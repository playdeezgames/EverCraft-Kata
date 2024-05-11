namespace EverCraft;

public static class Attack
{
    public static void PerformAttack(this ICharacter attacker, ICharacter defender, int roll)
    {
        bool success = false;
        if (roll == 20)
        {
            defender.HeetPints -= 2;
            success = true;
        }
        else if (roll + attacker.Level / 2 >= defender.CurrentArmurKlass)
        {
            defender.HeetPints--;
            success = true;
        }

        if (success)
        {
            attacker.XP += 10;
        }
    }
}