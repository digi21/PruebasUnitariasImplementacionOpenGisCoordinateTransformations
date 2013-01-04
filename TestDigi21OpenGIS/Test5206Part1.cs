using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;
using Digi21.OpenGis.Epsg;

namespace TestDigi21OpenGIS
{
    [TestClass]
    public class Test5206Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5206_part_1()
        {
            // Este test está mal en el archivo Excel pues en el archivo de preguntas preguntan por unas coordenadas que no coinciden con las preguntas del archivo de respuestas.
            // Además, muchas de las respuestas del propio archivo Excel están mal pues las he comprobado con la página oficial http://www.ngs.noaa.gov/cgi-bin/nadcon.prl
            // y el resultado que me sale es idéntico al de esta página. Así que únicamente he programado las pruebas de Conus, aunque las de Alaska me salen perfectas
            // (si comparo con la página web)
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""nadcon"",PARAMETER[""latitude_difference_file"",""conus.las""],PARAMETER[""longitude_difference_file"",""conus.los""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = d.Inverse;

            ExecuteTests(d, i);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test5206_part_1_OutOfRange_1()
        {
            // Este test está mal en el archivo Excel pues en el archivo de preguntas preguntan por unas coordenadas que no coinciden con las preguntas del archivo de respuestas.
            // Además, muchas de las respuestas del propio archivo Excel están mal pues las he comprobado con la página oficial http://www.ngs.noaa.gov/cgi-bin/nadcon.prl
            // y el resultado que me sale es idéntico al de esta página. Así que únicamente he programado las pruebas de Conus, aunque las de Alaska me salen perfectas
            // (si comparo con la página web)
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""nadcon"",PARAMETER[""latitude_difference_file"",""conus.las""],PARAMETER[""longitude_difference_file"",""conus.los""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = d.Inverse;

            TestInverseTransform(i, 0.0, 0.0, Sexa2DecimalDegrees(19, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(98, 31, 04.000, CardinalPoint.W), 1E-3);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test5206_part_1_OutOfRange_2()
        {
            // Este test está mal en el archivo Excel pues en el archivo de preguntas preguntan por unas coordenadas que no coinciden con las preguntas del archivo de respuestas.
            // Además, muchas de las respuestas del propio archivo Excel están mal pues las he comprobado con la página oficial http://www.ngs.noaa.gov/cgi-bin/nadcon.prl
            // y el resultado que me sale es idéntico al de esta página. Así que únicamente he programado las pruebas de Conus, aunque las de Alaska me salen perfectas
            // (si comparo con la página web)
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""nadcon"",PARAMETER[""latitude_difference_file"",""conus.las""],PARAMETER[""longitude_difference_file"",""conus.los""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = d.Inverse;

            TestDirectTransform(d, Sexa2DecimalDegrees(51, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 0.0, 0.0, 2E-3);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(29, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(90, 31, 04.000, CardinalPoint.W), Sexa2DecimalDegrees(29, 17, 00.813, CardinalPoint.N), Sexa2DecimalDegrees(90, 31, 04.310, CardinalPoint.W), 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(27, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(92, 31, 04.000, CardinalPoint.W), Sexa2DecimalDegrees(27, 17, 00.998, CardinalPoint.N), Sexa2DecimalDegrees(92, 31, 04.372, CardinalPoint.W), 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(25, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(94, 31, 04.000, CardinalPoint.W), Sexa2DecimalDegrees(25, 00, 01.255, CardinalPoint.N), Sexa2DecimalDegrees(94, 31, 04.348, CardinalPoint.W), 1E-3);

            TestInverseTransform(i, Sexa2DecimalDegrees(29, 59, 59.272, CardinalPoint.N), Sexa2DecimalDegrees(89, 31, 03.818, CardinalPoint.W), Sexa2DecimalDegrees(30, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(89, 31, 04.000, CardinalPoint.W), 1E-3);
            TestInverseTransform(i, Sexa2DecimalDegrees(28, 16, 59.111, CardinalPoint.N), Sexa2DecimalDegrees(91, 31, 03.633, CardinalPoint.W), Sexa2DecimalDegrees(28, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(91, 31, 04.000, CardinalPoint.W), 1E-3);
            TestInverseTransform(i, Sexa2DecimalDegrees(26, 16, 58.881, CardinalPoint.N), Sexa2DecimalDegrees(93, 31, 03.623, CardinalPoint.W), Sexa2DecimalDegrees(26, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(93, 31, 04.000, CardinalPoint.W), 1E-3);

            try
            {
                TestInverseTransform(i, 0.0, 0.0, Sexa2DecimalDegrees(19, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(98, 31, 04.000, CardinalPoint.W), 1E-3);
                Console.WriteLine("Mal");
            }
            catch (Exception)
            {
            }

            try
            {
                TestDirectTransform(d, Sexa2DecimalDegrees(51, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 0.0, 0.0, 2E-3);
                Console.WriteLine("Mal");
            }
            catch (Exception)
            {
            }

            TestDirectTransform(d, Sexa2DecimalDegrees(49, 59, 59.999, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), Sexa2DecimalDegrees(50, 00, 00.158, CardinalPoint.N), Sexa2DecimalDegrees(112, 00, 02.983, CardinalPoint.W), 2E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(48, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), Sexa2DecimalDegrees(47, 59, 59.858, CardinalPoint.N), Sexa2DecimalDegrees(112, 00, 03.057, CardinalPoint.W), 2E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(47, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), Sexa2DecimalDegrees(46, 59, 59.795, CardinalPoint.N), Sexa2DecimalDegrees(112, 00, 02.997, CardinalPoint.W), 2E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(45, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), Sexa2DecimalDegrees(44, 59, 59.711, CardinalPoint.N), Sexa2DecimalDegrees(112, 00, 02.888, CardinalPoint.W), 2E-3);


            TestInverseTransform(i, Sexa2DecimalDegrees(49, 59, 59.840, CardinalPoint.N), Sexa2DecimalDegrees(111, 59, 57.017, CardinalPoint.W), Sexa2DecimalDegrees(49, 59, 59.999, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 2E-3);
            TestInverseTransform(i, Sexa2DecimalDegrees(49, 00, 00.012, CardinalPoint.N), Sexa2DecimalDegrees(111, 59, 56.837, CardinalPoint.W), Sexa2DecimalDegrees(49, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 2E-3);
            TestInverseTransform(i, Sexa2DecimalDegrees(47, 00, 00.205, CardinalPoint.N), Sexa2DecimalDegrees(111, 59, 57.004, CardinalPoint.W), Sexa2DecimalDegrees(47, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 2E-3);
            TestInverseTransform(i, Sexa2DecimalDegrees(46, 00, 00.264, CardinalPoint.N), Sexa2DecimalDegrees(111, 59, 57.032, CardinalPoint.W), Sexa2DecimalDegrees(46, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(112, 0, 0, CardinalPoint.W), 2E-3);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(29, 17, 0, CardinalPoint.N), Sexa2DecimalDegrees(90, 31, 04.000, CardinalPoint.W));
        }
    }
}
