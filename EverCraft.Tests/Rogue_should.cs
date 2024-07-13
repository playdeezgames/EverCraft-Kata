namespace EverCraft.Tests;
using Shouldly;

public class Rogue_should
{
    [Fact]
    public void not_be_good_alignment()
    {
        Should.Throw<ArgumentException>(() => { ICharacter attacker = new Character() { CharacterClass = CharacterClass.Rogue, Alignment = Alignment.Gud }; });
    }

    [Fact]
    public void not_be_good_alignment_flipped()
    {
        Should.Throw<ArgumentException>(() =>
        {
            ICharacter attacker = new Character()
            {
                Alignment = Alignment.Gud,
                CharacterClass = CharacterClass.Rogue
            };
        });
    }

    [Fact]
    public void may_not_be_changed_to_good_alignment()
    {
        ICharacter character = new Character() { CharacterClass = CharacterClass.Rogue };
        Should.Throw<ArgumentException>(() =>
        {
            character.Alignment = Alignment.Gud;
        });
    }

    [Theory]
    [InlineData(Alignment.Neutered)]
    [InlineData(Alignment.Evily)]
    public void may_be_not_good(Alignment alignment)
    {
        ICharacter character = new Character() { CharacterClass = CharacterClass.Rogue, Alignment = alignment };
        character.Alignment.ShouldBe(alignment);
    }

    [Theory]
    [InlineData(Alignment.Neutered)]
    [InlineData(Alignment.Evily)]
    public void may_be_not_good_flipped(Alignment alignment)
    {
        ICharacter character = new Character() { Alignment = alignment, CharacterClass = CharacterClass.Rogue };
        character.Alignment.ShouldBe(alignment);
    }

}