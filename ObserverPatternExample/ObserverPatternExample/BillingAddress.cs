namespace ObserverPatternExample;

public class BillingAddress
{
    public string Street { get; init; } = null!;
    public string City { get; init; } = null!;
    public string State { get; init; } = null!;
    public string Zip { get; init; } = null!;

    public string FullAddress => $"{Street}, {City}, {State} {Zip}";
}