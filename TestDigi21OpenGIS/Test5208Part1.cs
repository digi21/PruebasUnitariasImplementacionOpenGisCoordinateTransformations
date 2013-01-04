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
    public class Test5208Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5208_part_1_Epsg()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4275);
            var vertB = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4807);

            ExecuteTests(vertA, vertB, lista => "1763");
        }

        [TestMethod]
        public void Test5208_part_1_Epsg_Inverse()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4275);
            var vertB = CoordinateSystemAuthorityFactory.CreateCoordinateSystem(4807);

            ExecuteTests(vertB, vertA, true, lista => "1763");
        }

        [TestMethod]
        public void Test5208_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""longitude_rotation"",PARAMETER[""dim"",2],PARAMETER[""rotation"",2.337229169999998]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",1.111111111111112],PARAMETER[""elt_0_1"",0],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",0],PARAMETER[""elt_1_1"",1.111111111111112],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1.111111111111112]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0.8999999999999991],PARAMETER[""elt_0_1"",0],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",0],PARAMETER[""elt_1_1"",0.8999999999999991],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",0.8999999999999991]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""longitude_rotation"",PARAMETER[""dim"",2],PARAMETER[""rotation"",2.337229169999998]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(56, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 62.22222222, 2.958634256, 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 58.88888889, 2.958634256, 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(49, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(4, 0, 0, CardinalPoint.E), 54.44444444, 1.847523144, 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(4, 0, 0, CardinalPoint.E), 58.88888889, 1.847523144, 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(7, 0, 0, CardinalPoint.E), 58.88888889, 5.180856478, 1E-6);
            TestDirectTransform(d, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(10, 0, 0, CardinalPoint.E), 58.88888889, 8.514189811, 1E-6);

            TestInverseTransform(i, Sexa2DecimalDegrees(58, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 64.44444444, 2.958634256, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(55, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 61.11111111, 2.958634256, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(51, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(4, 0, 0, CardinalPoint.E), 56.66666667, 1.847523144, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(46, 48, 0, CardinalPoint.N), Sexa2DecimalDegrees(2, 20, 14.025, CardinalPoint.E), 52, 0, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(3, 0, 0, CardinalPoint.E), 58.88888889, 0.736412033, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(6, 0, 0, CardinalPoint.E), 58.88888889, 4.069745367, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(9, 0, 0, CardinalPoint.E), 58.88888889, 7.4030787, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(53, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(11, 0, 0, CardinalPoint.E), 58.88888889, 9.625300922, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(56, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E));
        }
    }
}
