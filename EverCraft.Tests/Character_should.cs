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
}