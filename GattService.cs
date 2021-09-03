/****************************
 * Code created with the help of YouTube channel: "AngelSix"
 * YouTube Video URL: https://www.youtube.com/watch?v=r2e2bmcfdL0 
 * "AngelSix" Source Code: https://github.com/angelsix/blueberry
 ****************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ECEN403_FormsApp.Bluetooth
{
    /// <summary>
    /// Details about a specific GATT service
    /// <seealso cref="https://www.bluetooth.com/specifications/assigned-numbers/"/>
    /// </summary>
    public class GattService
    {
        #region Public Properties

        /// <summary>
        /// The human-readable name for the service
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The uniform identifier that is unique to this service
        /// </summary>
        public string UniformTypeIdentifier { get; }

        /// <summary>
        /// The 16-bit assigned number for this service.
        /// The Bluetooth GATT Service universally unique ID (UUID).
        /// </summary>
        public ushort UUID { get; }

        /// <summary>
        /// The type of sepcification that this service is.
        /// <seealso cref="https://www.bluetooth.com/specifications/"/>
        /// </summary>
        public string ProfileSpecification { get; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GattService(string name, string uniformIdentifier, ushort uuid, string specification)
        {
            Name = name;
            UniformTypeIdentifier = uniformIdentifier;
            UUID = uuid;
            ProfileSpecification = specification;
        }

        #endregion
    }
}
