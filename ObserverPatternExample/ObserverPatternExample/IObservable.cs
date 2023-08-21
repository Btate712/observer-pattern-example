namespace ObserverPatternExample;

public interface IObservable<T>
{
    void AddObserver(IObserver<T> observer);
    void RemoveObserver(IObserver<T> observer);
    void Notify();
}