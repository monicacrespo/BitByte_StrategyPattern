namespace BitByte
{
    using System;

    class Program
    {
        private static void Main(string[] args)
        {
            // The client code picks a concrete strategy and passes it to the context (decoder).
            // The client should be aware of the differences between strategies in order to make the right choice.
            IDecodeStrategy strategy = new TwoDimensionalArrayAndConditionStrategy();

            var decoderA = new Decoder(strategy);
                      
            var output = decoderA.DecodeNumbers(1, 20);
            var result = decoderA.GetResult(output);

            decoderA.SetStrategy(new DictionaryStrategy());

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
