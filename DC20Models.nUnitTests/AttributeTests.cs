﻿using Models;
using Models.Ancestries;
using Models.Classes;
using Attribute = Models.Attribute;

namespace DC20Models.nUnitTests; 
public class AttributeTests {
    [TestCase(1, false, 1, 1)]
    [TestCase(-2, false, -2, 1)]
    [TestCase(3, false, 3, 1)]
    [TestCase(4, false, 4, 5)]
    [TestCase(7, false, 7, 20)]
    public void Attribute_ValueTest(int expected, bool isSave, int value, int level) {
        Character thecharacter = LevelUpTo(new(new Commander(), new Human()), level);
        Attribute attribute = new(() => thecharacter.CombatMastery, value, isSave, () => thecharacter.AttributeLimit);

        Assert.That((int)attribute, Is.EqualTo(expected));
    }

    [TestCase(false, -3, 1)]
    [TestCase(false, 4, 1)]
    [TestCase(false, 5, 5)]
    [TestCase(false, 10, 20)]
    public void Attribute_ValueTest_Invalid(bool isSave, int value, int level) {
        Assert.Throws<InvalidAttributeException>(() => {
            Character thecharacter = LevelUpTo(new(new Commander(), new Human()), level);
            Attribute attribute = new(() => thecharacter.CombatMastery, value, isSave, () => thecharacter.AttributeLimit);
        });
    }

    [TestCase(1, false, 1, 1)]
    [TestCase(2, true, 1, 1)]
    [TestCase(3, true, 1, 4)]
    public void Attribute_SaveTest(int expected, bool isSave, int value, int level) {
        Character thecharacter = LevelUpTo(new(new Commander(), new Human()), level);
        Attribute attribute = new(() => thecharacter.CombatMastery, value, isSave, () => thecharacter.AttributeLimit);

        Assert.That(attribute.Save, Is.EqualTo(expected));
    }

    private Character LevelUpTo(Character character, int level) {
        for (int i = character.Level; i < level; ++i) {
            character.LevelUp();
        }
        return character;
    }
}
