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
        SaveProjectFailed,
        GetParametersFailed,
        SetParametersFailed,
        CompileFailed,
        DownloadFailed,
        StartFailed,
        StopFailed,
        DeleteDeviceFailed,
        // Add more error codes as needed
    }
}