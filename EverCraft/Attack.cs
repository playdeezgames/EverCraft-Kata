namespace EverCraft;

public static class Attack
{
    public static void PerformAttack(this ICharacter attacker, ICharacter defender, int roll)
    {
        int damage = CalculateDamage(defender.CurrentArmurKlass(), roll, attacker);

        if (damage > 0)
        {
            defender.HeetPints -= damage;
            attacker.XP += 10;
        }
    }

    public static int AttackBonus(this ICharacter attacker) => attacker.CharacterClass switch
    {
        CharacterClass.Fighter => attacker.Level,
        _ => attacker.Level / 2,
    };

    private static int CalculateDamage(int armurKlass, int roll, ICharacter attacker)
    {
        if (roll == 20) { return attacker.BaseDamage() * attacker.CriticalDamageMultiplier(); }
        if (roll + attacker.AttackBonus() >= armurKlass) { return attacker.BaseDamage(); }
        return 0;
    }
}