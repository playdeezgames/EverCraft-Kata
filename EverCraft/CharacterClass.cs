namespace EverCraft;

public enum CharacterClass
{
    Commoner,
    Fighter,
    Rogue,
}

public static class CharacterClassExtensions 
{
    public static int BaseHPModifierPerLevel(this CharacterClass characterClass) => characterClass switch 
    {
        CharacterClass.Fighter => 10,
        _ => 5,
    };

    public static int CriticalAttackDamageMultiplier(this CharacterClass characterClass) => characterClass switch
    {
        CharacterClass.Rogue => 3,
        _ => 2,
    };
}