# Solution for problem: Merchant's Guide To The Galaxy

The original problem description is at the end of this file.

## 1. About the solution

### 1.1. Language, solution type and structure

The solution is a C# .NET console application made on VS2013. I've created three projects, the main one is a console application project that references the core project and for last a test project to ensure that the rules are being respected.

##### - The core

In the core project I created classes and namespaces of the application, splitting it into two main streams: one for the interpreter/processor and another to the "The Roman Calculator" ( to Roman Numeral conversions )

### 1.2. Running the application

To run the application you should just execute it from VS2013, nothing else is required.

### 1.3. The solution

When the user input a sentence, the interpreter (instantiated when the application starts, before the user interation loop on the console application) receive it, initialize the Lexical Analyser and get all of the symbols on the sentence.

With the symbols list, the interpreter identify what kind of command the user typed, instantiate it and call the processor to execute it, receiving the "command result" that has the result of the command.

We are three command types:

- ConstantDeclarationCommands: Maps the intergalactical numeral to a roman numeral
- ClassifierDeclarationCommands: Maps the relationship between the metals, units and values (I named it classifier because I couldn't think a better name, I tried to make a "more flexible solution" thinking that the merchant's can begin sell other kind of thing, like bread... then it's a classifier of the thing that he sell...)'
- QueryCommands: The query command that calculate the conversions and returns the message.

Specific exceptions are throwed for parsing errors, command executions errors, duplicated declarations errors and roman numeral conversion errors.

I've add the twice declaratioon exception, but the application is ready to store more then one unit per "classifier". It allows you to declare a lot of diferent units for the same "classifier" (product) and its will calculate it correctly.

Example: 
- glob is I
- glob Bananas is 3 Dilmas
- glob Bananas is 1 Obamas

Them the sentence "How may Dilmas is glob glob Bananas" will output "glob glob Bananas is 6 Dilmas" and the sentence "How may Obamas is glob glob Bananas" will output "glob glob Bananas is 2 Obamas" on the same instance of the program.

## 2. Problem description
### - Problem Three: Merchant's Guide To The Galaxy

You decided to give up on earth after the latest financial collapse left 99.99% of the earth's population with 0.01% of the wealth. Luckily, with the scant sum of money that is left in your account, you are able to afford to rent a spaceship, leave earth, and fly all over the galaxy to sell common metals and dirt (which apparently is worth a lot).

Buying and selling over the galaxy requires you to convert numbers and units, and you decided to write a program to help you.

The numbers used for intergalactic transactions follows similar convention to the roman numerals and you have painstakingly collected the appropriate translation between them.

Roman numerals are based on seven symbols:

| Symbol | Value |
|---|---|
| I | 1 |
| V | 5 |
| X | 10 |
| L | 50 |
| C | 100 |
| D | 500 |
| M | 1,000 |


Numbers are formed by combining symbols together and adding the values. For example, MMVI is 1000 + 1000 + 5 + 1 = 2006. Generally, symbols are placed in order of value, starting with the largest values. When smaller values precede larger values, the smaller values are subtracted from the larger values, and the result is added to the total. For example MCMXLIV = 1000 + (1000 − 100) + (50 − 10) + (5 − 1) = 1944.

The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more. (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) "D", "L", and "V" can never be repeated.
"I" can be subtracted from "V" and "X" only. "X" can be subtracted from "L" and "C" only. "C" can be subtracted from "D" and "M" only. "V", "L", and "D" can never be subtracted.
Only one small-value symbol may be subtracted from any large-value symbol.
A number written in [16]Arabic numerals can be broken into digits. For example, 1903 is composed of 1, 9, 0, and 3. To write the Roman numeral, each of the non-zero digits should be treated separately. Inthe above example, 1,000 = M, 900 = CM, and 3 = III. Therefore, 1903 = MCMIII.

(Source: Wikipedia ( [17]http://en.wikipedia.org/wiki/Roman_numerals)

Input to your program consists of lines of text detailing your notes on the conversion between intergalactic units and roman numerals.

You are expected to handle invalid queries appropriately.

Test input:
glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
glob prok Gold is 57800 Credits
pish pish Iron is 3910 Credits
how much is pish tegj glob glob ?
how many Credits is glob prok Silver ?
how many Credits is glob prok Gold ?
how many Credits is glob prok Iron ?
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?

Test Output:
pish tegj glob glob is 42
glob prok Silver is 68 Credits
glob prok Gold is 57800 Credits
glob prok Iron is 782 Credits
I have no idea what you are talking about