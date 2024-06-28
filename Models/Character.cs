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
    public Attribute Might { get; private set; }
    public Attribute Agility { get; }
    public Attribute Charisma { get; }
    public Attribute Intelligence { get; }

    private Character(BaseClass characterClass, IAncestry ancestry, int might, bool mightIsSaveProf, int agi, bool agiIsSaveProf, int cha, bool chaIsSaveProf, int inte, bool inteIsSaveProf, string? player = null, string? name = null) {
        Player = player;
        Name = name;

        CharacterClass = characterClass;
        CharacterClass.AssignCharacter(this);
        Ancestry = ancestry;

        Might = new(() => CombatMastery, might, mightIsSaveProf, () => Level);
        Agility = new(() => CombatMastery, agi, agiIsSaveProf, () => Level);
        Charisma = new(() => CombatMastery, cha, chaIsSaveProf, () => Level);
        Intelligence = new(() => CombatMastery, inte, inteIsSaveProf, () => Level);

        HealthPoints = () => 6 + Level + Might + CharacterClass.BonusHP();
    }

    public void LevelUp() {
        CharacterClass.LevelUp();
    }


    public class CharacterBuilder {
        private string? _playerName;
        private string? _name;

        private BaseClass _characterClass;
        private IAncestry _ancestry;

        private bool _mightProficient;
        private int _mightValue;
        private bool _agilityProficient;
        private int _agilityValue;
        private bool _charismaProficient;
        private int _charismaValue;
        private bool _intelligenceProficient;
        private int _intelligenceValue;

        public CharacterBuilder SetPlayerName(string name) {
            _playerName = name;
            return this;
        }
        public CharacterBuilder SetCharacterName(string name) {
            _name = name;
            return this;
        }
        public CharacterBuilder SetClass(BaseClass characterClass) {
            _characterClass = characterClass;
            return this;
        }
        public CharacterBuilder SetAncestry(IAncestry ancestry) {
            _ancestry = ancestry;
            return this;
        }
        public CharacterBuilder SetMight(bool proficient, int value) {
            _mightProficient = proficient;
            _mightValue = value;
            return this;
        }
        public CharacterBuilder SetAgility(bool proficient, int value) {
            _agilityProficient = proficient;
            _agilityValue = value;
            return this;
        }
        public CharacterBuilder SetCharisma(bool proficient, int value) {
            _charismaProficient = proficient;
            _charismaValue = value;
            return this;
        }
        public CharacterBuilder SetIntelligence(bool proficient, int value) {
            _intelligenceProficient = proficient;
            _intelligenceValue = value;
            return this;
        }

        public Character Build() {
            return new Character(  
                _characterClass, _ancestry,
                _mightValue ,_mightProficient,
                _agilityValue, _agilityProficient,
                _charismaValue, _charismaProficient,
                _intelligenceValue, _intelligenceProficient,
                _playerName, _name
            );
        }
    }

}