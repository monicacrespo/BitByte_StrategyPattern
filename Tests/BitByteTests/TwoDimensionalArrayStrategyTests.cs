namespace BitByteTests
{
    using BitByte;
    using NUnit.Framework;

    [TestFixture]
    public class TwoDimensionalArrayStrategyTests
    {
        private IDecodeStrategy twoDimensionalArrayStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.twoDimensionalArrayStrategy = new TwoDimensionalArrayStrategy();
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.twoDimensionalArrayStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.twoDimensionalArrayStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.twoDimensionalArrayStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.twoDimensionalArrayStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }
    }
}
