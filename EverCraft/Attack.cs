namespace EverCraft;

public static class Attack
{
    public static void PerformAttack(this ICharacter attacker, ICharacter defender, int roll)
    {
        int damage = CalculateDamage(defender.CurrentArmurKlass, roll, attacker.AttackBonus(), attacker.CharacterClass is CharacterClass.Rogue ? 3 : 2);

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

    private static int CalculateDamage(int armurKlass, int roll, int bonus, int damageMultiplier = 2)
    {
        if (roll == 20) { return damageMultiplier; }
        if (roll + bonus >= armurKlass) { return 1; }
        return 0;
    }
}