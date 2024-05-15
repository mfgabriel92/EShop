namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardName { get; } = default!;

    public string CardNumber { get; } = default!;

    public string Expiration { get; } = default!;

    public string CVV { get; } = default!;

    public PaymentMethod PaymentMethod { get; } = default!;

    protected Payment() { }

    private Payment(string cardName, string cardNumber, string expiration, string cvv, PaymentMethod paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, PaymentMethod paymentMethod)
    {
        ArgumentException.ThrowIfNullOrEmpty(cardName);
        ArgumentException.ThrowIfNullOrEmpty(cardNumber);
        ArgumentException.ThrowIfNullOrEmpty(expiration);
        ArgumentException.ThrowIfNullOrEmpty(cvv);
        ArgumentNullException.ThrowIfNull((int)paymentMethod);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}