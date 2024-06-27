using Models.Classes.Prestige;
using Models.Classes;
using Models;

namespace DC20Models.nUnitTests; 
public static class UnitTestHelpers {
    public static Character LevelUpTo(Character character, int level) {
        for (int i = character.Level; i < level; ++i) {
            if (character.Level == 10) {
                character.CharacterClass.SelectPrestigeClass(new Martial());
            }
            character.LevelUp();
        }
        return character;
    }

    public static BaseCharacterClass LevelUpTo(BaseCharacterClass characterClass, int level) {
        for (int i = characterClass.Level; i < level; ++i) {
            if (characterClass.Level == 10) {
                characterClass.SelectPrestigeClass(new Martial());
            }
            characterClass.LevelUp();
        }

        return characterClass;
    }
}
