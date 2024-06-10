using Models;

namespace DC20Models.nUnitTests; 
public class CharacterTests {
    private Character? _character = null!;
    private static IEnumerable<TestCaseData> CMCalc {
        get 
        {
            yield return new TestCaseData(1).Returns(1).SetName("WhenCharacterLevel1_ThenReturnsCombatMastery");
            yield return new TestCaseData(2).Returns(1).SetName("WhenCharacterLevel2_ThenReturnsCombatMastery");
            yield return new TestCaseData(5).Returns(3).SetName("WhenCharacterLevel5_ThenReturnsCombatMastery");
            yield return new TestCaseData(12).Returns(6).SetName("WhenCharacterLevel12_ThenReturnsCombatMastery");
            yield return new TestCaseData(17).Returns(9).SetName("WhenCharacterLevel17_ThenReturnsCombatMastery");
            yield return new TestCaseData(20).Returns(10).SetName("WhenCharacterLevel20_ThenReturnsCombatMastery");
        }
    }
    [SetUp]
    public void Setup() {
        _character = new();
    }

    [Test, TestCaseSource(nameof(CMCalc))]
    public int CMCalcTest(int level) => new Character(level).CombatMastery;
    
}