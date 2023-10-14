
namespace EverCraft;

public interface ICharacter
{
    public string Name {get;set;}
    public Alignment Alignment { get; set; }
    public int ArmurKlass { get; set; }
    public int HeetPints { get; set; }
    public bool Attack(int roll);
    public bool IsDead => HeetPints <= 0;
}
