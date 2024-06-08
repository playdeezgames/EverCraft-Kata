namespace EverCraft;

public enum CharacterClass
{
    Commoner,
    Fighter,
    Rogue,
}

public static class CharacterExtensions
{
    public static int CriticalDamageMultiplier(this ICharacter character) => character.CharacterClass.CriticalDamageMultiplier();
}

public static class CharacterClassExtensions 
{
    public static int BaseHPModifierPerLevel(this CharacterClass characterClass) => characterClass switch 
    {
        CharacterClass.Fighter => 10,
        _ => 5,
    };

    internal static int CriticalDamageMultiplier(this CharacterClass characterClass) => characterClass switch
    {
        CharacterClass.Rogue => 3,
        _ => 2,
    };
}