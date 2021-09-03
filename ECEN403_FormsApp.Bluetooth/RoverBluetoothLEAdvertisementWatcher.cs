/****************************
 * Code created with the help of YouTube channel: "AngelSix"
 * YouTube Video URL: https://www.youtube.com/watch?v=RVasdDtgLKY
 * "AngelSix" Source Code: https://github.com/angelsix/blueberry
 ****************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace ECEN403_FormsApp.Bluetooth
{
    /// <summary>
    /// Defines and uses the <see cref="BluetoothLEAdvertisementWatcher"/>
    /// for easier use and allow open source adaptivity
    /// </summary>
    public class RoverBluetoothLEAdvertisementWatcher
    {

        #region Private Members
        // Read onlys are made here because user should not change this info
        /// <summary>
        /// Underlying bluetooth watcher class
        /// </summary>
        private readonly BluetoothLEAdvertisementWatcher AdWatcher;

        /// <summary>
        /// A list of discovered devices
        /// </summary>
        private readonly Dictionary<string, RoverBluetoothLEDevice> mDiscoveredDevices = new Dictionary<string, RoverBluetoothLEDevice>();

        /// <summary>
        /// The details about GATT services
        /// </summary>
        private readonly GattServiceIDs mGattServiceIDs;

        /// <summary>
        /// A thread lock object for this class
        /// </summary>
        private readonly object mThreadLock = new object();
        #endregion

        #region Public Properties

        /// <summary>
        /// Indicate if this watcher is listening for advertisements
        /// </summary>
        public bool Listening => AdWatcher.Status == BluetoothLEAdvertisementWatcherStatus.Started;

        /// <summary>
        /// A list of discovered devices
        /// </summary>
        public IReadOnlyCollection<RoverBluetoothLEDevice> DiscoveredDevices
        {
            get
            {
                // Cleanup timeouts
                CleanupTimeouts();

                // Making this Thread-safe
                lock (mThreadLock)
                {
                    // Convert to read-only list
                    return mDiscoveredDevices.Values.ToList().AsReadOnly();
                }
            }
        }

        /// <summary>
        /// The timeout in seconds that a device is removed from <see cref="DiscoveredDevices"/>
        /// list if it is re-advertised within this time
        /// </summary>
        public int Timeout { get; set; } = 30;

        #endregion

        #region Public Events

        /// <summary>
        /// Initiated when the blutooth watcher stops listening
        /// defaulted to be empty (i.e. () => [];)
        /// </summary>
        public event Action StoppedListening = () => { };

        /// <summary>
        /// Initiated when the blutooth watcher starts listening
        /// defaulted to be empty (i.e. () => [];)
        /// </summary>
        public event Action StartedListening = () => { };

        /// <summary>
        /// Fired up when a new device is discovered
        /// </summary>
        public event Action<RoverBluetoothLEDevice> NewDeviceDiscovered = (device) => { };

        /// <summary>
        /// Fired up when a device is discovered
        /// </summary>
        public event Action<RoverBluetoothLEDevice> DeviceDiscovered = (device) => { };

        /// <summary>
        /// Fired up when a device name changes
        /// </summary>
        public event Action<RoverBluetoothLEDevice> DeviceNameChanged = (device) => { };

        /// <summary>
        /// Fired up when a device is removed for timing out
        /// </summary>
        public event Action<RoverBluetoothLEDevice> DeviceTimeout = (device) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor statement
        /// </summary>
        public RoverBluetoothLEAdvertisementWatcher(GattServiceIDs gattIDs) 
        {
            // Null guard
            mGattServiceIDs = gattIDs ?? throw new ArgumentNullException(nameof(gattIDs));

            // Create Bluetooth listener
            AdWatcher = new BluetoothLEAdvertisementWatcher
            {
                ScanningMode = BluetoothLEScanningMode.Active
            };

            // Listens for new advertisements (or signal payload)
            AdWatcher.Received += WatcherAdvertisementReceivedAsync;

            //  Listens for when the watcher stops listening
            AdWatcher.Stopped += (watcher, e) =>
            {
                StoppedListening();
            };
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Listens out for watcher advertisements
        /// </summary>
        /// <param name="sender"> The watcher </param>
        /// <param name="args"> The arguments </param>
        private async void WatcherAdvertisementReceivedAsync(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            // Cleanup timeouts
            CleanupTimeouts();

            // Get BLE device info
            var device = await GetBluetoothLEDeviceAsync(
                args.BluetoothAddress, 
                args.Timestamp, 
                args.RawSignalStrengthInDBm);

            // Null guard
            if (device == null)
                // Can't do anything so do nothing
                return;

            // Is new discovery?
            var newDiscovery = false;
            var exisitingName = default(string);

            // Looping the list needs locking
            lock (mThreadLock)
            {
                // Check if this is a new discovery
                newDiscovery = !mDiscoveredDevices.ContainsKey(device.DeviceID);

                // If this is not new
                if (!newDiscovery)
                    // Store the old name
                    exisitingName = mDiscoveredDevices[device.DeviceID].Name;
            }

            // Did name change?
            var nameChanged = 
                // If it already exits
                !newDiscovery && 
                // And its name is not blank
                !string.IsNullOrEmpty(args.Advertisement.LocalName) &&
                // And if name is different
                exisitingName != device.Name;

            lock (mThreadLock)
            {
                // Add/update device in dictionary 
                mDiscoveredDevices[device.DeviceID] = device;
            }

            // Inform Listeners
            DeviceDiscovered(device);

            // if name changed...
            if (nameChanged)
                // Inform Listeners
                DeviceNameChanged(device);

            // if newDiscovery...
            if (newDiscovery)
                // Inform Listeners
                NewDeviceDiscovered(device);
            // throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to the BLE device and extracts more information from the 
        /// <see cref="https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.bluetoothledvice"/>
        /// </summary>
        /// <param name="address">The Bluetooth address of the device to connect to</param>
        /// <param name="broadcastTime">The time the broadcast message was received</param>
        /// <param name="rssi">The signal strength in dB</param>
        /// <returns></returns>
        /// <Capabilities> <DeviceCapability Name = "bluetooth"/></Capabilities>
        private async Task<RoverBluetoothLEDevice> GetBluetoothLEDeviceAsync(ulong address, DateTimeOffset broadcastTime, short rssi)
        {
            // Get bluetooth device info
            var device = await BluetoothLEDevice.FromBluetoothAddressAsync(address).AsTask();

            // Null Guard
            if (device == null)
                return null;

            // NOTE: This can throw a System.Exception for failures
            // Get GATT services that are available
            var gatt = await device.GetGattServicesAsync().AsTask();

            // If we have any services...
            if (gatt.Status == GattCommunicationStatus.Success)
            {
                // Loop each GATT service
                foreach (var service in gatt.Services)
                {
                    // This ID contains the GATT Profile Assigned number needed
                    // TODO: Get more info and connect
                    var gattProfileId = service.Uuid;
                }
            }

            // Return the new device information
            return new RoverBluetoothLEDevice
            (
                // Device ID
                deviceID: device.DeviceId,
                // Bluetooth Address
                addressBT: device.BluetoothAddress,
                // Device name
                name: device.Name,
                // Broadcast time
                broadcastTime: broadcastTime,
                // Signal strength
                rssi: rssi,
                // Is Connected?
                connected: device.ConnectionStatus == BluetoothConnectionStatus.Connected,
                // Can Pair?
                canPair: device.DeviceInformation.Pairing.CanPair,
                // Is Paired?
                paired: device.DeviceInformation.Pairing.IsPaired
            );
        }

        /// <summary>
        /// Prune any timed out devices that we have not heard of
        /// </summary>
        private void CleanupTimeouts()
        {
            lock (mThreadLock)
            {
                // The date in time that if less than means a device has timed out
                var threshold = DateTime.UtcNow - TimeSpan.FromSeconds(Timeout);

                // Any devices that have no sent a new broadcast within the time
                mDiscoveredDevices.Where(f => f.Value.BroadcastTime < threshold).ToList().ForEach(device =>
                {
                    // Remove device
                    mDiscoveredDevices.Remove(device.Key);

                    // Inform listeners
                    DeviceTimeout(device.Value);
                });
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts listening for Bluetooth LE Advertisements
        /// </summary>
        public void StartListening()
        {
            lock (mThreadLock)
            {
                // if already listening,
                if (Listening)
                {
                    // Do nothing here
                    return;
                }

                // Otherwise, start underlying watcher
                AdWatcher.Start();
            }

            // Inform listeners
            StartedListening();
        }

        /// <summary>
        /// Stops listening for BLE advertisements
        /// </summary>
        public void StopListening()
        {
            lock (mThreadLock)
            {
                // if we are not currently listening...
                if (!Listening)
                    // Do nothing
                    return;

                // Stop listening, no need to inform listeners
                AdWatcher.Stop();

                // Clear any devices
                mDiscoveredDevices.Clear();
            }
        }

        /// <summary>
        /// Attempts to pair to a BLE device via ID
        /// </summary>
        /// <param name="deviceID">The BLE device ID</param>
        /// <returns></returns>
        public async Task PairToDeviceAsync(string deviceID)
        {
            // Get bluetooth device info
            var device = await BluetoothLEDevice.FromIdAsync(deviceID).AsTask();

            // Null Guard
            if (device == null)
                // TODO: Localize
                throw new ArgumentNullException("Failed to get information about the Bluetooth device");

            // If we are already paired...
            if (device.DeviceInformation.Pairing.IsPaired)
                // Do nothing
                return;

            // Listen out for pairing request
            device.DeviceInformation.Pairing.Custom.PairingRequested += (sender,
                args) =>
            {
                // Log it
                // TODO: Remove console calls
                Console.WriteLine("Accepting Pairing request...");

                // Accept all attempts
                args.Accept();  // <-- Could enter a pin in here to accept
            };

            // Try and pair to the device
            var result = await device.DeviceInformation.Pairing.Custom.PairAsync(
                // For Contour we should try Provide Pin
                // TODO: try different types to see if any work on other devices
                DevicePairingKinds.ProvidePin).AsTask();

            if (result.Status == DevicePairingResultStatus.Paired)
                // TODO: Remove
                Console.WriteLine("Pairing successful");
            else
                // TODO: Remove
                Console.WriteLine($"Pairing failed: {result.Status}");
        }

        #endregion
    }
}
