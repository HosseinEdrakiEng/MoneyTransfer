namespace Application.Common
{
    public enum RegistryStatus
    {
        WAITING_FOR_USER,
        WAITING_FOR_VERIFICATION,
        VERIFIED,
        REJECTED,
        REVIEWING
    }
    public enum TransferDetailStatus : byte
    {
        None = 0,
        InProgress = 1,
        Retry = 2,
        Success = 3,
        Failed = 4,
        Canceled = 5,   
    }
}
