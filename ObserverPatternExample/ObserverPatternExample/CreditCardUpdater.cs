namespace ObserverPatternExample;

public class CreditCardUpdater : IObserver<BillingAddress>
{
    private readonly string _name;
    
    // ReSharper disable once NotAccessedField.Local
    private BillingAddress _billingAddress;
    
    public CreditCardUpdater(string name, PersonalData personalData)
    {
        _name = name;
        _billingAddress = personalData.BillingAddress;
        personalData.AddObserver(this);
    }
    public void Update(BillingAddress billingAddress)
    {
        _billingAddress = billingAddress;
        Console.WriteLine($"Updated Credit Card billing address for {_name}.");
    }
}