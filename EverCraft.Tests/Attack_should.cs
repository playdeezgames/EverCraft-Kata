namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{
    public static readonly int[] XPToLevel = {0, 0, 1000, 3000, 6000};

    [Theory]
    [InlineData(1, 0)]
    [InlineData(9, 0)]
    [InlineData(10, 10)]
    [InlineData(11, 10)]
    public void reward_attacker_on_successful_attack(int roll, int expectedXP)
    {
        // Arrange
        ICharacter attacker = new Character();
        ICharacter defender = new Character();

        //Act
        Attack.PerformAttack(attacker, defender, roll);

        //Assert
        int actual = attacker.XP;
        actual.ShouldBe(expectedXP);
    }

    [Theory]
    [InlineData(0, 10, 4)]
    [InlineData(1000, 9, 4)]
    [InlineData(1000, 19, 4)]
    [InlineData(0, 20, 3)]
    [InlineData(1000, 20, 3)]
    public void damage_defender_on_successful_attack(int initialXP, int roll, int expectedHP)
    {
        // Arrange
        ICharacter attacker = new Character() { XP = initialXP };
        ICharacter defender = new Character();

        //Act
        Attack.PerformAttack(attacker, defender, roll);

        //Assert
        int actual = defender.HeetPints;
        actual.ShouldBe(expectedHP);
    }

    [Fact]
    public void deal_triple_damage_critical_when_rogue()
    {
        ICharacter attacker = new Character() { CharacterClass = CharacterClass.Rogue };
        ICharacter defender = new Character();

        Attack.PerformAttack(attacker, defender, 20);

        defender.HeetPints.ShouldBe(2);
    }

    [Theory]
    [InlineData(CharacterClass.Commoner, 1, 0)]
    [InlineData(CharacterClass.Commoner, 2, 1)]
    [InlineData(CharacterClass.Commoner, 3, 1)]
    [InlineData(CharacterClass.Commoner, 4, 2)]
    [InlineData(CharacterClass.Fighter, 1, 1)]
    [InlineData(CharacterClass.Fighter, 2, 2)]
    [InlineData(CharacterClass.Fighter, 3, 3)]
    [InlineData(CharacterClass.Fighter, 4, 4)]
    public void have_bonus_based_on_attacker_level(CharacterClass initialClass, int initialLevel, int expectedBonus)
    {
        // Arrange
        ICharacter character = new Character() 
        { 
            XP = XPToLevel[initialLevel],
            CharacterClass = initialClass,
        };

        // Act
        int actual = character.AttackBonus();

        // Assert
        actual.ShouldBe(expectedBonus);
    }

}