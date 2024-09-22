using NIF.Exceptions;

namespace NIF;

public class Nif
{
	private Nif(string candidate)
	{
		throw new NotImplementedException();
	}

	public static Nif NewNif(string candidate)
	{
		if (candidate.Length != 9)
		{
			throw new LengthException();
		}

		throw new StructureException();
	}
}