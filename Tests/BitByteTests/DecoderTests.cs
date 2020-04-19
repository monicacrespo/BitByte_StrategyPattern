namespace BitByteTests
{
    using System.Linq;
    using BitByte;
    using NUnit.Framework;

    public class DecoderTests
    {
        private IDecodeStrategy stringStrategy;
        private Decoder context;

        [SetUp]
        public void BeforeEachTest()
        {
            this.stringStrategy = new StringStrategy();
            this.context = new Decoder(this.stringStrategy);
        }

        [Test]
        public void WhenDecodingPositiveNumbersThenShouldGetApropiateListOfString()
        {
            var expected = this.GetDummyCollectionFrom1To20();
            var result = this.context.DecodeNumbers(1, 20);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Has.Exactly(20).Items);
        }

        [Test]
        public void WhenDecodingNegativeNumbersThenShouldGetApropiateListOfString()
        {
            var expected = this.GetDummyCollectionFromMinus3To20();
            var result = this.context.DecodeNumbers(-3, 10);
            Assert.That(result.Count, Is.EqualTo(14));
        }

        [Test]
        public void WhenDecodinWrongRangeThenShouldNotGenerateAnySequence()
        {
            var result = this.context.DecodeNumbers(0, -1).ToList();
            Assert.That(result, Is.Empty);
            Assert.That(result, Is.EqualTo(Enumerable.Empty<string>()));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGenerateAggregatedString()
        {
            var expected = this.GetAggregateStringOfColletionFrom1To20();
            var result = this.context.GetResult(this.GetDummyCollectionFrom1To20());
            Assert.That(result, Is.EqualTo(expected));
        }

        private string GetAggregateStringOfColletionFrom1To20()
        {
            return "1 2 bit 4 byte bit 7 8 bit byte 11 bit 13 14 bitbyte 16 17 bit 19 byte";
        }

        private string[] GetDummyCollectionFrom1To20()
        {
            return new[]
            {
                "1", "2", "bit", "4", "byte",
                "bit", "7", "8", "bit", "byte",
                "11", "bit", "13", "14", "bitbyte",
                "16", "17", "bit", "19", "byte"
            };
        }

        private string[] GetDummyCollectionFromMinus3To20()
        {
            return new[]
            {
                "-3", "-1", "-2", "bitbyte", "1", "2", "bit", "4", "byte",
                "bit", "7", "8", "bit", "byte"
            };
        }
    }
}