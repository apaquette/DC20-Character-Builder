namespace Models.Classes;
public interface IClass {
    string Name { get; }
    int Level { get; }
    Func<int> BonusHP { get; }
    Func<int> AttributePoints { get; }
    Func<int> SkillPoints { get; }

    //Combat Masteries
    //Features

    void LevelUp();
}
