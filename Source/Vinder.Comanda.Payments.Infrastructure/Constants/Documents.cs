namespace Vinder.Comanda.Payments.Infrastructure.Constants;

public static class Documents
{
    public static class Payment
    {
        public const string Identifier = "_id";
        public const string Status = "Status";
        public const string Amount = "Amount";
        public const string PayerId = "Payer.Identifier";
        public const string ExternalId = "Metadata.Identifier";
        public const string ReferenceId = "Metadata.Reference";
        public const string CreatedAt = "CreatedAt";
    }
}