using Models;
using Models.Classes;
using Models.Ancestries;

namespace DC20Models.nUnitTests;
public class CharacterTests {
    private ICharacterClass Commander = new Commander();
    private IAncestry Human = new Human();


    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(3, 5)]
    [TestCase(6, 12)]
    [TestCase(9, 17)]
    [TestCase(10, 20)]
    public void CombatMastery_CalcTest(int expected, int level) {
        Character character = LevelUpTo(new(Commander, new Human()), level);
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
        Character character = LevelUpTo(new(Commander, new Human()), level);
        Assert.That(character.AttributeLimit, Is.EqualTo(expected));
    }

    [TestCase(3, 1, 3, 1, 2, -2)]
    [TestCase(3, 1, -2, 3, 1, 2)]
    [TestCase(3, 1, 2, -2, 3, 1)]
    [TestCase(3, 1, 1, 2, -2, 3)]
    [TestCase(3, 1, 3, 3, 0, -2)]
    public void PrimeAttribute(int expected, int level, int might, int agi, int cha, int inte) {
        Character character = LevelUpTo(new(null, null, might, agi, cha, inte), level);
        Assert.That(character.Prime, Is.EqualTo(expected));
    }

    [TestCase(11, 1, 3, 1, 2, -2, typeof(Commander), typeof(Human))]
    [TestCase(11, 1, 3, 1, 2, -2, typeof(Barbarian), typeof(Human))]
    [TestCase(10, 1, 3, 1, 2, -2, typeof(Bard), typeof(Human))]
    public void HPValue(int expected, int level, int might, int agi, int cha, int inte, Type characterClass, Type ancestry) {
        var characterClassInstance = Activator.CreateInstance(characterClass) as ICharacterClass;
        var ancestryInstance = Activator.CreateInstance(ancestry) as IAncestry;
        Character character = LevelUpTo(new(characterClassInstance!, ancestryInstance!, might, agi, cha, inte, null, null), level);
        Assert.That(character.HealthPoints, Is.EqualTo(expected));
    }

    private Character LevelUpTo(Character character, int level) {
        for(int i = character.Level; i < level; ++i) {
            character.LevelUp(); 
        }
        return character;
    }
}