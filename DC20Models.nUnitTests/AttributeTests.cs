using Models;

namespace DC20Models.nUnitTests; 
public class AttributeTests {
    [TestCase(1, false, 1, 1)]
    [TestCase(-2, false, -2, 1)]
    [TestCase(3, false, 3, 1)]
    public void Attribute_ValueTest(int expected, bool save, int value, int level) {
        Character thecharacter = LevelUpTo(new(), level);
        Attribute attribute = new(() => thecharacter.CombatMastery, value, save, () => thecharacter.AttributeLimit);

        Assert.That((int)attribute, Is.EqualTo(expected));
    }

    [TestCase(false, -3, 1)]
    [TestCase(false, 4, 1)]
    public void Attribute_ValueTest_Invalid(bool save, int value, int level) {
        Assert.Throws<InvalidAttributeException>(() => {
            Character thecharacter = LevelUpTo(new(), level);
            Attribute attribute = new(() => thecharacter.CombatMastery, value, save, () => thecharacter.AttributeLimit);
        });
    }

    [TestCase(1, false, 1, 1)]
    [TestCase(2, true, 1, 1)]
    [TestCase(3, true, 1, 4)]
    public void Attribute_SaveTest(int expected, bool save, int value, int level) {
        Character thecharacter = LevelUpTo(new(), level);
        Attribute attribute = new(() => thecharacter.CombatMastery, value, save, () => thecharacter.AttributeLimit);

        Assert.That(attribute.Save, Is.EqualTo(expected));
    }

    private Character LevelUpTo(Character character, int level) {
        for (int i = character.Level; i < level; ++i) {
            character.LevelUp();
        }
        return character;
    }
}
