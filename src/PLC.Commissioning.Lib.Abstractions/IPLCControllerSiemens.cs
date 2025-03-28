using System;
using System.Collections.Generic;
using FluentResults;

namespace PLC.Commissioning.Lib.Abstractions
{
    /// <summary>
    /// Siemens-specific interface for a PLC controller.
    /// </summary>
    public interface IPLCControllerSiemens : IPLCController
    {
        /// <summary>
        /// Configures specific device parameters such as IP address and Profinet name.
        /// </summary>
        /// <param name="device">The device to configure (expected to be an ImportedDevice).</param>
        /// <param name="parametersToConfigure">
        /// A dictionary containing key-value pairs of parameters to configure. 
        /// For example:
        /// {
        ///     "ipAddress": "192.168.0.1",
        ///     "profinetName": "PLC_1"
        /// }
        /// </param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.ConfigurationFailed"/>.
        /// </returns>
        Result ConfigureDevice(object device, Dictionary<string, object> parametersToConfigure);

        /// <summary>
        /// Retrieves a device object by its name.
        /// </summary>
        /// <param name="deviceName">The name of the device to retrieve.</param>
        /// <returns>
        /// A <see cref="Result{T}"/> containing the device object if found. 
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.GetParametersFailed"/>.
        /// </returns>
        /// <remarks>
        /// Ensure that the returned object is cast to the <see cref="ProjectDevice"/> type by the caller.
        /// </remarks>
        Result<object> GetDeviceByName(string deviceName);

        /// <summary>
        /// Imports additional items such as PLC tags or other helper files into the project.
        /// </summary>
        /// <param name="filesToImport">
        /// A dictionary where the key represents the type of import (e.g., "plcTags")
        /// and the value is the file path.
        /// </param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.ImportFailed"/>.
        /// </returns>
        /// <example>
        /// Example JSON structure:
        /// {
        ///     "plcTags": "C:\\path\\to\\tags.xml"
        /// }
        /// </example>
        Result AdditionalImport(Dictionary<string, object> filesToImport);

        /// <summary>
        /// Exports specified items such as PLC tags or the project to a different directory.
        /// </summary>
        /// <param name="filesToExport">
        /// A dictionary where the key represents the type of export (e.g., "plcTags")
        /// and the value is the export path.
        /// </param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.SaveProjectFailed"/>.
        /// </returns>
        /// <example>
        /// Example JSON structure:
        /// {
        ///     "plcTags": "C:\\export\\path\\tags.xml"
        /// }
        /// </example>
        Result Export(Dictionary<string, object> filesToExport);

        /// <summary>
        /// Prints GSD information for debugging purposes.
        /// </summary>
        /// <param name="gsdFilePath">The path to the GSD file to be processed.</param>
        /// <param name="moduleName">
        /// Optional: The name of a specific module to print information for.
        /// If not provided, all modules will be printed.
        /// </param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.GetParametersFailed"/>.
        /// </returns>
        Result PrintGSDInformations(string gsdFilePath, string moduleName = null);
        
        /// <summary>
        /// Deletes the specified device and all of its associated PLC tags from the project.
        /// </summary>
        /// <param name="device">The device object to delete. Must be an ImportedDevice.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.DeleteDeviceFailed"/>.
        /// </returns>
        Result DeleteDevice(object device);

        /// <summary>
        /// Reads and returns all PLC tag tables.
        /// </summary>
        /// <returns>A list of tag table names.</returns>
        Result<Dictionary<string, List<string>>> ReadPLCTagTables();
    }
}
