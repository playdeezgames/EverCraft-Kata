namespace EverCraft.Tests;
using Shouldly;

public class Character_should
{
    [Fact]
    public void have_a_name()
    {
        const string CharacterName="yermom";
        ICharacter subject=new Character();
        subject.Name.ShouldBe(CharacterName);
    }
    [Fact]
    public void change_a_name()
    {
        const string CharacterName="nachomama";
        ICharacter subject=new Character();
        subject.Name=CharacterName;
        subject.Name.ShouldBe(CharacterName);
    }
    [Fact]
    public void have_an_alignment()
    {
        const Alignment expectedAlignment = Alignment.Gud;
        ICharacter subject =new Character();
        subject.Alignment.ShouldBe(expectedAlignment);
    }
    [Fact]
    public void set_an_alignment()
    {
        const Alignment expectedAlignment = Alignment.Evily;
        ICharacter subject =new Character();
        subject.Alignment = expectedAlignment;
        subject.Alignment.ShouldBe(expectedAlignment);
    }
    [Fact]
    public void have_armour_class()
    {
        ICharacter subject=new Character();
        subject.ArmurKlass.ShouldBe(10);
    }
    [Fact]
    public void set_armour_class()
    {
        ICharacter subject=new Character();
        subject.ArmurKlass=11;
        subject.ArmurKlass.ShouldBe(11);
    }
    [Fact]
    public void have_heet_points()
    {
        ICharacter subject=new Character();
        subject.HeetPints.ShouldBe(5);
    }
    [Fact]
    public void set_heet_points()
    {
        ICharacter subject=new Character();
        subject.HeetPints=6;
        subject.HeetPints.ShouldBe(6);
    }
    [Theory]
    [InlineData(10,20,true)]
    [InlineData(21,20,true)]
    [InlineData(10,10,true)]
    [InlineData(10,9,false)]
    public void get_so_attacked(int ac, int roll, bool expectedResult)
    {
        ICharacter subject=new Character();
        subject.ArmurKlass=ac;
        subject.Attack(roll).ShouldBe(expectedResult);
    }
    [Theory]
    [InlineData(10,4)]
    [InlineData(20,3)]
    public void take_damage(int roll, int expectedHP)
    {
        ICharacter subject = new Character();
        subject.Attack(roll);
        subject.HeetPints.ShouldBe(expectedHP);
    }
    [Theory]
    [InlineData(0,true)]
    [InlineData(-1,true)]
    [InlineData(5,false)]
    public void die(int hp, bool demised)
    {
        ICharacter subject=new Character();
        subject.HeetPints=hp;
        subject.IsDead.ShouldBe(demised);       
    }
    [Theory]
    [InlineData(Ability.Strength)]
    [InlineData(Ability.Dexterity)]
    [InlineData(Ability.Constitution)]
    [InlineData(Ability.Wisdom)]
    [InlineData(Ability.Intelligence)]
    [InlineData(Ability.Charisma)]
    [InlineData(Ability.Comelyness)]
    public void have_default_ability_scores(Ability ability)
    {
        const int expected = 10;
        ICharacter subject=new Character();
        var actual = subject.GetAbilityScore(ability);
        actual.ShouldBe(expected);
    }
    [Theory]
    [InlineData(Ability.Strength)]
    [InlineData(Ability.Dexterity)]
    [InlineData(Ability.Constitution)]
    [InlineData(Ability.Wisdom)]
    [InlineData(Ability.Intelligence)]
    [InlineData(Ability.Charisma)]
    [InlineData(Ability.Comelyness)]
    public void have_default_ability_score_modifiers(Ability ability)
    {
        const int expected = 0;
        ICharacter subject=new Character();
        var actual = subject.GetAbilityScoreModifier(ability);
        actual.ShouldBe(expected);
    }
    [Theory]
    [InlineData(Ability.Strength,12,1)]
    [InlineData(Ability.Dexterity,11,0)]
    [InlineData(Ability.Constitution,13,1)]
    [InlineData(Ability.Wisdom,14,2)]
    [InlineData(Ability.Intelligence,15,2)]
    [InlineData(Ability.Charisma,16,3)]
    [InlineData(Ability.Comelyness,17,3)]
    public void set_ability_scores(Ability ability, int score, int expectedModifier)
    {
        ICharacter subject=new Character();
        subject.SetAbilityScore(ability, score);
        var actual = subject.GetAbilityScore(ability);
        actual.ShouldBe(score);
        subject.GetAbilityScoreModifier(ability).ShouldBe(expectedModifier);
    }
    [Fact]
    public void modify_ac_according_to_dex()
    {
        var dexterity = 12;
        const int defaultAC = 10;
        const int acBonusForDex=1;
        const int expectedAC=defaultAC+acBonusForDex;
        ICharacter subject=new Character();
        subject.SetAbilityScore(Ability.Dexterity, dexterity);
        var actual = subject.ArmurKlass;
        actual.ShouldBe(expectedAC);
    }
}