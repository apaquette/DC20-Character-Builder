namespace Models.Classes;
public class Bard : ICharacterClass {

    public int Level {  get; private set; }
    public string Name => "Bard";

    public int BonusHP => 0;

    public Bard() {
        Level = 1;
    }

    public void LevelUp() => ++Level;
}
