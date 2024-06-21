using Models;

namespace DC20Models.nUnitTests; 
public class AttributeTests {
    private Attribute? _attribute = null;
    private Character? _character = new Character();

    [TestCase(1, false, 1)]
    public void Attribute_ValueTest(int expected, bool save, int value) {
        Attribute attribute = new(() => _character.CombatMastery, value, save);
        Assert.That(attribute.Value, Is.EqualTo(expected));
    }
}
