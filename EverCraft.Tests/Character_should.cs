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
}