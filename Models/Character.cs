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
    public DC20Models.Attribute Might { get; }
    public DC20Models.Attribute Agility { get; }
    public DC20Models.Attribute Charisma { get; }
    public DC20Models.Attribute Intelligence { get; }

    public Character(string? playerName = null, string? name = null) {
        PlayerName = playerName;
        Name = name;
        Level = 1;
    }

    public void LevelUp() {
        ++Level;
    }
}