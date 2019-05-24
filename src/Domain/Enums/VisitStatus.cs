namespace Domain.Enums
{
    //Configure enum to be stored in database as string 
    //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
    public enum VisitStatus
    {
        Generated,
        Accepted,
        VisitDateChanged,
        CanceledByCustomer,
        CanceledByAdmin,
        Completed
    }
}
