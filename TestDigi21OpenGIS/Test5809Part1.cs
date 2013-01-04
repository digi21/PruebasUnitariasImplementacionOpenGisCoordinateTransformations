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
    public class Test5209Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5209_part_1()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateParameterizedTransform("P6", new[] {
                    new Parameter("map_grid_bearing_of_bin_grid_j_axis", 20),
                    new Parameter("bin_width_of_i_axis", 25),
                    new Parameter("bin_width_of_j_axis", 12.5),
                    new Parameter("bin_node_increment_on_i_axis", 2),
                    new Parameter("bin_node_increment_on_j_axis", 2),
                    new Parameter("scale_factor", 1),
                    new Parameter("bin_grid_origin_easting", 414188.46),
                    new Parameter("bin_grid_origin_northing", 5761775.889),
                    new Parameter("bin_grid_origin_i", 1),
                    new Parameter("bin_grid_origin_j", 10000),
                });

            IMathTransform i = d.Inverse;

            ExecuteTests(d, i);
        }

        [TestMethod]
        public void Test5209_part_1_Wkt()
        {
            MathTransformFactory mtf = new MathTransformFactory();
            IMathTransform d = mtf.CreateFromWkt(@"PARAM_MT[""p6"",PARAMETER[""bin_grid_origin_i"",1],PARAMETER[""bin_grid_origin_j"",10000],PARAMETER[""bin_grid_origin_easting"",414188.46],PARAMETER[""bin_grid_origin_northing"",5761775.889],PARAMETER[""scale_factor"",1],PARAMETER[""bin_width_of_i_axis"",25],PARAMETER[""bin_width_of_j_axis"",12.5],PARAMETER[""map_grid_bearing_of_bin_grid_j_axis"",20],PARAMETER[""bin_node_increment_on_i_axis"",2],PARAMETER[""bin_node_increment_on_j_axis"",2]]");
            IMathTransform i = mtf.CreateFromWkt(@"INVERSE_MT[PARAM_MT[""p6"",PARAMETER[""bin_grid_origin_i"",1],PARAMETER[""bin_grid_origin_j"",10000],PARAMETER[""bin_grid_origin_easting"",414188.46],PARAMETER[""bin_grid_origin_northing"",5761775.889],PARAMETER[""scale_factor"",1],PARAMETER[""bin_width_of_i_axis"",25],PARAMETER[""bin_width_of_j_axis"",12.5],PARAMETER[""map_grid_bearing_of_bin_grid_j_axis"",20],PARAMETER[""bin_node_increment_on_i_axis"",2],PARAMETER[""bin_node_increment_on_j_axis"",2]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, 1, 21200, 438129.87, 5827554.372, 1E-3);
            TestDirectTransform(d, 8001, 21200, 532099.1321, 5793352.358, 1E-3);
            TestDirectTransform(d, 1, 10000, 414188.46, 5761775.889, 1E-3);
            TestDirectTransform(d, 8001, 10000, 508157.7221, 5727573.875, 1E-3);

            TestInverseTransform(i, 5406.044399, 20442.91044, 500000, 5800000, 1E-3);
            TestInverseTransform(i, -2111.496567, 14970.58815, 400000, 5800000, 1E-3);
            TestInverseTransform(i, 4383.435063, 2671.667361, 450000, 5700000, 1E-3);
            TestInverseTransform(i, 3360.825726, -15099.57572, 400000, 5600000, 1E-3);

            ExecuteIterations(d, i, 1, 21200);
        }
    }
}
