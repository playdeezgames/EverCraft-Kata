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
    public bool Attack(int roll) => roll >= ArmurKlass;
}
