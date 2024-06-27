using Models.Ancestries;
using Models.Classes;


namespace Models;

public class Character {
    public string? Player { get; set; }
    public string? Name { get; set; }
    public int Level => CharacterClass.Level;
    public int CombatMastery => (int)Math.Ceiling((double)Level / 2);

    public ICharacterClass CharacterClass {get; private set;}
    public IAncestry Ancestry { get; private set; }
    
    public int HealthPoints => 6 + Level + Might + CharacterClass.BonusHP + Ancestry.BonusHP;

    // ATTRIBUTES
    public int Prime => (new int[] {Might, Agility, Charisma, Intelligence}).Max(x => x);
    public Attribute Might { get; }
    public Attribute Agility { get; }
    public Attribute Charisma { get; }
    public Attribute Intelligence { get; }
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

    public Character(ICharacterClass characterClass, IAncestry ancestry, int might = 0, int agi = 0, int cha = 0, int inte = 0, string? player = null, string? name = null) {
        Player = player;
        Name = name;

        CharacterClass = characterClass;
        Ancestry = ancestry;

        Might = new(() => CombatMastery, might, false, () => AttributeLimit);
        Agility = new(() => CombatMastery, agi, false, () => AttributeLimit);
        Charisma = new(() => CombatMastery, cha, false, () => AttributeLimit);
        Intelligence = new(() => CombatMastery, inte, false, () => AttributeLimit);

    }

    public void LevelUp() {
        CharacterClass.LevelUp();
    }
}