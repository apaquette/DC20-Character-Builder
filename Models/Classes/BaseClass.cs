namespace Models.Classes;
public abstract class BaseClass : IClass {
    private int _level;

    protected BaseClass() {
        _level = 1;
    }

    public abstract string Name { get; }
    public int Level => _level;

    public abstract Func<int> BonusHP { get; }

    public abstract Func<int> AttributePoints { get; }

    public abstract Func<int> SkillPoints { get; }

    private Character? Character { get; set; }

    public void LevelUp() {
        ++_level;
    }
    public void AssignCharacter(Character character) {
        Character = character;
    }
}
