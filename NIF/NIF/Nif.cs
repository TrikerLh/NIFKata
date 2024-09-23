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

		Regex valid = new Regex("^[0-9XYZ].*");

		if (!valid.IsMatch(candidate))
		{
			throw new BadStartsException();
		}

		valid = new Regex("^.\\d{7}.*");

		if (!valid.IsMatch(candidate))
		{
			throw new BadMiddleFormatException();
		}

		throw new InvalidEndFormatException();
	}
}