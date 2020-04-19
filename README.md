# BitByte_StrategyPattern
A simple Console Application in C#.NET to illustrate the Strategy design pattern to decode a number in different ways at different times

The solution contains two projects:

* BitByte
* BitByteTests

The code illustrates the following topics:

* Implementation of the strategy design pattern in a console application using Net Core 2.2
* Use of an interface abstraction, which let us create multiple strategy implementations to be passed to client objects as needed
* Unit Testing the design pattern using NUnit


To implement the strategy pattern, you need three main elements:

* A client, which is aware of the existence of some abstract strategy but may not know what that strategy does or how it does it. In this example, the console.
* A set of strategies that the client can use if/when provided with one of them. In this example, defined in the DecodeStrategies class.
* Context that the client can provide to its current strategy to use in execution. In this example, Decoder class.

Our Decoder class accepts a strategy argument at construction and also has a setter to change that strategy if desired. 
We pass it one of several strategy classes defined in the DecodeStrategies class. Each of these strategies has a DecodeNumber method, meaning that our client objects can execute any of them with the same code. We have each strategy implementing a IDecodeStrategy interface. 
When this program runs, each decoder is provided with the desired strategy at instantiation. During program execution, the decoders are then able to use these strategies as needed, passing their own name as context to the strategy. And if we wanted to update a particular decoder’s strategy mid-way through the program, we could easily do so with a setter method, as in decoderA.SetStrategy (dictionaryStrategy);

This behavioral design pattern has a number of benefits, including: 

* Encapsulation of particular algorithms in their own classes
* Isolation of knowledge about how algorithms are implemented 
* Code that is more flexible, and maintainable. These are the same attributes that result from code that follows the Open/Closed Principle (OCP) and indeed, the strategy pattern is an excellent way to write OCP-adherent code.