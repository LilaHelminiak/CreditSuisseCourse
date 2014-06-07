Lilianna Helminiak,
2014-04-29
Week 8 assignment

_____________________

week8.zip contains:

- Common:
Here are all interfaces and classes used in previous assignments (assignment 3 & 4).

- DataGeneratorServiceLibrary
Here is the WCF application that generates Market data

- SelfHost
An application that hosts DataGeneratorService

- UseCase5.Specs
Here are BDD tests


How run the DataGeneratorService:
It's needed to build the SelfHost project and run SelfHost.exe.

How run the tests:

1. The DataGeneratorService must be running
2. The UseCase5.Specs project must be open in the VisualStudio 2012
3. Open UpdateMarketData.feature file
4. Right-click on the feature and Run Tests using NUnit

It's important to run ALL tests in this feature, not one by one, 
since I'm using FeatureContext that saves an object in the first test 
and uses it in the second test.


How the new price is calculaed:
For this purpose I used the application I wrote for the Assignment 3 (Common/CalculateStock.cs).
I tried to refactor it a little bit since I'm aware that my writing practices 
were not so good back then.