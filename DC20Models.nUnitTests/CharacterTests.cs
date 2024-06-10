using Models;

namespace DC20Models.nUnitTests; 
public class CharacterTests {
    private Character? _character = null!;
    [SetUp]
    public void Setup() {
        _character = new();
    }

    [TestCase(1,1)]
    [TestCase(1,2)]
    [TestCase(3,5)]
    [TestCase(6,12)]
    [TestCase(9,17)]
    [TestCase(10,20)]
    public void CombatMastery_CalcTest(int expected, int level) => Assert.That(new Character(level).CombatMastery, Is.EqualTo(expected));
    
}