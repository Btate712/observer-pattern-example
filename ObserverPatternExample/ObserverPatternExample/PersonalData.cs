namespace ObserverPatternExample;

public class PersonalData : IObservable<BillingAddress>
{
    private readonly List<IObserver<BillingAddress>> _observers;
    private BillingAddress _billingAddress;

    public string Name { get; set; }
    
    public BillingAddress BillingAddress
    {
        get => _billingAddress;
        
        set
        {
            _billingAddress = value;
            Console.WriteLine($"Set address for {Name} to {_billingAddress.FullAddress}");
            Notify();
        }
    }
    
    public PersonalData()
    {
        _billingAddress = new BillingAddress();
        _observers = new List<IObserver<BillingAddress>>();
    }
    
    public void AddObserver(IObserver<BillingAddress> observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver<BillingAddress> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver<BillingAddress> observer in _observers)
        {
            observer.Update(BillingAddress);
        }
    }
}