namespace Models.Classes;
public interface IMartial {
    Func<int> StaminaPoints { get; }
    Func<int> ManeuversKnown { get; }
    Func<int> TechniquesKnown { get; }
}
