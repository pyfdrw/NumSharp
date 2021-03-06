using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NumSharp.Core;

namespace NumSharp.UnitTest.Operations
{
    [TestClass]
    public class NDArrayMultiplicationTest
    {
        [TestMethod]
        public void DoubleTwo1D_NDArrayMultiplication()
        {
            var np1 = new NDArray(typeof(double)).arange(4, 1, 1).reshape(1, 3);
            var np2 = new NDArray(typeof(double)).arange(5, 2, 1).reshape(1, 3);

            var np3 = np1 * np2;

            Assert.IsTrue(Enumerable.SequenceEqual(new double[] { 2, 6, 12 }, np3.Storage.GetData<double>()));
        }

        [TestMethod]
        public void ComplexTwo1D_NDArrayMultiplication()
        {
            var np1 = new NDArray(typeof(Complex),2);
            np1.Storage.SetData(new Complex[] { new Complex(1, 2), new Complex(3, 4) });

            var np2 = new NDArray(typeof(Complex),2);
            np2.Storage.SetData(new Complex[] { new Complex(5, 6), new Complex(7, 8) });

            var np3 = np1 * np2;

            Assert.IsTrue(Enumerable.SequenceEqual(new Complex[] { new Complex(-7, 16), new Complex(-11, 52) }, np3.Storage.GetData<Complex>()));

        }

        [TestMethod]
        public void Double1DPlusOffset_NDArrayMultiplication()
        {
            var np1 = new NDArray(typeof(double),3);
            np1.Storage.SetData(new double[] { 1, 2, 3 });

            var np3 = np1 * 2;

            Assert.IsTrue(Enumerable.SequenceEqual(new double[] { 2, 4, 6 }, np3.Storage.GetData<double>()));
        }

        [TestMethod]
        public void Complex1DPlusOffset_NDArrayMultiplication()
        {
            var np1 = new NDArray(typeof(Complex),2);
            np1.Storage.SetData(new Complex[] { new Complex(1, 2), new Complex(3, 4) });

            var np2 = np1 * new Complex(1, 2);

            Assert.IsTrue(Enumerable.SequenceEqual(new Complex[] { new Complex(-3, 4), new Complex(-5, 10) }, np2.Storage.GetData<Complex>()));
        }
    }
}
