using Models;

namespace DC20Models.nUnitTests; 
public class CharacterTests {
    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(3, 5)]
    [TestCase(6, 12)]
    [TestCase(9, 17)]
    [TestCase(10, 20)]
    public void CombatMastery_CalcTest(int expected, int level) {
        Character character = LevelUpTo(new(), level);
        Assert.That(character.CombatMastery, Is.EqualTo(expected));
    }

    [TestCase(3, 1)]
    [TestCase(3, 3)]
    [TestCase(4, 5)]
    [TestCase(4, 7)]
    [TestCase(5, 10)]
    [TestCase(5, 13)]
    [TestCase(6, 15)]
    [TestCase(6, 18)]
    [TestCase(7, 20)]
    public void AttributeLimit(int expected, int level) {
        Character character = LevelUpTo(new(), level);
        Assert.That(character.AttributeLimit, Is.EqualTo(expected));
    }

    [TestCase(3, 1, 3, 2, 2, 2)]
    public void PrimeAttribute(int expected, int level, int might, int agi, int cha, int inte) {
        Character character = LevelUpTo(new(null, null, might, agi, cha, inte), level);
        Assert.That(character.Prime, Is.EqualTo(expected));
    }

    private Character LevelUpTo(Character character, int level) {
        for(int i = character.Level; i < level; ++i) {
            character.LevelUp(); 
        }
        return character;
    }
    
}