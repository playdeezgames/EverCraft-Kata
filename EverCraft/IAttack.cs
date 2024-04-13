namespace EverCraft;

public interface IAttack
{
    public ICharacter Attacker { get; }
    /// <summary>
    /// Given a dice result (roll), performs an attack. When a successful attack occurs,
    /// award the attacker 10 XP.
    /// </summary>
    /// <param name="roll"></param>
    void PerformAttack(int roll);
}