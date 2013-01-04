using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digi21.OpenGis.Epsg;
using Digi21.OpenGis.CoordinateTransformations;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations.Algorithms;

namespace TestDigi21OpenGIS
{
    [TestClass]
    public class Test5211Part1
    {
        [TestMethod]
        public void Test5211_part_1()
        {
            IMathTransform d = new GeocentricTranslations(371, -112, 434);
            IMathTransform i = d.Inverse;

            ExecuteTests(d, i);
        }

        static void TestGeocentricDirect(IMathTransform t, double x1, double y1, double z1, double x2, double y2, double z2, double sigma)
        {
            double[] transformado = t.Transform(new double[] { x1, y1, z1 });

            Assert.AreNotEqual(transformado[0], double.NaN);
            Assert.AreNotEqual(transformado[1], double.NaN);
            Assert.AreNotEqual(transformado[2], double.NaN);
            Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[2], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[1], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[2], double.NegativeInfinity);
            Assert.AreEqual(x2, transformado[0], sigma);
            Assert.AreEqual(y2, transformado[1], sigma);
            Assert.AreEqual(z2, transformado[2], sigma);
        }

        static void TestGeocentricInverse(IMathTransform t, double x1, double y1, double z1, double x2, double y2, double z2, double sigma)
        {
            double[] transformado = t.Transform(new double[] { x2, y2, z2 });

            Assert.AreNotEqual(transformado[0], double.NaN);
            Assert.AreNotEqual(transformado[1], double.NaN);
            Assert.AreNotEqual(transformado[2], double.NaN);
            Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[2], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[1], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[2], double.NegativeInfinity);
            Assert.AreEqual(x1, transformado[0], sigma);
            Assert.AreEqual(y1, transformado[1], sigma);
            Assert.AreEqual(z1, transformado[2], sigma);
        }

        protected void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestGeocentricDirect(d, -1598619.169, 2768889.623, 5500844.468, -1598248.169, 2768777.623, 5501278.468, 1E-3);
            TestGeocentricDirect(d, -1598394.169, 2768499.912, 5500065.045, -1598023.169, 2768387.912, 5500499.045, 1E-3);
            TestGeocentricDirect(d, 6377563.396, 0, 0, 6377934.396, -112, 434, 1E-3);
            TestGeocentricDirect(d, 6374563.396, 0, 0, 6374934.396, -112, 434, 1E-3);
            TestGeocentricDirect(d, 6367563.396, 0, 0, 6367934.396, -112, 434, 1E-3);
            TestGeocentricDirect(d, -1598394.169, -2768499.912, -5500065.045, -1598023.169, -2768611.912, -5499631.045, 1E-3);
            TestGeocentricDirect(d, -1598169.169, -2768110.201, -5499285.622, -1597798.169, -2768222.201, -5498851.622, 1E-3);
            TestGeocentricDirect(d, 0, -5783481.614, 2678892.11, 371, -5783593.614, 2679326.11, 1E-3);
            TestGeocentricDirect(d, -4087466.478, 2977579.559, -3875891.429, -4087095.478, 2977467.559, -3875457.429, 1E-3);
            TestGeocentricDirect(d, -4086290.959, 2976723.233, -3874769.274, -4085919.959, 2976611.233, -3874335.274, 1E-3);
            TestGeocentricDirect(d, -4084371.165, 2975324.729, -3872936.631, -4084000.165, 2975212.729, -3872502.631, 1E-3);
            TestGeocentricDirect(d, -4079891.647, 2972061.553, -3868660.465, -4079520.647, 2971949.553, -3868226.465, 1E-3);
            TestGeocentricDirect(d, -2187707.719, 0, -5970583.093, -2187336.719, -112, -5970149.093, 1E-3);


            TestGeocentricInverse(i, -962850.5924, 555799.8517, 6260304.653, -962479.5924, 555687.8517, 6260738.653, 1E-3);
            TestGeocentricInverse(i, -962668.0059, 555694.4354, 6259108.961, -962297.0059, 555582.4354, 6259542.961, 1E-3);
            TestGeocentricInverse(i, 2763839.405, 4787864.865, 3170034.52, 2764210.405, 4787752.865, 3170468.52, 1E-3);
            TestGeocentricInverse(i, 2763757.32, 4787722.688, 3169939.735, 2764128.32, 4787610.688, 3170373.735, 1E-3);
            TestGeocentricInverse(i, 2763757.32, -4787498.688, -3170807.735, 2764128.32, -4787610.688, -3170373.735, 1E-3);
            TestGeocentricInverse(i, 2763529.349, -4787103.831, -3170544.497, 2763900.349, -4787215.831, -3170110.497, 1E-3);
            TestGeocentricInverse(i, 2763509.863, -4787070.081, -3170521.997, 2763880.863, -4787182.081, -3170087.997, 1E-3);
            TestGeocentricInverse(i, -962668.0059, -555470.4354, -6259976.961, -962297.0059, -555582.4354, -6259542.961, 1E-3);
            TestGeocentricInverse(i, -962521.945, -555386.1071, -6259020.462, -962150.945, -555498.1071, -6258586.462, 1E-3);
            TestGeocentricInverse(i, -962169.2951, -555182.5046, -6256711.087, -961798.2951, -555294.5046, -6256277.087, 1E-3);
            TestGeocentricInverse(i, -2187707.719, 0, 5970583.093, -2187336.719, -112, 5971017.093, 1E-3);
            TestGeocentricInverse(i, -2905069.555, -2904586.555, 4862355.038, -2904698.555, -2904698.555, 4862789.038, 1E-3);
            TestGeocentricInverse(i, 6377766, 112, -434, 6378137, 0, 0, 1E-3);
            TestGeocentricInverse(i, -2905069.555, 2904810.555, -4863223.038, -2904698.555, 2904698.555, -4862789.038, 1E-3);
        }
    }
}
