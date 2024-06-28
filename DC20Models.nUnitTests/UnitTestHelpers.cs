using Models;
using Models.Classes;

namespace DC20Models.nUnitTests;
public static class UnitTestHelpers {
    public static void LevelUpTo(this Character character, int level) {
        for (int i = character.Level; i < level; ++i) {
            //if (character.Level == 10) {
            //    character.CharacterClass.SelectPrestigeClass(new Martial());
            //}
            character.LevelUp();
        }
    }

    public static void LevelUpTo(this BaseClass characterClass, int level) {
        for (int i = characterClass.Level; i < level; ++i) {
            //if (characterClass.Level == 10) {
            //    characterClass.SelectPrestigeClass(new Martial());
            //}
            characterClass.LevelUp();
        }
    }
}
