namespace Models.Classes.Prestige;
public class Martial : BasePrestigeClass
{
    public Martial()
    {
        BonusHPCalculation = (level) => level * 1;
    }

    public override Func<int, int> BonusHPCalculation { get; set; }
}
