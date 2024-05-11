namespace EverCraft;

public static class Attack
{
    public static void PerformAttack(this ICharacter attacker, ICharacter defender, int roll)
    {
        if(defender.LegacyAttack(roll + (attacker.Level / 2)))
        {
            attacker.XP += 10;
        }
    }
}