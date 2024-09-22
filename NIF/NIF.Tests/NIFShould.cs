using NIF;
using NIF.Exceptions;

namespace NIF.Tests {
	public class NIFShould {

		[Test]
		public void FailWhenStringIsTooLoong()
		{
			Assert.Throws<LengthException>(
				() => Nif.NewNif("1234567891011")
			);

		}

		[Test]
		public void FailWhenStringIsTooShort()
		{
			Assert.Throws<LengthException>(
				() => Nif.NewNif("0123456")
			);
		}

		[Test]
		public void FailIfStartsWithALetterOtherThan_X_Y_Z()
		{
			Assert.Throws<StructureException>(
				() => Nif.NewNif("A12345678")
				);
		}
	}
}