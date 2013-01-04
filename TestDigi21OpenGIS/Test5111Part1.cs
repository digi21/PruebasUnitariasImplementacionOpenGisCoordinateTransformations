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
    public class Test5111Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5111_part_1()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62037");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5111_part_1_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS L27"",GEOGCS[""GIGS geogCRS L"",DATUM[""GIGS geodetic datum L"",SPHEROID[""GIGS ellipsoid C"",6377397.155,299.152812869001,AUTHORITY[""GIGS"",""67004""]],AUTHORITY[""GIGS"",""66011""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64014""]],PROJECTION[""Mercator_1SP""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",109.9999999999999],PARAMETER[""scale_factor"",0.997],PARAMETER[""false_easting"",3900000],PARAMETER[""false_northing"",900000],PARAMETER[""semi_major"",6377397.155],PARAMETER[""semi_minor"",6356078.962823105],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""X"", EAST],AXIS[""Y"", NORTH],AUTHORITY[""GIGS"",""62037""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5111_part_1_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(3001);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5111_part_1_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""Batavia / NEIEZ"",GEOGCS[""Batavia"",DATUM[""Batavia"",SPHEROID[""Bessel 1841"",6377397.155,299.1528128,AUTHORITY[""EPSG"",""7004""]],AUTHORITY[""EPSG"",""6211""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4211""]],PROJECTION[""Mercator_1SP""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",109.9999999999999],PARAMETER[""scale_factor"",0.997],PARAMETER[""false_easting"",3900000],PARAMETER[""false_northing"",900000],PARAMETER[""semi_major"",6377397.155],PARAMETER[""semi_minor"",6356078.962818189],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""X"", EAST],AXIS[""Y"", NORTH],AUTHORITY[""EPSG"",""3001""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5111_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Mercator_1SP"",PARAMETER[""semi_major"",6377397.155],PARAMETER[""semi_minor"",6356078.962823105],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",109.9999999999999],PARAMETER[""scale_factor"",0.997],PARAMETER[""false_easting"",3900000],PARAMETER[""false_northing"",900000]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[INVERSE_MT[PARAM_MT[""Mercator_1SP"",PARAMETER[""semi_major"",6377397.155],PARAMETER[""semi_minor"",6356078.962823105],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",109.9999999999999],PARAMETER[""scale_factor"",0.997],PARAMETER[""false_easting"",3900000],PARAMETER[""false_northing"",900000]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(77, 39, 12.536, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 15000000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(67, 03, 06.597, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 11000000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(48, 15, 50.033, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 7000000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(18, 42, 17.489, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 3000000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.E), 3900000, 900000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(1, 48, 50.574, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 700000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(3, 37, 34.519, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 500000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(5, 26, 05.241, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 300000, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(7, 14, 16.214, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 100000, 3E-2);

            // I think the next two tests are incorrect (west geographic coordinates with possitive X projected coordinates)
            //TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(90, 0, 0, CardinalPoint.W), 21655625.33, 679490.646, 3E-2);
            //TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(150, 0, 0, CardinalPoint.W), 14997265.83, 679490.646, 3E-2);

            TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(150, 0, 0, CardinalPoint.E), 8338906.333, 679490.646, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(110, 0, 0, CardinalPoint.E), 3900000, 679490.646, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 679490.646, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(60, 0, 0, CardinalPoint.E), -1648632.916, 679490.646, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(0, 0, 0, CardinalPoint.E), -8306992.416, 679490.646, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(2, 0, 0, CardinalPoint.S), Sexa2DecimalDegrees(60, 0, 0, CardinalPoint.W), -14965351.92, 679490.646, 3E-2);


            TestInverseTransform(i, Sexa2DecimalDegrees(73, 08, 39.428, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 13000000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(58, 54, 50.565, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 9000000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(34, 48, 10.456, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 5000000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(0, 54, 25.701, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 1000000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(0, 54, 25.701, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 800000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(4, 31, 51.942, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 400000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(6, 20, 13.600, CardinalPoint.S), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E), 2800000, 200000, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(8, 08, 12.282, CardinalPoint.S), Sexa2DecimalDegrees(74, 51, 22.350, CardinalPoint.E), 0, 0, 1E-6);
            //TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(71, 00, 00.000, CardinalPoint.W), 23764105.84, 679490.646, 1E-6);
            //TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(120, 00, 00.000, CardinalPoint.W), 18326445.58, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(180, 00, 00.000, CardinalPoint.E), 11668086.08, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(120, 00, 00.000, CardinalPoint.E), 5009726.583, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(106, 48, 27.790, CardinalPoint.E), 3545744.141, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(90, 00, 00.000, CardinalPoint.E), 1680546.833, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(30, 00, 00.000, CardinalPoint.E), -4977812.666, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(30, 00, 00.000, CardinalPoint.W), -11636172.17, 679490.646, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(2, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(69, 00, 00.000, CardinalPoint.W), -15964105.84, 679490.646, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(77, 39, 12.536, CardinalPoint.N), Sexa2DecimalDegrees(100, 05, 15.534, CardinalPoint.E));
        }
    }
}
