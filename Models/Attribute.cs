namespace DC20Models;
public class Attribute {
    private readonly Func<int> _combatMastery;
    private readonly Func<int> _attributeLimit;

    public Attribute(Func<int> combatMastery, int value, bool saveProficiency, Func<int> attributeLimit) {

        if (value < -2 || value > attributeLimit()) {
            throw new InvalidAttributeException($"Value must be greater than -3 and less than {attributeLimit() + 1}");
        }

        _combatMastery = combatMastery;
        Value = value;
        SaveProficiency = saveProficiency;
        _attributeLimit = attributeLimit;
    }

    public int Value { get; private set; }
    public int Save => SaveProficiency ? Value + _combatMastery() : Value;
    public bool SaveProficiency { get; private set; }

    public static implicit operator int(Attribute attribute) {
        return attribute.Value;
    }
}
public class InvalidAttributeException : Exception {
    public InvalidAttributeException() {
    }

    public InvalidAttributeException(string message)
        : base(message) {
    }
}