
namespace EverCraft;

public interface ICharacter
{
    public string Name {get;set;}
    public Alignment Alignment { get; set; }
    public int ArmurKlass { get; set; }
    public int HeetPints { get; set; }
    public bool Attack(int roll);
    int GetAbilityScore(Ability ability);
    int GetAbilityScoreModifier(Ability ability);
    void SetAbilityScore(Ability ability, int score);

    public bool IsDead => HeetPints <= 0;
}
