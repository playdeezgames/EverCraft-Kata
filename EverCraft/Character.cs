namespace EverCraft;

public class Character : ICharacter
{
    public string Name { get; set; } = "yermom";
    public CharacterClass CharacterClass { get; init; } = CharacterClass.Commoner;
    public Alignment Alignment { get; set; } = Alignment.Gud;
    private int _armurKlass = 10;
    public int BaseHP => Level * Math.Max(1, CharacterClass.BaseHPModifierPerLevel() + GetAbilityScoreModifier(Ability.Constitution));
    private int _wounds = 0;
    public int HeetPints 
    { 
        get => BaseHP - _wounds; 
        set
        {
            _wounds = BaseHP - value;
        } 
    }
    


    public int CurrentArmurKlass => _armurKlass + GetAbilityScoreModifier(Ability.Dexterity);

    public int BaseArmurKlass { set => _armurKlass = value; }
    public int XP { get; set; } = 0;

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

    public int Level => XPToLevel(XP, 1);

    private static int XPToLevel(int xp, int currentLevel)
    {
        int xpToNext = currentLevel * 1000;
        if (xp < xpToNext) { return currentLevel; }
        return XPToLevel(xp - xpToNext, currentLevel + 1);
    }

    public int BaseDamage() => 1 + GetAbilityScoreModifier(Ability.Strength);
}
