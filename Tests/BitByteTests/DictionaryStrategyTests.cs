namespace BitByteTests
{
    using BitByte;
    using NUnit.Framework;

    [TestFixture]
    public class DictionaryStrategyTests
    {
        private IDecodeStrategy dictionaryStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.dictionaryStrategy = new DictionaryStrategy();
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.dictionaryStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.dictionaryStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.dictionaryStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.dictionaryStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }
    }
}
