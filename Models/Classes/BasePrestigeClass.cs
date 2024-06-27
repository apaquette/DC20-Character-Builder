namespace Models.Classes; 
public abstract class BasePrestigeClass {
    public abstract Func<int, int> BonusHPCalculation { get; }
}