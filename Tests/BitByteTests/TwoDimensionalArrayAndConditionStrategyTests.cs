namespace BitByteTests
{
    using BitByte;
    using NUnit.Framework;

    [TestFixture]
    public class TwoDimensionalArrayAndConditionStrategyTests
    {
        private IDecodeStrategy twoDimensionalArrayAndConditionStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.twoDimensionalArrayAndConditionStrategy = new TwoDimensionalArrayAndConditionStrategy();
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }
    }
}
