namespace PLC.Commissioning.Lib.Abstractions.Enums
{
    /// <summary>
    /// A set of standard error codes for operations.
    /// </summary>
    public enum OperationErrorCode
    {
        None,
        ConfigurationFailed,
        InitializationFailed,
        ImportFailed,
        GetParametersFailed,
        SetParametersFailed,
        CompileFailed,
        DownloadFailed,
        StartFailed,
        StopFailed,
        
        // Siemens specific
        SaveProjectFailed,
        DeleteDeviceFailed,
        ReadTagTablesFailed,
        ExportFailed,
        GetDeviceFailed
    }
}