using Models;
using Models.Ancestries;
using Models.Classes;
using Attribute = Models.Attribute;

namespace DC20Models.nUnitTests; 
//TODO: rework attribute unit tests
public class AttributeTests {
    [TestCase(1, false, 1, 1)]
    [TestCase(-2, false, -2, 1)]
    [TestCase(3, false, 3, 1)]
    [TestCase(4, false, 4, 5)]
    [TestCase(7, false, 7, 20)]
    public void Attribute_ValueTest(int expected, bool isSave, int value, int level) {
        var character = new Character.Builder()
            .SetClass(new Barbarian())
            .SetAncestry(new Human())
            .SetMight(true, 3)
            .SetAgility(true, 1)
            .SetCharisma(false, 2)
            .SetIntelligence(false, -2)
            .Build();
        
        character.LevelUpTo(level);

        Attribute attribute = new(() => character.CombatMastery, value, isSave, () => character.Level);

        Assert.That((int)attribute, Is.EqualTo(expected));
    }

    [TestCase(false, -3, 1)]
    [TestCase(false, 4, 1)]
    [TestCase(false, 5, 5)]
    [TestCase(false, 10, 20)]
    public void Attribute_ValueTest_Invalid(bool isSave, int value, int level) {
        Assert.Throws<InvalidAttributeException>(() => {
            var character = new Character.Builder()
            .SetClass(new Barbarian())
            .SetAncestry(new Human())
            .SetMight(true, 3)
            .SetAgility(true, 1)
            .SetCharisma(false, 2)
            .SetIntelligence(false, -2)
            .Build();

            character.LevelUpTo(level);

            Attribute attribute = new(() => character.CombatMastery, value, isSave, () => character.Level);
        });
    }

    [TestCase(1, false, 1, 1)]
    [TestCase(2, true, 1, 1)]
    [TestCase(3, true, 1, 4)]
    public void Attribute_SaveTest(int expected, bool isSave, int value, int level) {

        var character = new Character.Builder()
            .SetClass(new Barbarian())
            .SetAncestry(new Human())
            .SetMight(true, value)
            .SetAgility(true, 1)
            .SetCharisma(false, 2)
            .SetIntelligence(false, -2)
            .Build();

        character.LevelUpTo(level);
        Attribute attribute = new(() => character.CombatMastery, value, isSave, () => character.Level);

        Assert.That(attribute.Save, Is.EqualTo(expected));
    }
}
