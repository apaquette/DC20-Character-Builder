
namespace Models.Classes;
public class Bard : BaseCharacterClass {
    public override string Name => "Bard";

    public override int Level => _level;

    public override int BonusHP => _bonusHP;

    protected override Func<int, int> BonusHPCalculation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Bard() {
        _level = 1;
        _bonusHP = 0;
    }
}
