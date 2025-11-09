namespace Vinder.Comanda.Payments.Application.Payloads.Payment;

public sealed record PaymentsFetchParameters :
    IMessage<Result<PaginationScheme<PaymentScheme>>>
{
    public string? Id { get; set; }
    public string? PayerId { get; set; }
    public string? ExternalId { get; set; }
    public string? ReferenceId { get; set; }

    public Status? Status { get; set; }
    public PaymentMethod? Method { get; set; }

    public SortFilters? Sort { get; set; }
    public PaginationFilters? Pagination { get; set; }

    public DateOnly? CreatedAfter { get; set; }
    public DateOnly? CreatedBefore { get; set; }

    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
}