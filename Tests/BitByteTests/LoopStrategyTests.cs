namespace BitByteTests
{
    using BitByte;
    using NUnit.Framework;

    [TestFixture]
    public class LoopStrategyTests
    {
        private IDecodeStrategy loopStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.loopStrategy = new LoopStrategy();
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.loopStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.loopStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.loopStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.loopStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }
    }
}
