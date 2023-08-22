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
        _phoneNumber = personalData.PhoneNumber;
        personalData.AddObserver(this as IObserver<BillingAddress>);
        personalData.AddObserver(this as IObserver<string>);
        WriteBillingAddressUpdateToConsole();
        WritePhoneNumberUpdateToConsole();
    }
    public void Update(BillingAddress observableState)
    {
        // Send change of address notification to CC Company
        _billingAddress = observableState;
        WriteBillingAddressUpdateToConsole();
    }

    public void Update(string observableState)
    {
        // Send change of phone notification to CC Company
        _phoneNumber = observableState;
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