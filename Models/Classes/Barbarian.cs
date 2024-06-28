namespace Models.Classes;
public class Barbarian : BaseClass, IMartial {
    // Base Class
    public override string Name => "Barbarian";

    public override Func<int> BonusHP { get; }

    public Barbarian() {
        BonusHP = () => 1 * Level;
    }

    public override Func<int> AttributePoints => throw new NotImplementedException();

    public override Func<int> SkillPoints => throw new NotImplementedException();
    // IMartial
    public Func<int> StaminaPoints => throw new NotImplementedException();

    public Func<int> ManeuversKnown => throw new NotImplementedException();

    public Func<int> TechniquesKnown => throw new NotImplementedException();
    
}
