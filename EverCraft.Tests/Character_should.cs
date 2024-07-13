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
        subject.ArmorClassWithModfier().ShouldBe(10);
    }
    [Fact]
    public void set_armour_class()
    {
        ICharacter subject=new Character();
        subject.BaseArmurKlass=11;
        subject.ArmorClassWithModfier().ShouldBe(11);
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
        var actual = subject.ArmorClassWithModfier();
        actual.ShouldBe(expectedAC);
    }

    // - add Constitution modifier to hit points (always at least 1 hit point)
    [Theory]
    [InlineData(1, 1)]
    [InlineData(6, 3)]
    [InlineData(8, 4)]
    [InlineData(10, 5)]
    [InlineData(12, 6)]
    [InlineData(14, 7)]
    [InlineData(16, 8)]
    [InlineData(18, 9)]
    public void add_constitution_modifier_to_hit_points(int constitution, int expectedHP)
    {
        ICharacter subject = new Character();

        subject.SetAbilityScore(Ability.Constitution, constitution);

        var actual = subject.HeetPints;
        actual.ShouldBe(expectedHP);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    [InlineData(12)]
    [InlineData(14)]
    [InlineData(16)]
    [InlineData(18)]
    public void change_constitution_modifier_to_hit_points(int constitution)
    {
        ICharacter subject = new Character();

        subject.SetAbilityScore(Ability.Constitution, constitution);
        subject.SetAbilityScore(Ability.Constitution, 10);

        var actual = subject.HeetPints;
        actual.ShouldBe(5);
    }

    [Fact]
    public void have_xp()
    {
        ICharacter subject = new Character();

        var actual = subject.XP;
        actual.ShouldBe(0);
    }

    [Fact]
    public void have_level()
    {
        ICharacter subject = new Character();

        var actual = subject.Level;
        actual.ShouldBe(1);
    }

    [Theory]
    [InlineData(500, 1)]
    [InlineData(1000, 2)]
    [InlineData(3000, 3)]
    public void gain_level_based_on_xp(int xp, int expectedLevel)
    {
        ICharacter subject = new Character();
        subject.XP = xp;

        var actual = subject.Level;
        actual.ShouldBe(expectedLevel);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(1000, 10)]
    [InlineData(2000, 10)]
    [InlineData(3000, 15)]
    [InlineData(6000, 20)]
    public void increase_hp_based_on_xp(int xp, int expectedHP)
    {
        ICharacter subject = new Character();
        subject.XP = xp;
        var actual = subject.HeetPints;

        actual.ShouldBe(expectedHP);
    }

    [Theory]
    [InlineData(0, 12, 6)]
    [InlineData(1000, 12, 12)]
    [InlineData(1000, 1, 2)]
    public void increase_hp_based_on_xp_and_constitution(int xp, int constitution, int expectedHP)
    {
        ICharacter subject = new Character();
        subject.XP = xp;
        subject.SetAbilityScore(Ability.Constitution, constitution);
        var actual = subject.HeetPints;

        actual.ShouldBe(expectedHP);
    }

    [Theory]
    [InlineData(CharacterClass.Commoner)]
    [InlineData(CharacterClass.Fighter)]
    [InlineData(CharacterClass.Rogue)]
    public void have_a_character_class(CharacterClass expectedClass)
    {
        ICharacter subject = new Character() { CharacterClass = expectedClass };

        subject.CharacterClass.ShouldBe(expectedClass);
    }

    [Theory]
    [InlineData(1, 10)]
    [InlineData(2, 20)]
    [InlineData(3, 30)]
    public void have_10_hp_per_level_when_fighter(int level, int expectedHP)
    {
        ICharacter subject = new Character() { CharacterClass = CharacterClass.Fighter, XP = CharacterUtils.XPToLevel[level] };

        subject.HeetPints.ShouldBe(expectedHP);
    }
}