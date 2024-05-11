namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{

    [Fact]
    public void reward_attacker_on_successful_attack()
    {
        // Arrange
        ICharacter attacker = new Character();
        ICharacter defender = new Character();

        const int roll = 10;
        //Act
        Attack.PerformAttack(attacker, defender, roll);

        //Assert
        int actual = attacker.XP;
        actual.ShouldBe(10);
    }
}