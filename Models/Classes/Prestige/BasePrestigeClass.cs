namespace Models.Classes.Prestige;
public abstract class BasePrestigeClass
{
    public abstract Func<int, int> BonusHPCalculation { get; set; }
    public void AddBaseClassHPCalculation(Func<int, int> baseClassCalc) {
        BonusHPCalculation += baseClassCalc;
    }
}