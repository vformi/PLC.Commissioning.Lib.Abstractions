using System;
using System.Collections.Generic;

namespace PLC.Commissioning.Lib.Abstractions
{
    public interface IPLCController : IDisposable
    {
        /// <summary>
        /// Configures the connection and network interface.
        /// </summary>
        /// <param name="jsonFilePath">The path to a JSON file containing the configuration settings.</param>
        /// <returns>A boolean indicating if the configuration was successful.</returns>
        bool Configure(string jsonFilePath);

        /// <summary>
        /// Opens programming tool and initializes connection to the PLC.
        /// </summary>
        /// <param name="safety"> Indicates if we are working with Safety device or not</param>
        /// <param name="debug"> Displays some debug information, network card info, device info etc</param>
        /// <returns>A boolean indicating if the connection was successfully initialized.</returns>
        bool Initialize(bool safety);

        /// <summary>
        /// Imports a device or multiple devices configuration into the Siemens PLC project.
        /// </summary>
        /// <param name="filePath">The path to the device configuration file.</param>
        /// <returns>A dictionary with device names as keys and corresponding objects as values, or <c>null</c> if the import fails.</returns>
        object ImportDevice(string filePath);

        /// <summary>
        /// Saves project under specified directory path 
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        bool SaveProjectAs(string dirPath);

        /// <summary>
        /// Retrieves device parameters for a specified module.
        /// </summary>
        /// <param name="device">The device object to retrieve parameters for.</param>
        /// <param name="gsdFilePath">The file path to the GSD file.</param>
        /// <param name="moduleName">The name of the module to retrieve parameters for.</param>
        /// <param name="parameterSelections">Optional list of parameters to retrieve.</param>
        /// <param name="safety">Indicates whether safety parameters are required.</param>
        /// <returns><c>true</c> if the parameters were retrieved successfully; otherwise, <c>false</c>.</returns>
        bool GetDeviceParameters(object device, string gsdFilePath, string moduleName, List<string> parameterSelections = null, bool safety = false);

        /// <summary>
        /// Sets device parameters for a specified module.
        /// </summary>
        /// <param name="device">The device object to configure.</param>
        /// <param name="gsdFilePath">The file path to the GSD file.</param>
        /// <param name="moduleName">The name of the module to configure.</param>
        /// <param name="parametersToSet">A dictionary of parameters to set.</param>
        /// <param name="safety">Indicates whether safety parameters are being set.</param>
        /// <returns><c>true</c> if the parameters were set successfully; otherwise, <c>false</c>.</returns>
        bool SetDeviceParameters(object device, string gsdFilePath, string moduleName, Dictionary<string, object> parametersToSet, bool safety = false);

        /// <summary>
        /// Compiles the project
        /// </summary>
        /// <returns></returns>
        bool Compile();

        /// <summary>
        /// Downloads the project
        /// </summary>
        /// <returns></returns>
        bool Download(object downloadOptions);

        /// <summary>
        /// Starts the PLC.
        /// </summary>
        /// <returns>A boolean indicating if the PLC started successfully.</returns>
        bool Start();

        /// <summary>
        /// Stops the PLC.
        /// </summary>
        /// <returns>A boolean indicating if the PLC stopped successfully.</returns>
        bool Stop();
    }
}
