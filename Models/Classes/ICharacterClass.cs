namespace Models.Classes;
public interface ICharacterClass {
    string Name { get; }
    int Level { get; }
    int BonusHP { get; }

    void LevelUp();
}
