namespace Models.Classes;
public class Barbarian : BaseCharacterClass {
    
    public override string Name => "Barbarian";

    public override int Level => _level;

    public override int BonusHP => _bonusHP;

    protected override Func<int, int> BonusHPCalculation { get; set; }

    public Barbarian() {
        _level = 1;
        _bonusHP = 1;

        BonusHPCalculation = (int level) => 1;
    }
}
