namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{

    [Theory]
    [InlineData(10, 10)]
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