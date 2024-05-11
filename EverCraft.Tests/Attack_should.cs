namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{
    public int[] XPToLevel = {0, 0, 1000, 3000, 6000};

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

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    public void have_bonus_based_on_attacker_level(int initialLevel, int expectedBonus)
    {
        // Arrange
        ICharacter character = new Character() { XP = XPToLevel[initialLevel] };

        // Act
        int actual = character.AttackBonus();

        // Assert
        actual.ShouldBe(expectedBonus);
    }

}