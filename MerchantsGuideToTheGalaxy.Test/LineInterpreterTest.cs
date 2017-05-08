using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor;

namespace MerchantsGuideToTheGalaxy.Test
{
    [TestClass]
    public class LineInterpreterTest
    {
        [TestMethod]
        public void CanDeclareConstant()
        {
            var interpreter = new LineInterpreter();
            interpreter.ParseAndExecute("glob is I");
            var globSymbol = new ConstantSymbol("glob");
            var iSymbol = new RomanSymbol("I");

            Assert.IsTrue(interpreter.Processor.ConstantsTable.ContainsKey(globSymbol));
            Assert.AreEqual(iSymbol, interpreter.Processor.ConstantsTable[globSymbol]);            
        }

        [TestMethod]
        public void CanDeclareClassifier()
        {
            var interpreter = new LineInterpreter();
            interpreter.ParseAndExecute("glob is I");
            interpreter.ParseAndExecute("glob glob Silver is 34 Credits");
            
            var silverSymbol = new ClassifierSymbol("Silver");
            var creditsSymbol = new UnitSymbol("Credits");

            Assert.IsTrue(interpreter.Processor.ClassifiersTable.ContainsKey(silverSymbol));
            Assert.IsTrue(interpreter.Processor.ClassifiersTable[silverSymbol].Contains(creditsSymbol));
            Assert.AreEqual(17, interpreter.Processor.ClassifiersTable[silverSymbol].Find(s => s.Equals(creditsSymbol)).Factor);
        }

        [TestMethod]
        public void CanCalculateSimpleConversion()
        {
            var interpreter = new LineInterpreter();
            interpreter.ParseAndExecute("glob is I");
            interpreter.ParseAndExecute("pish is X");
            interpreter.ParseAndExecute("tegj is L");

            var result = interpreter.ParseAndExecute("how much is pish tegj glob glob ?");
            Assert.AreEqual("pish tegj glob glob is 42", result.ResultText);
        }

        [TestMethod]
        public void CanCalculateUnitConversion()
        {
            var interpreter = new LineInterpreter();
            interpreter.ParseAndExecute("glob is I");
            interpreter.ParseAndExecute("prok is V");
            interpreter.ParseAndExecute("pish is X");
            interpreter.ParseAndExecute("tegj is L");

            interpreter.ParseAndExecute("glob glob Silver is 34 Credits");
            interpreter.ParseAndExecute("glob prok Gold is 57800 Credits");
            interpreter.ParseAndExecute("pish pish Iron is 3910 Credits");

            var resultSilver = interpreter.ParseAndExecute("how many Credits is glob prok Silver ?");
            var resultGold = interpreter.ParseAndExecute("how many Credits is glob prok Gold ?");
            var resultIron = interpreter.ParseAndExecute("how many Credits is glob prok Iron ?");

            Assert.AreEqual("glob prok Silver is 68 Credits", resultSilver.ResultText);
            Assert.AreEqual("glob prok Gold is 57800 Credits", resultGold.ResultText);
            Assert.AreEqual("glob prok Iron is 782 Credits", resultIron.ResultText);
        }

        [TestMethod]
        public void CanHandleInvalidQueries()
        {
            var interpreter = new LineInterpreter();

            var result = interpreter.ParseAndExecute("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");

            Assert.AreEqual("I have no idea what you are talking about", result.ResultText);
        }
    }
}
