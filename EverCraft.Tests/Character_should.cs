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
}