using Models;
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
        var CombatMastery = (int)Math.Ceiling((double)level / 2);

        Attribute attribute = new(() => CombatMastery, value, isSave, () => level);

        Assert.That((int)attribute, Is.EqualTo(expected));
    }

    [TestCase(false, -3, 1)]
    [TestCase(false, 4, 1)]
    [TestCase(false, 5, 5)]
    [TestCase(false, 10, 20)]
    public void Attribute_ValueTest_Invalid(bool isSave, int value, int level) {
        Assert.Throws<InvalidAttributeException>(() => {

            var CombatMastery = (int)Math.Ceiling((double)level / 2);

            Attribute attribute = new(() => CombatMastery, value, isSave, () => level);
        });
    }

    [TestCase(1, false, 1, 1)]
    [TestCase(2, true, 1, 1)]
    [TestCase(3, true, 1, 4)]
    public void Attribute_SaveTest(int expected, bool isSave, int value, int level) {
        var CombatMastery = (int)Math.Ceiling((double)level / 2);

        Attribute attribute = new(() => CombatMastery, value, isSave, () => level);

        Assert.That(attribute.Save, Is.EqualTo(expected));
    }
}
