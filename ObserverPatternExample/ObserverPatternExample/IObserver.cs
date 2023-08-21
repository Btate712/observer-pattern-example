namespace ObserverPatternExample;

public interface IObserver<in T>
{
    void Update(T observeableState);
}