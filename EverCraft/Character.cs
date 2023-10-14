namespace EverCraft;

public class Character : ICharacter
{
    public string Name { get; set; } = "yermom";
    public Alignment Alignment { get; set; } = Alignment.Gud;
    public int ArmurKlass { get; set; } = 10;
    public int HeetPints { get; } = 5;
}
