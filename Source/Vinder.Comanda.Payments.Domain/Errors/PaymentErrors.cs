namespace Vinder.Comanda.Payments.Domain.Errors;

public static class PaymentErrors
{
    public static readonly Error MethodNotAllowed = new(
        Code: "#COMANDA-ERROR-947B5",
        Description: "the specified payment method is not allowed for this type of transaction"
    );

    public static readonly Error CredentialNotProvided = new(
        Code: "#COMANDA-ERROR-3AF99",
        Description: "payment gateway credential was not provided"
    );
}
