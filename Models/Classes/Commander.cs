namespace Models.Classes;
public class Commander : BaseCharacterClass {

    public override string Name => "Commander";

    public override int Level => _level;

    protected override Func<int, int> BonusHPCalculation { get; set; }

    public Commander() {
        _level = 1;
        _bonusHP = 1;

        BonusHPCalculation = (_level) => 1;
    }
}