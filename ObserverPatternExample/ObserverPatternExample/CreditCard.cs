namespace ObserverPatternExample;

public class CreditCard : IObserver<BillingAddress>, IObserver<string>
{
    private readonly string _name;
    private string _phoneNumber;
    
    private BillingAddress _billingAddress;
    
    public CreditCard(string name, PersonalData personalData)
    {
        _name = name;
        _billingAddress = personalData.BillingAddress;
        personalData.AddObserver(this as IObserver<BillingAddress>);
        personalData.AddObserver(this as IObserver<string>);
        WriteBillingAddressUpdateToConsole();
    }
    public void Update(BillingAddress billingAddress)
    {
        // Send change of address notification to CC Company
        _billingAddress = billingAddress;
        WriteBillingAddressUpdateToConsole();
    }

    public void Update(string phoneNumber)
    {
        // Send change of phone notification to CC Company
        _phoneNumber = phoneNumber;
        WritePhoneNumberUpdateToConsole();
    }
    
    private void WriteBillingAddressUpdateToConsole()
    {
        Console.WriteLine($"Set Credit Card billing address for {_name} to {_billingAddress.FullAddress}.");
    }    
    
    private void WritePhoneNumberUpdateToConsole()
    {
        Console.WriteLine($"Set contact number for {_name} to {_phoneNumber}.");
    }
}