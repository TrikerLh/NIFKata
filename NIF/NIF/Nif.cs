namespace NIF;

public class Nif
{
	private Nif(string candidate)
	{
		throw new NotImplementedException();
	}

	public static Nif NewNif(string candidate)
	{
		throw new TooLoongException();
	}
}