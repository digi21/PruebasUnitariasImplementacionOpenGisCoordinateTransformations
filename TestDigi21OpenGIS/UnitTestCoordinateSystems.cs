#define _FORMULAS_JHS

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digi21.OpenGis.CoordinateTransformations;
using Digi21.OpenGis.CoordinateSystems;
using Gigs;
using Digi21.OpenGis.Epsg;

namespace Digi21.Geodesia.Test
{
    enum CardinalPoint { E, W, N, S }

    public class TestTransformacionesCoordenadas
    {
        static void AGMS(double gradosSexagesimal, out uint grados, out uint minutos, out double segundos, out bool positivo)
        {
            positivo = gradosSexagesimal > 0;
            gradosSexagesimal = Math.Abs(gradosSexagesimal);

            grados = (uint)gradosSexagesimal;
            minutos = (uint)((gradosSexagesimal - grados) * 60);
            segundos = ((gradosSexagesimal - grados) * 60 - minutos) * 60;
        }

        static uint AGrados(double gradosSexagesimal)
        {
            gradosSexagesimal = Math.Abs(gradosSexagesimal);
            return (uint)gradosSexagesimal;
        }

        static double Sexa2DecimalDegrees(uint grados, uint minutos, double segundos, CardinalPoint CardinalPoint)
        {
            if (CardinalPoint == CardinalPoint.E || CardinalPoint == CardinalPoint.N)
                return grados + minutos / 60.0 + segundos / 3600.0;

            return -grados - minutos / 60.0 - segundos / 3600.0;
        }

        static void TestDirectTransform(IMathTransform t, double latitud, double longitud, double x, double y, double sigma)
        {
            double[] transformado = t.Transform(new double[] { longitud, latitud });
            Assert.AreEqual(x, transformado[0], sigma);
            Assert.AreEqual(y, transformado[1], sigma);
        }

        static void TestInverseTransform(IMathTransform t, double latitud, double longitud, double x, double y, double sigma)
        {
            double[] transformado = t.Transform(new double[] { x, y });
            Assert.AreEqual(longitud, transformado[0], sigma);
            Assert.AreEqual(latitud, transformado[1], sigma);
        }

        public void Test5208()
        {
            //ICoordinateTransformation geogCRS_H_to_geogCRS_T = CoordinateTransformationAuthorityFactory.CreateFromTransformationCode(1763);
            //IMathTransform h2t = geogCRS_H_to_geogCRS_T.MathTransform;
            //IMathTransform t2h = h2t.Inverse;

            //double[] transformado;

            //transformado = t2h.Transform(new double[] { 5.0, 56.0 });
            //Assert.AreEqual(2.95863425555556, transformado[0], 0.000001);
            //Assert.AreEqual(62.2222222222222, transformado[1], 0.000001);

            //transformado = t2h.Transform(new double[] { 5.0, 53.0 });
            //Assert.AreEqual(2.95863425555556, transformado[0], 0.000001);
            //Assert.AreEqual(58.8888888888889, transformado[1], 0.000001);

            //transformado = t2h.Transform(new double[] { 4.0, 49.0 });
            //Assert.AreEqual(1.84752314444444, transformado[0], 0.000001);
            //Assert.AreEqual(54.4444444444444, transformado[1], 0.000001);

            //transformado = t2h.Transform(new double[] { 4.0, 53.0 });
            //Assert.AreEqual(1.84752314444444, transformado[0], 0.000001);
            //Assert.AreEqual(58.8888888888889, transformado[1], 0.000001);

            //transformado = t2h.Transform(new double[] { 7.0, 53.0 });
            //Assert.AreEqual(5.18085647777778, transformado[0], 0.000001);
            //Assert.AreEqual(58.8888888888889, transformado[1], 0.000001);

            //transformado = t2h.Transform(new double[] { 10.0, 53.0 });
            //Assert.AreEqual(8.51418981111111, transformado[0], 0.000001);
            //Assert.AreEqual(58.8888888888889, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 2.9586343, 64.444444 });
            //Assert.AreEqual(5, transformado[0], 0.000001);
            //Assert.AreEqual(58, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 2.95863425555556, 61.1111111111111 });
            //Assert.AreEqual(5, transformado[0], 0.000001);
            //Assert.AreEqual(55, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 1.84752314444444, 56.6666666666667 });
            //Assert.AreEqual(4, transformado[0], 0.000001);
            //Assert.AreEqual(51, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 0.0, 52.0 });
            //Assert.AreEqual(2.3372292, transformado[0], 0.000001);
            //Assert.AreEqual(46.8, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 0.736412033333333, 58.8888888888889 });
            //Assert.AreEqual(3, transformado[0], 0.000001);
            //Assert.AreEqual(53, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 4.06974536666667, 58.8888888888889 });
            //Assert.AreEqual(6, transformado[0], 0.000001);
            //Assert.AreEqual(53, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 7.4030787, 58.8888888888889 });
            //Assert.AreEqual(9, transformado[0], 0.000001);
            //Assert.AreEqual(53, transformado[1], 0.000001);

            //transformado = h2t.Transform(new double[] { 9.62530092222222, 58.8888888888889 });
            //Assert.AreEqual(11, transformado[0], 0.000001);
            //Assert.AreEqual(53, transformado[1], 0.000001);

            //transformado = new double[] { 5.0, 56.0 };
            //bool sw = true;
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (sw)
            //        transformado = h2t.Transform(transformado);
            //    else
            //        transformado = t2h.Transform(transformado);
            //    sw = !sw;
            //}
            //Assert.AreEqual(5, transformado[0], 0.000001);
            //Assert.AreEqual(56, transformado[1], 0.000001);
        }


        public void TestCassiniSoldnerFactoryEPSG()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(30200);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            CoordinateTransformationFactory ctf = new CoordinateTransformationFactory();
            ICoordinateTransformation coordinateTransformation = ctf.CreateFromCoordinateSystems(gcs, pcs);
            IMathTransform d = coordinateTransformation.MathTransform;
            IMathTransform i = d.Inverse;

            TestDirectTransform(d, Sexa2DecimalDegrees(10, 0, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(62, 00, 00.000, CardinalPoint.W), 66644.94, 82536.22, 1E-2);
            TestInverseTransform(i, Sexa2DecimalDegrees(10, 0, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(62, 00, 00.000, CardinalPoint.W), 66644.94, 82536.22, 1E-2);
        }

    }
}


