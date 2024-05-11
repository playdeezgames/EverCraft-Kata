namespace EverCraft;

public class Attack : IAttack
{
    public ICharacter Attacker { get; init; }
    private readonly ICharacter _defender;

    public void PerformAttack(int roll)
    {
        if(_defender.LegacyAttack(roll))
        {
            Attacker.XP += 10;
        }
    }

    public Attack(ICharacter attacker, ICharacter defender) => (Attacker, _defender) = (attacker, defender);

    public static void PerformAttack(ICharacter attacker, ICharacter defender, int roll)
    {
        if(defender.LegacyAttack(roll))
        {
            attacker.XP += 10;
        }
    }
}