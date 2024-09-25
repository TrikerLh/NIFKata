using System.Text.RegularExpressions;
using NIF.Exceptions;

namespace NIF;

public class Nif
{
	public string Number { get;}
	private const string ControlMap = "TRWAGMYFPDXBNJZSQVHLCKE";

	private Nif(string number)
	{
		Number = number;
	}


	public static Nif NewNif(string candidate)
	{
		ValidateFormat(candidate);

		var controlLetter = GetControlLetter(candidate);

		if (candidate[8] == controlLetter)
		{
			return new Nif(candidate);
		}

		throw new BadControlLetterException();
	}

	private static void ValidateFormat(string candidate)
	{
		var valid = new Regex("^[0-9XYZ]\\d{7}[^UIOÑ0-9]$");

		if (!valid.IsMatch(candidate))
		{
			throw new BadFormatException();
		}
	}

	private static char GetControlLetter(string candidate)
	{
		if (candidate[0] == 'X')
		{
			candidate = candidate.Replace('X', '0');
		}
		if (candidate[0] == 'Y') {
			candidate = candidate.Replace('Y', '1');
		}
		if (candidate[0] == 'Z') {
			candidate = candidate.Replace('Z', '2');
		}
		var numeric = Convert.ToInt32(candidate.Substring(0, 8));
		var modulus = numeric % 23;
		return ControlMap[modulus];
	}
}