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
		Regex valid = new Regex("^[0-9XYZ]\\d{7}.$");

		if (!valid.IsMatch(candidate))
		{
			throw new BadFormatException();
		}
		
		throw new InvalidEndFormatException();
	}
}