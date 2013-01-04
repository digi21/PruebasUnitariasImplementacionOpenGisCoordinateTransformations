using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gigs;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestDigi21OpenGIS
{
    public enum CardinalPoint { E, W, N, S }

    public abstract class MapProjectionTestBase
    {
        protected GigsFactory gigsFactory = new GigsFactory();
        protected CoordinateSystemFactory factory = new CoordinateSystemFactory();

        protected void ExecuteTests(ICoordinateSystem source, ICoordinateSystem target)
        {
            ExecuteTests(source, target, false, null);
        }

        protected void ExecuteTests(ICoordinateSystem source, ICoordinateSystem target, DelegateCoordinateOperation delegado)
        {
            ExecuteTests(source, target, false, delegado);
        }

        protected void ExecuteTests(ICoordinateSystem source, ICoordinateSystem target, bool inverse, DelegateCoordinateOperation delegado)
        {
            CoordinateTransformationFactory ctf = new CoordinateTransformationFactory();
            ICoordinateTransformation coordinateTransformation = ctf.CreateFromCoordinateSystems(source, target, delegado);
            IMathTransform d = coordinateTransformation.MathTransform;
            IMathTransform i = d.Inverse;

            if( inverse )
                ExecuteTests(i, d);
            else
                ExecuteTests(d, i);
        }

        protected abstract void ExecuteTests(IMathTransform d, IMathTransform i);

        protected void TestDirectTransform(IMathTransform t, double latitud, double longitud, double x, double y, double sigma)
        {
            double[] transformado = t.Transform(new double[] { latitud, longitud });

            Assert.AreNotEqual(transformado[0], double.NaN);
            Assert.AreNotEqual(transformado[1], double.NaN);
            Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[1], double.NegativeInfinity);
            Assert.AreEqual(x, transformado[0], sigma);
            Assert.AreEqual(y, transformado[1], sigma);
        }

        protected void TestInverseTransform(IMathTransform t, double latitud, double longitud, double x, double y, double sigma)
        {
            double[] transformado = t.Transform(new double[] { x, y });

            Assert.AreNotEqual(transformado[0], double.NaN);
            Assert.AreNotEqual(transformado[1], double.NaN);
            Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
            Assert.AreNotEqual(transformado[1], double.NegativeInfinity);
            Assert.AreEqual(latitud, transformado[0], sigma);
            Assert.AreEqual(longitud, transformado[1], sigma);
        }

        protected double Sexa2DecimalDegrees(uint grados, uint minutos, double segundos, CardinalPoint puntoCardinal)
        {
            if (puntoCardinal == CardinalPoint.E || puntoCardinal == CardinalPoint.N)
                return grados + minutos / 60.0 + segundos / 3600.0;

            return -grados - minutos / 60.0 - segundos / 3600.0;
        }

        protected void ExecuteIterations(IMathTransform d, IMathTransform i, double lat, double lon)
        {
            var transformado = new double[] { lat, lon };
            bool sw = true;
            for (int _i = 0; _i < 1000; _i++)
            {
                if (sw)
                    transformado = d.Transform(transformado);
                else
                    transformado = i.Transform(transformado);

                Assert.AreNotEqual(transformado[0], double.NaN);
                Assert.AreNotEqual(transformado[1], double.NaN);
                Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
                Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
                Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
                Assert.AreNotEqual(transformado[1], double.NegativeInfinity);

                sw = !sw;
            }
            Assert.AreEqual(lat, transformado[0], 1E-3);
            Assert.AreEqual(lon, transformado[1], 1E-3);
        }

        protected void ExecuteIterations(IMathTransform d, IMathTransform i, double lat, double lon, double sigma)
        {
            var transformado = new double[] { lat, lon };
            bool sw = true;
            for (int _i = 0; _i < 1000; _i++)
            {
                if (sw)
                    transformado = d.Transform(transformado);
                else
                    transformado = i.Transform(transformado);

                Assert.AreNotEqual(transformado[0], double.NaN);
                Assert.AreNotEqual(transformado[1], double.NaN);
                Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
                Assert.AreNotEqual(transformado[1], double.PositiveInfinity);
                Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
                Assert.AreNotEqual(transformado[1], double.NegativeInfinity);

                sw = !sw;
            }
            Assert.AreEqual(lat, transformado[0], sigma);
            Assert.AreEqual(lon, transformado[1], sigma);
        }
    }
}
