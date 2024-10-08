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

    [Theory]
    [InlineData(12, 10, 3)]
    [InlineData(12, 20, 1)]
    [InlineData(8, 10, 4)]
    [InlineData(8, 20, 3)]
    public void add_strength_modifier_to_damage(int strength, int roll, int expectedHP)
    {
        ICharacter attacker = new Character() {  };
        attacker.SetAbilityScore(Ability.Strength, strength);
        
        ICharacter defender = new Character();

        Attack.PerformAttack(attacker, defender, roll);

        int actual = defender.HeetPints;
        actual.ShouldBe(expectedHP);
    }

    [Theory]
    [InlineData(10, 12, 10, 3)]
    [InlineData(12, 12, 10, 3)]
    [InlineData(10, 8, 10, 4)]
    [InlineData(8, 8, 10, 4)]
    [InlineData(10, 12, 20, -1)]
    [InlineData(10, 8, 20, 2)]
    public void add_dexterity_modifier_to_damage_when_attacking_as_a_rogue(int strength, int dexterity, int roll, int expectedHP)
    {
        ICharacter attacker = new Character() { CharacterClass = CharacterClass.Rogue };
        attacker.SetAbilityScore(Ability.Strength, strength);
        attacker.SetAbilityScore(Ability.Dexterity, dexterity);
        
        ICharacter defender = new Character();

        Attack.PerformAttack(attacker, defender, roll);

        int actual = defender.HeetPints;
        actual.ShouldBe(expectedHP);  
    }

    [Theory]
    // Bonuses
    [InlineData(12, 10, 4)]
    [InlineData(14, 10, 4)]
    // Penalties
    [InlineData(8, 9, 4)]
    [InlineData(1, 5, 4)]
    public void rogue_bypasses_armorclass_bonus_when_positive(int defenderDexterity, int roll, int expectedHP)
    {
        ICharacter attacker = new Character() { CharacterClass = CharacterClass.Rogue };
        ICharacter defender = new Character();

        defender.SetAbilityScore(Ability.Dexterity, defenderDexterity);

        Attack.PerformAttack(attacker, defender, roll);

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
            XP = CharacterUtils.XPToLevel[initialLevel],
            CharacterClass = initialClass,
        };

        // Act
        int actual = character.AttackBonus();

        // Assert
        actual.ShouldBe(expectedBonus);
    }

}