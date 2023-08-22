namespace ObserverPatternExample;

public interface IObservable<out T>
{
    void AddObserver(IObserver<T> observer);
    void RemoveObserver(IObserver<T> observer);
    void Notify();
}