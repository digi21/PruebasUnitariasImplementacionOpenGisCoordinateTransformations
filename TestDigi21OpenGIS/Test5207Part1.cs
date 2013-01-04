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
    public class Test5207Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5207_part_1_Epsg()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4202);
            var vertB = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4283);

            ExecuteTests(vertA, vertB, lista => "1803");
        }

        [TestMethod]
        public void Test5207_part_1_Epsg_Inverse()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4283);
            var vertB = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4202);

            ExecuteTests(vertA, vertB, true, lista => "1803");
        }

        [TestMethod]
        public void Test5207_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test5207_part_1_MathTransform_OutOfRange_1()
        {
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            TestDirectTransform(d, Sexa2DecimalDegrees(8, 0, 0.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E), 0.0, 0.0, 1E-6);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test5207_part_1_OutOfRange_MathTransform_2()
        {
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""NTv2"",PARAMETER[""Latitude_and_longitude_difference_file"",""A66 National (13.09.01).gsb""]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            TestDirectTransform(d, Sexa2DecimalDegrees(10, 0, 0.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E), 0.0, 0.0, 1E-6);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(10, 03, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E), Sexa2DecimalDegrees(10, 02, 55.094, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 04.504, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(12, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E), Sexa2DecimalDegrees(11, 59, 55.119, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 04.541, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(9, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 24.000, CardinalPoint.E), Sexa2DecimalDegrees(8, 59, 54.756, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 28.078, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(9, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 36.000, CardinalPoint.E), Sexa2DecimalDegrees(8, 59, 54.756, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 40.078, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(27, 07, 35.315, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 19.431, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 24.000, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 00.000, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 24.685, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 04.568, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 18.000, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 24.684, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 22.568, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(28, 03, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(137, 50, 50.000, CardinalPoint.E), Sexa2DecimalDegrees(28, 02, 54.712, CardinalPoint.S), Sexa2DecimalDegrees(137, 50, 54.620, CardinalPoint.E), 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(28, 03, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 50, 50.000, CardinalPoint.E), Sexa2DecimalDegrees(28, 02, 54.668, CardinalPoint.S), Sexa2DecimalDegrees(138, 50, 54.573, CardinalPoint.E), 1E-6);

            TestInverseTransform(i, Sexa2DecimalDegrees(11, 00, 04.894, CardinalPoint.S), Sexa2DecimalDegrees(114, 59, 55.479, CardinalPoint.E), Sexa2DecimalDegrees(11, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(9, 00, 05.244, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 37.922, CardinalPoint.E), Sexa2DecimalDegrees(9, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 42.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(9, 00, 05.244, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 55.922, CardinalPoint.E), Sexa2DecimalDegrees(9, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 00.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(9, 00, 05.244, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 13.922, CardinalPoint.E), Sexa2DecimalDegrees(9, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 18.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 42.000, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 24.685, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 46.568, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(27, 07, 35.315, CardinalPoint.S), Sexa2DecimalDegrees(138, 02, 55.432, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 00.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(27, 07, 35.316, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 31.432, CardinalPoint.E), Sexa2DecimalDegrees(27, 07, 30.000, CardinalPoint.S), Sexa2DecimalDegrees(138, 03, 36.000, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(28, 03, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(136, 50, 50.000, CardinalPoint.E), Sexa2DecimalDegrees(28, 02, 54.697, CardinalPoint.S), Sexa2DecimalDegrees(136, 50, 54.691, CardinalPoint.E), 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(28, 03, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(139, 50, 50.000, CardinalPoint.E), Sexa2DecimalDegrees(28, 02, 54.626, CardinalPoint.S), Sexa2DecimalDegrees(139, 50, 54.511, CardinalPoint.E), 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(12, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(115, 00, 00.000, CardinalPoint.E));
        }
    }
}
