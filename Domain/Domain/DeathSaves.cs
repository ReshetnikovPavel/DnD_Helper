using Infrastructure;

namespace Domain;

public class DeathSaves : ValueType<DeathSaves>, IDndObject
{
	public int Successes { get; set; }
	public int Failures { get; set; }
}