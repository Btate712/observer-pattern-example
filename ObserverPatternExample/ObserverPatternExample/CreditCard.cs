namespace ObserverPatternExample;

public class CreditCard : IObserver<BillingAddress>
{
    private readonly string _name;
    
    // ReSharper disable once NotAccessedField.Local
    private BillingAddress _billingAddress;
    
    public CreditCard(string name, PersonalData personalData)
    {
        _name = name;
        _billingAddress = personalData.BillingAddress;
        personalData.AddObserver(this);
        WriteUpdateToConsole();
    }
    public void Update(BillingAddress billingAddress)
    {
        // Send change of address notification to CC Company
        _billingAddress = billingAddress;
        WriteUpdateToConsole();
    }

    private void WriteUpdateToConsole()
    {
        Console.WriteLine($"Set Credit Card billing address for {_name} to {_billingAddress.FullAddress}.");
    }
}