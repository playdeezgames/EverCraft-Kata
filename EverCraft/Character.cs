﻿namespace EverCraft;

public class Character : ICharacter
{
    public string Name { get; set; } = "yermom";
    public Alignment Alignment { get; set; } = Alignment.Gud;
    public int ArmurKlass { get; set; } = 10;
    public int HeetPints { get; set; } = 5;
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
        
        if (roll >= ArmurKlass)
        {
            HeetPints--;
            return true;
        }
        return false;
    }

    public int GetAbilityScore(Ability ability) => _abilityScores[ability];

    public int GetAbilityScoreModifier(Ability ability)
    {
        int score = _abilityScores[ability];
        return score switch {
            1 => -5,
            2 => -4,
            3 => -4,
            4 => -3,
            5 => -3,
            6 => -2,
            7 => -2,
            8 => -1,
            9 => -1,
            10 => 0,
            11 => 0,
            12 => 1,
            13 => 1,
            14 => 2,
            15 => 2,
            16 => 3,
            17 => 3,
            18 => 4,
            19 => 4,
            20 => 5,
            _ => throw new Exception("Invalid score?"),
        };
    }

    public void SetAbilityScore(Ability ability, int score) => _abilityScores[ability] = score;
}
