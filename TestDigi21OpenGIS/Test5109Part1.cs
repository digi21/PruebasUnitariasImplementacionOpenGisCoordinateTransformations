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
    public class Test5109Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5109_part_1()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62016");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5109_part_1_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS F9"",GEOGCS[""GIGS geogCRS F"",DATUM[""GIGS geodetic datum F"",SPHEROID[""GIGS ellipsoid F"",6378137,298.257222169001,AUTHORITY[""GIGS"",""67019""]],AUTHORITY[""GIGS"",""66006""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64009""]],PROJECTION[""Albers_Conic_Equal_Area""],PARAMETER[""latitude_of_center"",0],PARAMETER[""longitude_of_center"",131.9999999999999],PARAMETER[""standard_parallel1"",-17.99999999999998],PARAMETER[""standard_parallel2"",-35.99999999999996],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""E"", EAST],AXIS[""N"", NORTH],AUTHORITY[""GIGS"",""62016""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5109_part_1_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(3577);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5109_part_1_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GDA94 / Australian Albers"",GEOGCS[""GDA94"",DATUM[""Geocentric Datum of Australia 1994"",SPHEROID[""GRS 1980"",6378137,298.257222101,AUTHORITY[""EPSG"",""7019""]],AUTHORITY[""EPSG"",""6283""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4283""]],PROJECTION[""Albers_Conic_Equal_Area""],PARAMETER[""latitude_of_center"",0],PARAMETER[""longitude_of_center"",131.9999999999999],PARAMETER[""standard_parallel1"",-17.99999999999998],PARAMETER[""standard_parallel2"",-35.99999999999996],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314140356],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""E"", EAST],AXIS[""N"", NORTH],AUTHORITY[""EPSG"",""3577""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5109_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Albers_Conic_Equal_Area"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""standard_parallel1"",-17.99999999999998],PARAMETER[""standard_parallel2"",-35.99999999999996],PARAMETER[""latitude_of_center"",0],PARAMETER[""longitude_of_center"",131.9999999999999],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[INVERSE_MT[PARAM_MT[""Albers_Conic_Equal_Area"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""standard_parallel1"",-17.99999999999998],PARAMETER[""standard_parallel2"",-35.99999999999996],PARAMETER[""latitude_of_center"",0],PARAMETER[""longitude_of_center"",131.9999999999999],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(27, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(132, 00, 00.000, CardinalPoint.E), 0, -2926820.89, 1E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(20, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 832799.36, -2170181.926, 1E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 567313.287, -6404311.163, 1E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(130, 00, 00.000, CardinalPoint.E), -141915.257, -6387653.78, 1E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(150, 00, 00.000, CardinalPoint.E), 1273067.747, -6476375.276, 1E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(170, 00, 00.000, CardinalPoint.E), 2656914.716, -6784621.89, 1E-2);

            TestInverseTransform(i, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(132, 00, 00.000, CardinalPoint.E), 0, 0, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 966973.979, -30285.601, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(40, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 693250.209, -4395794.489, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(80, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 486878.674, -7687130.029, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(120, 00, 00.000, CardinalPoint.E), -850274.747, -6426505.132, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(140, 00, 00.000, CardinalPoint.E), 567313.287, -6404311.163, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(160, 00, 00.000, CardinalPoint.E), 1971026.264, -6603404.818, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(27, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(132, 00, 00.000, CardinalPoint.E));
        }
    }
}
