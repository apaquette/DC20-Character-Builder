namespace Models;

public class Character {
    public string? PlayerName { get; set; }
    public string? Name { get; set; }
    public int Level { get; private set; }
    public int CombatMastery => (int)Math.Ceiling((double)Level / 2);
    public int AttributeLimit {
        get {
            return Level switch {
                < 5 => 3,
                < 10 => 4,
                < 15 => 5,
                < 20 => 6,
                _ => 7
            };
        }
    }

    // ATTRIBUTES
    public int Prime => (new int[] {Might, Agility, Charisma, Intelligence}).Max(x => x);
    public Attribute Might { get; }
    public Attribute Agility { get; }
    public Attribute Charisma { get; }
    public Attribute Intelligence { get; }

    public Character(string? playerName = null, string? name = null, int might = 0, int agi = 0, int cha = 0, int inte = 0) {
        PlayerName = playerName;
        Name = name;
        Level = 1;

        Might = new(() => CombatMastery, might, false, () => AttributeLimit);
        Agility = new(() => CombatMastery, agi, false, () => AttributeLimit);
        Charisma = new(() => CombatMastery, cha, false, () => AttributeLimit);
        Intelligence = new(() => CombatMastery, inte, false, () => AttributeLimit);
    }

    public void LevelUp() {
        ++Level;
    }
}