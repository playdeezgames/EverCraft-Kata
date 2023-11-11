namespace EverCraft;

public class Character : ICharacter
{
    public string Name { get; set; } = "yermom";
    public Alignment Alignment { get; set; } = Alignment.Gud;
    public int ArmurKlass { get; set; } = 10;
    public int HeetPints { get; set; } = 5;

    /// <summary>
    /// Given an attack roll, returns true if this character was hit and false otherwise.
    /// </summary>
    public bool Attack(int roll)
    {
        if (roll == 20)
        {
            HeetPints -= 2;
            return true;
        }
        
        if (roll >= ArmurKlass)
        {
            HeetPints--;
            return true;
        }
        return false;
    }

    public int GetAbilityScore(Ability ability)
    {
        return 10;
    }

    public int GetAbilityScoreModifier(Ability ability)
    {
        return 0;
    }
}
