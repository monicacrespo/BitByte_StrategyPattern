namespace BitByteTests
{
    using BitByte;
    using NUnit.Framework;

    [TestFixture]
    public class StringBuilderStrategyTests
    {
        private IDecodeStrategy stringBuilderStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.stringBuilderStrategy = new StringBuilderStrategy();
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.stringBuilderStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.stringBuilderStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.stringBuilderStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.stringBuilderStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }
    }
}
