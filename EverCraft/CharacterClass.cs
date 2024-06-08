namespace EverCraft;

public enum CharacterClass
{
    Commoner,
    Fighter,
    Rogue,
}

public static class CharacterClassExtensions 
{
    public static int CriticalDamageMultiplier(this ICharacter character) => character.CharacterClass.CriticalDamageMultiplier();
    public static int BaseHPModifierPerLevel(this CharacterClass characterClass) => characterClass switch 
    {
        CharacterClass.Fighter => 10,
        _ => 5,
    };

    private static int CriticalDamageMultiplier(this CharacterClass characterClass) => characterClass switch
    {
        CharacterClass.Rogue => 3,
        _ => 2,
    };
}