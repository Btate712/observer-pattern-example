namespace ObserverPatternExample;

public class BillingAddress
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Zip { get; set; } = null!;

    public string FullAddress => $"{Street}, {City}, {State} {Zip}";
}