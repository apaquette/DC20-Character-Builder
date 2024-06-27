using Models.Classes.Prestige;

namespace Models.Classes;
public abstract class BaseCharacterClass : ICharacterClass {
    protected int _level;
    protected int _bonusHP;

    public abstract string Name { get; }

    public abstract int Level { get; }

    public int BonusHP => _bonusHP;

    protected abstract Func<int, int> BonusHPCalculation { get; set; }

    private BasePrestigeClass? _prestigeClass = null;

    public void LevelUp() {
        if(Level == 10 && _prestigeClass == null) {
            throw new();
        }

        ++_level;
        _bonusHP = BonusHPCalculation(Level);
    }

    public void SelectPrestigeClass(BasePrestigeClass prestigeClass) {
        _prestigeClass = prestigeClass;
        _prestigeClass.AddBaseClassHPCalculation(BonusHPCalculation);
        BonusHPCalculation = prestigeClass.BonusHPCalculation;
    }
}
