using NIF.Exceptions;

namespace NIF.Tests {
	public class NifShould {

		[Test]
		public void FailWhenStringIsTooLoong()
		{
			Assert.Throws<BadFormatException>(
				() => Nif.NewNif("1234567891011")
			);

		}

		[Test]
		public void FailWhenStringIsTooShort()
		{
			Assert.Throws<BadFormatException>(
				() => Nif.NewNif("0123456")
			);
		}

		[Test]
		public void FailIfStartsWithALetterOtherThan_X_Y_Z()
		{
			Assert.Throws<BadFormatException>(
				() => Nif.NewNif("A12345678")
			);
		}

		[Test]
		public void FailIfDoesntHave7DigitInTheMiddle()
		{
			Assert.Throws<BadFormatException>(
				() => Nif.NewNif("0123X567R")
			);
		}

		[Test]
		public void FailIfDoesntEndWithAValidControLetter() {
			Assert.Throws<BadFormatException>(
				() => Nif.NewNif("01234567U")
			);
		}

		[Test]
		public void FailIfDoesntEndWithTheRightControLetter() {
			Assert.Throws<BadControlLetterException>(
				() => Nif.NewNif("00000000S")
			);
		}

		[TestCase("00000023T")]
		[TestCase("00000046T")]
		public void AcceptMod23Being0(string candidate)
		{
			var nif = Nif.NewNif(candidate);

			Assert.That(nif.Number, Is.EqualTo(candidate));
		}
	}
}