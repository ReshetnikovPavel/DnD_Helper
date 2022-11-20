namespace Infrastructure;

public static class IntExtensions
{
	public static int DivideBy(this int numerator, int denominator)
	{
		if (Math.Sign(numerator) == Math.Sign(denominator))
			return numerator / denominator;
		return (numerator - 1) / denominator;
	}
}