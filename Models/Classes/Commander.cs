namespace Models.Classes;
public class Commander : ICharacterClass {

    public string Name => "Commander";

    public int BonusHP => 1;

    public int Level { get; private set; }

    public Commander() {
        Level = 1;
    }
    public void LevelUp() => ++Level;
}