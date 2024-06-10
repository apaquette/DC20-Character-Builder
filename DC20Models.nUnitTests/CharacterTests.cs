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
        _character = new(2);
        Assert.That(_character.CombatMastery, Is.EqualTo(1));
    }

    [Test]
    public void Character_LevelFiveCMCalculation() {
        _character = new(5);
        Assert.That(_character.CombatMastery, Is.EqualTo(3));
    }

    [Test]
    public void Character_LevelTwelveCMCalculation() {
        _character = new(12);
        Assert.That(_character.CombatMastery, Is.EqualTo(6));
    }
    [Test]
    public void Character_LevelSeventeenCMCalculation() {
        _character = new(17);
        Assert.That(_character.CombatMastery, Is.EqualTo(9));
    }
    [Test]
    public void Character_LevelTwentyCMCalculation() {
        _character = new(20);
        Assert.That(_character.CombatMastery, Is.EqualTo(10));
    }
}