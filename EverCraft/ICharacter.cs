
namespace EverCraft;

public interface ICharacter
{
    public string Name {get;set;}
    public CharacterClass CharacterClass { get; }
    public Alignment Alignment { get; set; }
    public int ArmorClassWithModfier();
    public int BaseArmurKlass{get; set;}
    public int HeetPints { get; set; }
    int GetAbilityScore(Ability ability);
    int GetAbilityScoreModifier(Ability ability);
    void SetAbilityScore(Ability ability, int score);
    int BaseDamage();

    public bool IsDead => HeetPints <= 0;

    public int XP { get; set; }
    public int Level { get; }
}
