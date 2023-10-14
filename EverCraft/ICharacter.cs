
namespace EverCraft;

public interface ICharacter
{
    public string Name {get;set;}
    public Alignment Alignment { get; set; }
    public int ArmurKlass { get; }
    
}
