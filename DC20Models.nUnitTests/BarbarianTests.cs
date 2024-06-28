using Models.Classes;

namespace DC20Models.nUnitTests;
public class BarbarianTests {
    [TestCase(1,1)]
    [TestCase(2,2)]
    [TestCase(3,3)]
    [TestCase(4,4)]
    [TestCase(5,5)]
    [TestCase(6,6)]
    [TestCase(7,7)]
    [TestCase(8,8)]
    [TestCase(9,9)]
    [TestCase(10,10)]
    public void BonusHealthPoints(int expected, int Level) {
        Barbarian barbarian = new Barbarian();
        barbarian.LevelUpTo(Level);

        Assert.That(barbarian.BonusHP(), Is.EqualTo(expected));
    }
}