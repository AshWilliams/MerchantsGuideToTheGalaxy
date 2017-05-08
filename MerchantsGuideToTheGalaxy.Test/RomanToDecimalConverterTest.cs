using MerchantsGuideToTheGalaxy.Core.Roman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantsGuideToTheGalaxy.Test
{
    [TestClass]
    public class RomanToDecimalConverterTest
    {
        [TestMethod]
        public void CanConvertPrimarySymbols()
        {
            var resultForI = RomanToDecimalConverter.Convert("I");
            var resultForV = RomanToDecimalConverter.Convert("V");
            var resultForX = RomanToDecimalConverter.Convert("X");
            var resultForL = RomanToDecimalConverter.Convert("L");
            var resultForC = RomanToDecimalConverter.Convert("C");
            var resultForD = RomanToDecimalConverter.Convert("D");
            var resultForM = RomanToDecimalConverter.Convert("M");

            Assert.AreEqual(1, resultForI);
            Assert.AreEqual(5, resultForV);
            Assert.AreEqual(10, resultForX);
            Assert.AreEqual(50, resultForL);
            Assert.AreEqual(100, resultForC);
            Assert.AreEqual(500, resultForD);
            Assert.AreEqual(1000, resultForM);
        }

        [TestMethod]
        public void CanConvertRepetitions()
        {
            
            var resultForIII = RomanToDecimalConverter.Convert("III");
            var resultForXXX = RomanToDecimalConverter.Convert("XXX");
            var resultForCCC = RomanToDecimalConverter.Convert("CCC");
            var resultForMMM = RomanToDecimalConverter.Convert("MMM");

            Assert.AreEqual(3, resultForIII);
            Assert.AreEqual(30, resultForXXX);
            Assert.AreEqual(300, resultForCCC);
            Assert.AreEqual(3000, resultForMMM);
        }

        [TestMethod]
        public void CanConvertSubtractions()
        {
            
            var resultForIV = RomanToDecimalConverter.Convert("IV");
            var resultForIX = RomanToDecimalConverter.Convert("IX");
            var resultForXL = RomanToDecimalConverter.Convert("XL");
            var resultForXC = RomanToDecimalConverter.Convert("XC");
            var resultForCD = RomanToDecimalConverter.Convert("CD");
            var resultForCM = RomanToDecimalConverter.Convert("CM");

            Assert.AreEqual(4, resultForIV);
            Assert.AreEqual(9, resultForIX);
            Assert.AreEqual(40, resultForXL);
            Assert.AreEqual(90, resultForXC);
            Assert.AreEqual(400, resultForCD);
            Assert.AreEqual(900, resultForCM);
        }

        [TestMethod]
        public void CanConvertAdditions()
        {
            
            var resultForVIII = RomanToDecimalConverter.Convert("VIII");
            var resultForXIII = RomanToDecimalConverter.Convert("XIII");
            var resultForXV = RomanToDecimalConverter.Convert("XV");
            var resultForXVIII = RomanToDecimalConverter.Convert("XVIII");

            Assert.AreEqual(8, resultForVIII);
            Assert.AreEqual(13, resultForXIII);
            Assert.AreEqual(15, resultForXV);
            Assert.AreEqual(18, resultForXVIII);
        }

        #region "I" can be subtracted from "V" and "X" only.
        [TestMethod]
        public void ThrowsExceptionForSubstractionFaultForI()
        {
            
            var exceptionForL = false;
            var exceptionForC = false;
            var exceptionForD = false;
            var exceptionForM = false;

            try{ RomanToDecimalConverter.Convert("IL"); }
            catch (InvalidRomanNumberException){exceptionForL = true;}
            try { RomanToDecimalConverter.Convert("IC"); }
            catch (InvalidRomanNumberException) { exceptionForC = true; }
            try { RomanToDecimalConverter.Convert("ID"); }
            catch (InvalidRomanNumberException) { exceptionForD = true; }
            try { RomanToDecimalConverter.Convert("IM"); }
            catch (InvalidRomanNumberException) { exceptionForM = true; }

            Assert.IsTrue(exceptionForL);
            Assert.IsTrue(exceptionForC);
            Assert.IsTrue(exceptionForD);
            Assert.IsTrue(exceptionForM);
            Assert.AreEqual(4, RomanToDecimalConverter.Convert("IV"));
            Assert.AreEqual(9, RomanToDecimalConverter.Convert("IX"));
        }
        #endregion

        #region "X" can be subtracted from "L" and "C" only.
        [TestMethod]
        public void ThrowsExceptionForSubstractionFaultForX()
        {
            
            var exceptionForD = false;
            var exceptionForM = false;

            try { RomanToDecimalConverter.Convert("ID"); }
            catch (InvalidRomanNumberException) { exceptionForD = true; }
            try { RomanToDecimalConverter.Convert("IM"); }
            catch (InvalidRomanNumberException) { exceptionForM = true; }

            Assert.AreEqual(11, RomanToDecimalConverter.Convert("XI"));
            Assert.AreEqual(15, RomanToDecimalConverter.Convert("XV"));
            Assert.AreEqual(20, RomanToDecimalConverter.Convert("XX"));
            Assert.AreEqual(40, RomanToDecimalConverter.Convert("XL"));
            Assert.AreEqual(90, RomanToDecimalConverter.Convert("XC"));
            Assert.IsTrue(exceptionForD);
            Assert.IsTrue(exceptionForM);
        }
        #endregion

        #region "C" can be subtracted from "D" and "M" only.
        [TestMethod]
        public void CorrectSubstractionsForC()
        {
            
            Assert.AreEqual(101, RomanToDecimalConverter.Convert("CI"));
            Assert.AreEqual(105, RomanToDecimalConverter.Convert("CV"));
            Assert.AreEqual(110, RomanToDecimalConverter.Convert("CX"));
            Assert.AreEqual(150, RomanToDecimalConverter.Convert("CL"));
            Assert.AreEqual(200, RomanToDecimalConverter.Convert("CC"));
            Assert.AreEqual(400, RomanToDecimalConverter.Convert("CD"));
            Assert.AreEqual(900, RomanToDecimalConverter.Convert("CM"));
        }
        #endregion

        #region "V", "L", and "D" can never be subtracted.
        [TestMethod]
        public void VNeverCanSubtracted()
        {
            
            Assert.AreEqual(6, RomanToDecimalConverter.Convert("VI"));

            var exceptionForVV = false;
            var exceptionForVX = false;
            var exceptionForVL = false;
            var exceptionForVC = false;
            var exceptionForVD = false;
            var exceptionForVM = false;

            try { RomanToDecimalConverter.Convert("VV"); }
            catch (InvalidRomanNumberException) { exceptionForVV = true; }
            try { RomanToDecimalConverter.Convert("VX"); }
            catch (InvalidRomanNumberException) { exceptionForVX = true; }
            try { RomanToDecimalConverter.Convert("VL"); }
            catch (InvalidRomanNumberException) { exceptionForVL = true; }
            try { RomanToDecimalConverter.Convert("VC"); }
            catch (InvalidRomanNumberException) { exceptionForVC = true; }
            try { RomanToDecimalConverter.Convert("VD"); }
            catch (InvalidRomanNumberException) { exceptionForVD = true; }
            try { RomanToDecimalConverter.Convert("VM"); }
            catch (InvalidRomanNumberException) { exceptionForVM = true; }

            Assert.IsTrue(exceptionForVV);
            Assert.IsTrue(exceptionForVX);
            Assert.IsTrue(exceptionForVL);
            Assert.IsTrue(exceptionForVC);
            Assert.IsTrue(exceptionForVD);
            Assert.IsTrue(exceptionForVM);
        }
        [TestMethod]
        public void LNeverCanSubtracted()
        {
            
            var exceptionForLL = false;
            var exceptionForLC = false;
            var exceptionForLD = false;
            var exceptionForLM = false;

            Assert.AreEqual(51, RomanToDecimalConverter.Convert("LI"));
            Assert.AreEqual(55, RomanToDecimalConverter.Convert("LV"));
            Assert.AreEqual(60, RomanToDecimalConverter.Convert("LX"));

            try { RomanToDecimalConverter.Convert("LL"); }
            catch (InvalidRomanNumberException) { exceptionForLL = true; }
            try { RomanToDecimalConverter.Convert("LC"); }
            catch (InvalidRomanNumberException) { exceptionForLC = true; }
            try { RomanToDecimalConverter.Convert("LD"); }
            catch (InvalidRomanNumberException) { exceptionForLD = true; }
            try { RomanToDecimalConverter.Convert("LM"); }
            catch (InvalidRomanNumberException) { exceptionForLM = true; }

            Assert.IsTrue(exceptionForLL);
            Assert.IsTrue(exceptionForLC);
            Assert.IsTrue(exceptionForLD);
            Assert.IsTrue(exceptionForLM);
        }

        [TestMethod]
        public void DNeverCanSubtracted()
        {
            

            var exceptionForDD = false;
            var exceptionForDM = false;

            Assert.AreEqual(501, RomanToDecimalConverter.Convert("DI"));
            Assert.AreEqual(505, RomanToDecimalConverter.Convert("DV"));
            Assert.AreEqual(510, RomanToDecimalConverter.Convert("DX"));
            Assert.AreEqual(550, RomanToDecimalConverter.Convert("DL"));
            Assert.AreEqual(600, RomanToDecimalConverter.Convert("DC"));

            try { RomanToDecimalConverter.Convert("DD"); }
            catch (InvalidRomanNumberException) { exceptionForDD = true; }
            try { RomanToDecimalConverter.Convert("DM"); }
            catch (InvalidRomanNumberException) { exceptionForDM = true; }

            Assert.IsTrue(exceptionForDD);
            Assert.IsTrue(exceptionForDM);
        }

        #endregion

        #region "D", "L", and "V" can never be repeated.
        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForD()
        {
            RomanToDecimalConverter.Convert("DD");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForL()
        {
            RomanToDecimalConverter.Convert("LL");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForV()
        {
            RomanToDecimalConverter.Convert("VV");
        }
        #endregion

        #region The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more.
        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForI()
        {
            RomanToDecimalConverter.Convert("IIII");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForX()
        {
            RomanToDecimalConverter.Convert("XXXX");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForC()
        {
            RomanToDecimalConverter.Convert("CCCC");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberException))]
        public void ThrowsExceptionForRepettitionFaultForM()
        {
            RomanToDecimalConverter.Convert("MMMM");
        }
        #endregion

    }
}
