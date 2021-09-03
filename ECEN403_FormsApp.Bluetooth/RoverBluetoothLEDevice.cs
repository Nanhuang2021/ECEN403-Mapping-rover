/****************************
 * Code created with the help of YouTube channel: "AngelSix"
 * YouTube Video URL: https://www.youtube.com/watch?v=RVasdDtgLKY
 * "AngelSix" Source Code: https://github.com/angelsix/blueberry
 ****************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ECEN403_FormsApp.Bluetooth
{
    /// <summary>
    /// Information about the BLE device
    /// </summary>
    public class RoverBluetoothLEDevice
    {
        #region Public Properties

        /// <summary>
        /// The time of the broadcast advertisement message of the device
        /// </summary>
        public DateTimeOffset BroadcastTime { get;  }

        /// <summary>
        /// The address of the device
        /// </summary>
        public ulong Address { get; }

        /// <summary>
        /// The name of the device
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The signal strength in dB
        /// </summary>
        public short SignalStrengthdB { get; }

        /// <summary>
        /// Indicates if we are connected to this device
        /// </summary>
        public bool Connected { get; }

        /// <summary>
        /// Indicates if this device supports pairing
        /// </summary>
        public bool CanPair { get; }

        /// <summary>
        /// Indicates if we are currently paired to this device
        /// </summary>
        public bool Paired { get; }

        /// <summary>
        /// The permanent unique ID of this device
        /// </summary>
        public string DeviceID { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// Defualt Constructor
        /// </summary>
        /// <param name="addressBT">Device Bluetooth address</param>
        /// <param name="name">Device Bluetooth name</param>
        /// <param name="rssi">Device's signal strength</param>
        /// <param name="broadcastTime">Broadcast time of the discovery</param>
        /// <param name="connected">Connection Status of device</param>
        /// <param name="canPair">If device can pair with us</param>
        /// <param name="paired">Paired Status of device</param>
        /// <param name="deviceID">Unique ID of device</param>
        public RoverBluetoothLEDevice(
            ulong addressBT, 
            string name, 
            short rssi, 
            DateTimeOffset broadcastTime, 
            bool connected,
            bool canPair,
            bool paired,
            string deviceID)
        {
            Address = addressBT;
            Name = name;
            SignalStrengthdB = rssi;
            BroadcastTime = broadcastTime;
            Connected = connected;
            CanPair = canPair;
            Paired = paired;
            DeviceID = deviceID;
        }

        #endregion

        /// <summary>
        /// Repurposed User friendly ToString function
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ (string.IsNullOrEmpty(Name) ? "[No Name]" : Name) } [{DeviceID}] ({SignalStrengthdB})";
        }
    }
}
