using DoofesZeug.Tools.Crypt;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Crypt
{
    [TestClass]
    public class TestROT128
    {
        [TestMethod]
        public void ExecuteROT18()
        {
            string strOriginal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string strExcepted = "ÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚ";

            string strRotated = ROT128.Rotate(strOriginal);

            Assert.IsNotNull(strRotated);
            Assert.IsTrue(strRotated.Equals(strExcepted));

            // And Vice Versa
            Assert.IsTrue(strOriginal.Equals(ROT128.Rotate(strRotated)));
        }
    }
}
