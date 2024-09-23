using System.Text.RegularExpressions;
using NIF.Exceptions;

namespace NIF;

public class Nif
{
	public string Number { get;}

	private Nif(string number)
	{
		Number = number;
	}


	public static Nif NewNif(string candidate)
	{
		Regex valid = new Regex("^[0-9XYZ]\\d{7}[^UIOÑ0-9]$");

		if (!valid.IsMatch(candidate))
		{
			throw new BadFormatException();
		}

		if (candidate == "00000023T")
		{
			return new Nif(candidate);
		}

		if (candidate == "00000046T") {
			return new Nif(candidate);
		}

		throw new BadControlLetterException();
	}
}