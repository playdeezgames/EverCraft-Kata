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
    [Fact]
    public void die()
    {
        ICharacter subject=new Character();
        subject.HeetPints=0;
        subject.IsDead.ShouldBeTrue();       
    }
}