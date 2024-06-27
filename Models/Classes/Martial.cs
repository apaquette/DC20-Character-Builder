
namespace Models.Classes;
public class Martial : BasePrestigeClass {
    public Martial() {
        BonusHPCalculation = (int Level) => 1;
    }

    public override Func<int, int> BonusHPCalculation { get; set; }
}
