namespace Ecommerce.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 1,
        Authorized = 2,
        Successful = 3,
        Declined = 4,
        Refunded = 5,
        PartiallyRefunded = 6,
        Failed = 7,
        Cancelled = 8,
        Expired = 9

    }
}