using NIF;

namespace NIF.Tests {
	public class NIFShould {

		[Test]
		public void FailWhenStringIsTooLoong()
		{
			Assert.Throws<TooLoongException>(
				() => Nif.NewNif("1234567891011")
			);

		}

		[Test]
		public void FailWhenStringIsTooShort()
		{
			Assert.Throws<TooShortException>(
				() => Nif.NewNif("0123456")
			);
		}
	}
}