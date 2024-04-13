namespace EverCraft.Tests;
using Shouldly;

public class Attack_should
{

    [Fact]
    public void reward_attacker_on_successful_attack()
    {
        // Arrange
        IAttack subject;
        ICharacter attacker = new Character();
        ICharacter defender = new Character();
        subject = new Attack(attacker, defender);

        const int roll = 10;
        //Act
        subject.PerformAttack(roll);

        //Assert
        int actual = subject.Attacker.XP;
        actual.ShouldBe(10);
    }
}