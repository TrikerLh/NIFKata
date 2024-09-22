using NIF.Exceptions;

namespace NIF;

public class Nif
{
	private const int Maxlength = 9;

	private Nif(string candidate)
	{
		throw new NotImplementedException();
	}

	public static Nif NewNif(string candidate)
	{
		if (candidate.Length != Maxlength)
		{
			throw new LengthException();
		}

		throw new StructureException();
	}
}