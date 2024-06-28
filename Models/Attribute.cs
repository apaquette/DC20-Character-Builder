namespace Models;
public class Attribute {
    private readonly Func<int> _combatMastery;
    private readonly Func<int> _level;
    private int AttributeLimit {
        get {
            return _level() switch {
                < 5 => 3,
                < 10 => 4,
                < 15 => 5,
                < 20 => 6,
                _ => 7
            };
        }
    }

    public Attribute(Func<int> combatMastery, int value, bool saveProficiency, Func<int> level) {
        _level = level;

        if (value < -2 || value > AttributeLimit) {
            throw new InvalidAttributeException($"Value must be greater than -3 and less than {AttributeLimit + 1}");
        }

        _combatMastery = combatMastery;
        Value = value;
        SaveProficiency = saveProficiency;
    }

    public int Value { get; private set; }
    public int Save => SaveProficiency ? Value + _combatMastery() : Value;
    public bool SaveProficiency { get; private set; }

    public static implicit operator int(Attribute attribute) => attribute.Value;
}
public class InvalidAttributeException : Exception {
    public InvalidAttributeException() {
    }

    public InvalidAttributeException(string message)
        : base(message) {
    }
}