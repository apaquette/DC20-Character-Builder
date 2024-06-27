namespace Models.Classes;
public class Barbarian : ICharacterClass {

    public string Name => "Barbarian";

    public int BonusHP => 1;

    public int Level { get; private set; }
    public Barbarian() {
        Level = 1;
    }

    public void LevelUp() => ++Level;
}
