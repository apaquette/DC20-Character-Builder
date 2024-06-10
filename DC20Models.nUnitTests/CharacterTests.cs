using Models;

namespace DC20Models.nUnitTests; 
public class CharacterTests {
    private Character? _character = null!;
    [SetUp]
    public void Setup() {
        _character = new();
    }

    [Test]
    public void Character_LevelOneCMCalculation() {
        Assert.Equals(1, _character.CombatMastery);
    }
}