using DoofesZeug.Tools.Crypt;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Crypt
{
    [TestClass]
    public class TestROT13
    {
        [TestMethod]
        public void ExecuteRO13Test()
        {
            string strOriginal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string strExcepted = "NOPQRSTUVWXYZABCDEFGHIJKLM";

            string strRotated = ROT13.Rotate(strOriginal);

            Assert.IsNotNull(strRotated);
            Assert.IsTrue(strRotated.Equals(strExcepted));

            // And Vice Versa
            Assert.IsTrue(strOriginal.Equals(ROT13.Rotate(strRotated)));
        }
    }
}
