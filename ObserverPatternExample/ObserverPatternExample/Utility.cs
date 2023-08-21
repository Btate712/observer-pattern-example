namespace ObserverPatternExample;

public class Utility : IObserver<BillingAddress>
{
    private readonly string _name;
    
    // ReSharper disable once NotAccessedField.Local
    private BillingAddress _billingAddress;
    
    public Utility(string name, PersonalData personalData)
    {
        _name = name;
        _billingAddress = personalData.BillingAddress;
        personalData.AddObserver(this);
        WriteAddressToConsole();
    }
    public void Update(BillingAddress billingAddress)
    {
        _billingAddress = billingAddress;
        WriteAddressToConsole();
    }
    
    private void WriteAddressToConsole()
    {
        Console.WriteLine($"Set {_name} utility billing address to {_billingAddress.FullAddress}.");
    }
}