namespace Models.Classes;
public interface ICharacterClass {
    string Name { get; }
    int BonusHP { get; }
    int Level { get; }

    void LevelUp();
}
