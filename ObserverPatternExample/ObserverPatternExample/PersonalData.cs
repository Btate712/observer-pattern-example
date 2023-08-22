namespace ObserverPatternExample;

public class PersonalData : IObservable<BillingAddress>, IObservable<string>
{
    private readonly List<IObserver<BillingAddress>> _billingAddressObservers;
    private readonly List<IObserver<string>> _phoneNumberObservers;
    
    private BillingAddress _billingAddress;
    private string _phoneNumber;
    private bool _billingAddressChanged = false;
    private bool _phoneNumberChanged = false;
    
    public PersonalData(string name)
    {
        Name = name;
        _billingAddress = new BillingAddress();
        _phoneNumber = string.Empty;
        _billingAddressObservers = new List<IObserver<BillingAddress>>();
        _phoneNumberObservers = new List<IObserver<string>>();
    }
    
    public string Name { get; private set; }

    public string PhoneNumber
    {
        get => _phoneNumber;

        set
        {
            _phoneNumber = value;
            Console.WriteLine($"Set phone number for {Name} to {_phoneNumber}");
            _phoneNumberChanged = true;
            Notify();
        }
    }
    public BillingAddress BillingAddress
    {
        get => _billingAddress;
        
        set
        {
            _billingAddress = value;
            Console.WriteLine($"Set address for {Name} to {_billingAddress.FullAddress}");
            _billingAddressChanged = true;
            Notify();
        }
    }

    public void AddObserver(IObserver<BillingAddress> observer)
    {
        _billingAddressObservers.Add(observer);
    }

    public void RemoveObserver(IObserver<BillingAddress> observer)
    {
        _billingAddressObservers.Remove(observer);
    }

    public void AddObserver(IObserver<string> observer)
    {
        _phoneNumberObservers.Add(observer);
    }

    public void RemoveObserver(IObserver<string> observer)
    {
        _phoneNumberObservers.Remove(observer);
    }

    public void Notify()
    {
        if (_billingAddressChanged)
        {
            UpdateBillingAddressObservers();
        }

        if (_phoneNumberChanged)
        {
            UpdatePhoneNumberObservers();
        }
    }

    private void UpdateBillingAddressObservers()
    {
        foreach (IObserver<BillingAddress> observer in _billingAddressObservers)
        {
            observer.Update(BillingAddress);
        }

        _billingAddressChanged = false;
    }

    private void UpdatePhoneNumberObservers()
    {
        foreach (IObserver<string> observer in _phoneNumberObservers)
        {
            observer.Update(PhoneNumber);
        }

        _phoneNumberChanged = false;
    }
}