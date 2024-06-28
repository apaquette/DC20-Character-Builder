using Models;
using Models.Ancestries;
using Models.Classes;

namespace DC20Models.nUnitTests;
public class CharacterTests {
    private IAncestry Human = new Human();


    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(3, 5)]
    [TestCase(6, 12)]
    [TestCase(9, 17)]
    [TestCase(10, 20)]
    public void CombatMastery_CalcTest(int expected, int level) {
        Character character = new(new Barbarian(), new Human(), 3, 1, 2, -2);
        character.LevelUpTo(level);
        Assert.That(character.CombatMastery, Is.EqualTo(expected));
    }

    //[TestCase(3, 1)]
    //[TestCase(3, 3)]
    //[TestCase(4, 5)]
    //[TestCase(4, 7)]
    //[TestCase(5, 10)]
    //[TestCase(5, 13)]
    //[TestCase(6, 15)]
    //[TestCase(6, 18)]
    //[TestCase(7, 20)]
    //public void AttributeLimit(int expected, int level) {
    //    Character character = UnitTestHelpers.LevelUpTo(new Character(new Commander(), new Human()), level);
    //    Assert.That(character.AttributeLimit, Is.EqualTo(expected));
    //}

    [TestCase(3, 1, 3, 1, 2, -2)]
    [TestCase(3, 1, -2, 3, 1, 2)]
    [TestCase(3, 1, 2, -2, 3, 1)]
    [TestCase(3, 1, 1, 2, -2, 3)]
    [TestCase(3, 1, 3, 3, 0, -2)]
    public void PrimeAttribute(int expected, int level, int might, int agi, int cha, int inte) {
        Character character = new Character(new Barbarian(), new Human(), might, agi, cha, inte);
        character.LevelUpTo(level);
        Assert.That(character.Prime, Is.EqualTo(expected));
    }

    //[TestCase(11, 1, 3, 1, 2, -2, typeof(Commander), typeof(Human))]
    [TestCase(11, 1, 3, 1, 2, -2, typeof(Barbarian), typeof(Human))]
    [TestCase(13, 2, 3, 1, 2, -2, typeof(Barbarian), typeof(Human))]
    //[TestCase(10, 1, 3, 1, 2, -2, typeof(Bard), typeof(Human))]
    public void HPValue(int expected, int level, int might, int agi, int cha, int inte, Type characterClass, Type ancestry) {
        var characterClassInstance = Activator.CreateInstance(characterClass) as BaseClass;
        var ancestryInstance = Activator.CreateInstance(ancestry) as IAncestry;
        Character character = new Character(characterClassInstance!, ancestryInstance!, might, agi, cha, inte);

        character.LevelUpTo(level);
        
        Assert.That(character.HealthPoints(), Is.EqualTo(expected));
    }
}