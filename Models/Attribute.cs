namespace DC20Models;
public class Attribute {
    private readonly Func<int> _combatMastery;

    public Attribute(Func<int> combatMastery, int value, bool saveProficiency) {
        _combatMastery = combatMastery;
        Value = value;
        SaveProficiency = saveProficiency;
    }

    public int Value { get; private set; }
    public int Save => SaveProficiency ? Value + _combatMastery() : Value;
    public bool SaveProficiency { get; private set; }

    public static implicit operator int(Attribute attribute) {
        return attribute.Value;
    }
}