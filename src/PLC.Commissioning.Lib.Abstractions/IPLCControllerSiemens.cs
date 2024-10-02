using System;
using System.Collections.Generic;
using System.Text;

namespace PLC.Commissioning.Lib.Abstractions
{
    // Siemens specific 
    public interface IPLCControllerSiemens : IPLCController
    {
        /// <summary>
        /// Configures specific device parameters such as IP address and Profinet name.
        /// </summary>
        /// <param name="parametersToConfigure">A dictionary containing key-value pairs of parameters to configure.</param>
        /// <returns><c>true</c> if the configuration was successful; otherwise, <c>false</c>.</returns>
        /// <example>
        /// Example JSON structure:
        /// <code>
        /// {
        ///     "ipAddress": "192.168.0.1",
        ///     "profinetName": "PLC_1"
        /// }
        /// </code>
        /// </example>
        bool ConfigureDevice(object device, Dictionary<string, object> parametersToConfigure);

        /// <summary>
        /// Retrieves a device object by its name.
        /// </summary>
        /// <param name="device">The name of the device to retrieve.</param>
        /// <returns>
        /// An object representing the device with the specified name, 
        /// or <c>null</c> if no such device is found. 
        /// The returned object should be cast to a <see cref="Device"/>.
        /// </returns>
        /// <remarks>
        /// Ensure that the returned object is cast to the <see cref="Device"/> type by the caller.
        /// </remarks>
        object GetDeviceByName(string device);

        /// <summary>
        /// Imports additional items such as PLC tags or other helper files into the project.
        /// </summary>
        /// <param name="filesToImport">A dictionary where the key represents the type of import (e.g., "plcTags") and the value is the file path.</param>
        /// <returns><c>true</c> if the import was successful; otherwise, <c>false</c>.</returns>
        /// <example>
        /// Example JSON structure:
        /// <code>
        /// {
        ///     "plcTags": "C:\\path\\to\\tags.xml"
        /// }
        /// </code>
        /// </example>
        bool AdditionalImport(Dictionary<string, object> filesToImport);

        /// <summary>
        /// Exports specified items such as PLC tags or the project to a different directory.
        /// </summary>
        /// <param name="filesToExport">A dictionary where the key represents the type of export (e.g., "plcTags") and the value is the export path.</param>
        /// <returns><c>true</c> if the export was successful; otherwise, <c>false</c>.</returns>
        /// <example>
        /// Example JSON structure:
        /// <code>
        /// {
        ///     "plcTags": "C:\\export\\path\\tags.xml"
        /// }
        /// </code>
        /// </example>
        bool Export(Dictionary<string, object> filesToExport);

        /// <summary>
        /// Prints GSD information for debugging purposes.
        /// </summary>
        /// <param name="gsdFilePath">The path to the GSD file to be processed.</param>
        /// <param name="moduleName">Optional: The name of a specific module to print information for. If not provided, all modules will be printed.</param>
        /// <returns><c>true</c> if the GSD information was printed successfully; otherwise, <c>false</c>.</returns>
        bool PrintGSDInformations(string gsdFilePath, string moduleName = null);
    }
}
