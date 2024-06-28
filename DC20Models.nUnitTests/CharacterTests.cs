using Models;
using Models.Ancestries;
using Models.Classes;

namespace DC20Models.nUnitTests;
public class CharacterTests {
    [TestCase(1,1,typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(1, 2, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(3, 5, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(6, 12, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(9, 17, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(10, 20, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    public void CombatMastery_CalcTest(int expected, int level, Type baseClass, Type ancestry, int might, bool mSave, int agility, bool aSave, int charisma, bool cSave, int intelligence, bool iSave) {
        var characterClassInstance = Activator.CreateInstance(baseClass) as BaseClass;
        var ancestryInstance = Activator.CreateInstance(ancestry) as IAncestry;

        var character = new Character.Builder()
            .SetClass(characterClassInstance!)
            .SetAncestry(ancestryInstance!)
            .SetMight(mSave, might)
            .SetAgility(aSave, agility)
            .SetCharisma(cSave, charisma)
            .SetIntelligence(iSave, intelligence)
            .Build();

        character.LevelUpTo(level);

        Assert.That(character.CombatMastery, Is.EqualTo(expected));
    }

    [TestCase(3, 1, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    [TestCase(3, 1, typeof(Barbarian), typeof(Human), -2, true, 3, true, 1, false, 2, false)]
    [TestCase(3, 1, typeof(Barbarian), typeof(Human), 1, true, 2, true, -2, false, 3, false)]
    [TestCase(3, 1, typeof(Barbarian), typeof(Human), 3, true, 3, true, 0, false, -2, false)]
    public void PrimeAttribute(int expected, int level, Type baseClass, Type ancestry, int might, bool mSave, int agility, bool aSave, int charisma, bool cSave, int intelligence, bool iSave) {
        var characterClassInstance = Activator.CreateInstance(baseClass) as BaseClass;
        var ancestryInstance = Activator.CreateInstance(ancestry) as IAncestry;

        var character = new Character.Builder()
            .SetClass(characterClassInstance!)
            .SetAncestry(ancestryInstance!)
            .SetMight(mSave, might)
            .SetAgility(aSave, agility)
            .SetCharisma(cSave, charisma)
            .SetIntelligence(iSave, intelligence)
            .Build();

        character.LevelUpTo(level);

        Assert.That(character.Prime, Is.EqualTo(expected));
    }

    //[TestCase(11, 1, 3, 1, 2, -2, typeof(Commander), typeof(Human))]
    [TestCase(11, 1, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2,false)]
    [TestCase(13, 2, typeof(Barbarian), typeof(Human), 3, true, 1, true, 2, false, -2, false)]
    //[TestCase(10, 1, 3, 1, 2, -2, typeof(Bard), typeof(Human))]
    public void HPValue(int expected, int level, Type baseClass, Type ancestry, int might, bool mSave, int agility, bool aSave, int charisma, bool cSave, int intelligence, bool iSave) {
        var characterClassInstance = Activator.CreateInstance(baseClass) as BaseClass;
        var ancestryInstance = Activator.CreateInstance(ancestry) as IAncestry;

        var character = new Character.Builder()
            .SetClass(characterClassInstance!)
            .SetAncestry(ancestryInstance!)
            .SetMight(mSave, might)
            .SetAgility(aSave, agility)
            .SetCharisma(cSave, charisma)
            .SetIntelligence(iSave, intelligence)
            .Build();

        character.LevelUpTo(level);
        
        Assert.That(character.HealthPoints(), Is.EqualTo(expected));
    }
}