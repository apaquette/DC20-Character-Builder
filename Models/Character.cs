namespace Models; 
public class Character {
    public string? PlayerName { get; set; }
    public string? Name { get; set; }
    public int Level { get; private set; }
    public int CombatMastery => (int)Math.Ceiling((double)Level / 2);

    public Character(int level = 1, string? playerName = null, string? name = null) {
        PlayerName = playerName;
        Name = name;
        Level = level;
    }
}