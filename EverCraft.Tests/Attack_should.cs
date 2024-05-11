namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{

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

}