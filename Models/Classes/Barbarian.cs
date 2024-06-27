namespace Models.Classes;
public class Barbarian : BaseCharacterClass {
    
    public override string Name => "Barbarian";

    public override int Level => _level;

    protected override Func<int, int> BonusHPCalculation { get; set; }

    public Barbarian() {
        _level = 1;
        _bonusHP = 1;

        BonusHPCalculation = (int level) => level * 1;
    }
}
