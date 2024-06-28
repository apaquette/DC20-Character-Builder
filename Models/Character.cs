using Models.Ancestries;
using Models.Classes;


namespace Models;

public class Character {
    public string? Player { get; set; }
    public string? Name { get; set; }
    public int Level => CharacterClass.Level;
    public int CombatMastery => (int)Math.Ceiling((double)Level / 2);

    public BaseClass CharacterClass { get; private set; }
    public IAncestry Ancestry { get; private set; }

    public Func<int> HealthPoints { get; private set; } // + CharacterClass.BonusHP + Ancestry.BonusHP;

    // ATTRIBUTES
    public int Prime => (new int[] {Might, Agility, Charisma, Intelligence}).Max(x => x);
    public Attribute Might { get; }
    public Attribute Agility { get; }
    public Attribute Charisma { get; }
    public Attribute Intelligence { get; }

    public Character(BaseClass characterClass, IAncestry ancestry, int might, int agi, int cha, int inte, string? player = null, string? name = null) {
        Player = player;
        Name = name;

        CharacterClass = characterClass;
        CharacterClass.AssignCharacter(this);
        Ancestry = ancestry;

        Might = new(() => CombatMastery, might, false, () => Level);
        Agility = new(() => CombatMastery, agi, false, () => Level);
        Charisma = new(() => CombatMastery, cha, false, () => Level);
        Intelligence = new(() => CombatMastery, inte, false, () => Level);


        //HealthPoints = () => 6 + Level + Might;
        HealthPoints = () => 6 + Level + Might + CharacterClass.BonusHP();
    }

    public void LevelUp() {
        CharacterClass.LevelUp();
    }
}