namespace Models.Classes;
public interface ISpellcaster {
    Func<int> ManaPoints { get; }
    Func<int> CantripsKnown { get; }
    Func<int> SpellsKnown { get; }
}
