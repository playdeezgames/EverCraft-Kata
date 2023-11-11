using System.Security.Cryptography.X509Certificates;

namespace EverCraft;

public class Character : ICharacter
{
    public string Name { get; set; } = "yermom";
    public Alignment Alignment { get; set; } = Alignment.Gud;
    private int _armurKlass = 10;
    public int HeetPints { get; set; } = 5;

    public int CurrentArmurKlass => _armurKlass + GetAbilityScoreModifier(Ability.Dexterity);

    public int BaseArmurKlass { set => _armurKlass = value; }

    private Dictionary<Ability, int> _abilityScores = new ()
    {
        [Ability.Strength] = 10,
        [Ability.Dexterity] = 10,
        [Ability.Constitution] = 10,
        [Ability.Wisdom] = 10,
        [Ability.Intelligence] = 10,
        [Ability.Charisma] = 10,
        [Ability.Comelyness] = 10,
    };

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
        
        if (roll >= CurrentArmurKlass)
        {
            HeetPints--;
            return true;
        }
        return false;
    }

    public int GetAbilityScore(Ability ability) => _abilityScores[ability];

    private static readonly IReadOnlyDictionary<int,int> _modifiers=
        new Dictionary<int,int>{
            [1 ]= -5,
            [2 ]= -4,
            [3 ]= -4,
            [4 ]= -3,
            [5 ]= -3,
            [6 ]= -2,
            [7 ]= -2,
            [8 ]= -1,
            [9 ]= -1,
            [10] = 0,
            [11] = 0,
            [12] = 1,
            [13] = 1,
            [14] = 2,
            [15] = 2,
            [16] = 3,
            [17] = 3,
            [18] = 4,
            [19] = 4,
            [20] = 5,
        };

    public int GetAbilityScoreModifier(Ability ability)=>_modifiers[GetAbilityScore(ability)];

    public void SetAbilityScore(Ability ability, int score) => _abilityScores[ability] = score;
}
