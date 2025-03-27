using System;
using System.Collections.Generic;
using FluentResults;

namespace PLC.Commissioning.Lib.Abstractions
{
    /// <summary>
    /// General interface for a PLC controller.
    /// </summary>
    public interface IPLCController : IDisposable
    {
        /// <summary>
        /// Configures the connection and network interface using a JSON configuration file.
        /// </summary>
        /// <param name="jsonFilePath">
        /// The path to the JSON file containing the configuration settings.
        /// </param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the configuration was successful.
        /// On failure, the Result contains error details.
        /// In case of failure, metadata "ErrorCode" is set to 
        /// <see cref="OperationErrorCode.ConfigurationFailed"/>.
        /// </returns>
        Result Configure(string jsonFilePath);

        /// <summary>
        /// Initializes the Siemens PLC controller in offline mode.
        /// </summary>
        /// <param name="safety">Indicates whether safety mode is enabled.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, metadata "ErrorCode" is set to <see cref="OperationErrorCode.InitializationFailed"/>.
        /// </returns>
        Result Initialize(bool safety);

        /// <summary>
        /// Imports one or more devices into an industrial automation project (e.g., PROFINET, EtherNet/IP, or EtherCAT).
        /// </summary>
        /// <param name="filePath">The path to the device configuration file.</param>
        /// <param name="descriptionFiles">
        /// A list of relevant device description files (e.g., GSDML, EDS, ESI) used for mapping.
        /// </param>
        /// <returns>
        /// A <see cref="Result{T}"/> containing a dictionary of imported devices if successful.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.ImportFailed"/>.
        /// </returns>
        Result<Dictionary<string, object>> ImportDevices(string filePath, List<string> descriptionFiles);

        /// <summary>
        /// Saves the current project to a specific Documents/Openness/Saved_Projects/ directory.
        /// </summary>
        /// <param name="projectName">The name of the project.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.SaveProjectFailed"/>.
        /// </returns>
        Result SaveProjectAs(string dirPath);

        /// <summary>
        /// Retrieves device parameters for a specified module.
        /// </summary>
        /// <param name="device">
        ///   The device object to retrieve parameters from (must be an <see cref="ImportedDevice"/>).
        /// </param>
        /// <param name="moduleName">The name of the module to retrieve parameters for.</param>
        /// <param name="parameterSelections">
        ///   An optional list of parameter names to retrieve. If <c>null</c> or empty, all parameters are retrieved.
        /// </param>
        /// <param name="safety">Indicates whether safety parameters are required.</param>
        /// <returns>
        ///   A <see cref="Result{T}"/> containing a <see cref="Dictionary{String, Object}"/> of retrieved parameters on success.
        ///   On failure, the result is <see cref="Result.Fail{Dictionary{String, Object}}"/>, and the Error's metadata 
        ///   <c>"ErrorCode"</c> is set to <see cref="OperationErrorCode.GetParametersFailed"/>.
        ///   <para/>
        /// </returns>
        Result<Dictionary<string, object>> GetDeviceParameters(object device, string moduleName, List<string> parameterSelections = null, bool safety = false);


        /// <summary>
        /// Sets device parameters for a specified module.
        /// </summary>
        /// <param name="device">The device object to configure (must be an ImportedDevice).</param>
        /// <param name="moduleName">The name of the module to configure.</param>
        /// <param name="parametersToSet">A dictionary of parameters to set.</param>
        /// <param name="safety">Indicates whether safety parameters are being set.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.SetParametersFailed"/>.
        /// </returns>
        Result SetDeviceParameters(object device, string moduleName, Dictionary<string, object> parametersToSet, bool safety = false);

        /// <summary>
        /// Compiles the current PLC project.
        /// </summary>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.CompileFailed"/>.
        /// </returns>
        Result Compile();

        /// <summary>
        /// Downloads the PLC project to the PLC device.
        /// </summary>
        /// <param name="options">Options for the download process.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.DownloadFailed"/>.
        /// </returns>
        Result Download(object downloadOptions);

        /// <summary>
        /// Starts the PLC.
        /// </summary>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.StartFailed"/>.
        /// </returns>
        Result Start();

        /// <summary>
        /// Stops the PLC.
        /// </summary>
        /// <returns>
        /// A <see cref="Result"/> indicating success or failure.
        /// On failure, the Error's metadata "ErrorCode" is <see cref="OperationErrorCode.StopFailed"/>.
        /// </returns>
        Result Stop();
    }
}
