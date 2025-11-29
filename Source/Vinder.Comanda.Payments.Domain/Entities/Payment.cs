namespace Vinder.Comanda.Payments.Domain.Entities;

public sealed class Payment : Entity
{
    public Status Status { get; set; } = Status.Pending;
    public Method Method { get; set; } = Method.Pix;

    public PaymentMetadata Metadata { get; set; } = PaymentMetadata.None;
    public User Payer { get; set; } = default!;

    public decimal Fee { get; set; } = 0m;
    public decimal Amount { get; set; } = 0m;

    public void MarkAsPaid() => Status = Status.Paid;
    public void MarkAsRefunded() => Status = Status.Refunded;
    public void MarkAsFailed() => Status = Status.Failed;
}