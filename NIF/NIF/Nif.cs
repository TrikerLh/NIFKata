using System.Text.RegularExpressions;
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

		Regex re = new Regex("^[^0-9XYZ].*");

		if (re.IsMatch(candidate))
		{
			throw new StructureException();
		}

		throw new BadMiddleFormatException();
	}
}