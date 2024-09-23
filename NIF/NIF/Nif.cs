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

		var controlLetter = candidate[8];
		var numeric = Convert.ToInt32(candidate.Substring(0, 8));
		var modulus = numeric % 23;


		if (controlLetter == 'T' && modulus == 0)
		{
			return new Nif(candidate);
		}

		if (controlLetter == 'R' && modulus == 1) {
			return new Nif(candidate);
		}

		throw new BadControlLetterException();
	}
}