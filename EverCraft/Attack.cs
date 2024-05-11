namespace EverCraft;

public class Attack
{
    public static void PerformAttack(ICharacter attacker, ICharacter defender, int roll)
    {
        if(defender.LegacyAttack(roll))
        {
            attacker.XP += 10;
        }
    }
}