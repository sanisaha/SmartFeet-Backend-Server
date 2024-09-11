namespace Ecommerce.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        OnHold = 3,
        Shipped = 4,
        Delivered = 5,
        Completed = 6,
        Canceled = 7,
        Refunded = 8,
        Returned = 9,
        Failed = 10

    }
}