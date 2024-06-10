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
        _character = new();
        Assert.That(_character.CombatMastery, Is.EqualTo(1));
    }

    [Test]
    public void Character_LevelTwoCMCalculation() {
        _character = new Character(2);
        Assert.That(_character.CombatMastery, Is.EqualTo(1));
    }

    [Test]
    public void Character_LevelFiveCMCalculation() {
        _character = new Character(5);
        Assert.That(_character.CombatMastery, Is.EqualTo(3));
    }
}