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
    public class Test5113Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5113_part_1()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62017");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5113_part_1_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS G10"",GEOGCS[""GIGS geogCRS G"",DATUM[""GIGS geodetic datum G"",SPHEROID[""GIGS ellipsoid F"",6378137,298.257222169001,AUTHORITY[""GIGS"",""67019""]],AUTHORITY[""GIGS"",""66007""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64010""]],PROJECTION[""Transverse_Mercator_South_Orientated""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",20.99999999999998],PARAMETER[""scale_factor"",1],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""Y"", WEST],AXIS[""X"", SOUTH],AUTHORITY[""GIGS"",""62017""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5113_part_1_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(2049);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5113_part_1_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""Hartebeesthoek94 / Lo21"",GEOGCS[""Hartebeesthoek94"",DATUM[""Hartebeesthoek94"",SPHEROID[""WGS 84"",6378137,298.257223563,AUTHORITY[""EPSG"",""7030""]],AUTHORITY[""EPSG"",""6148""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4148""]],PROJECTION[""Transverse_Mercator_South_Orientated""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",20.99999999999998],PARAMETER[""scale_factor"",1],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314245179],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""Y"", WEST],AXIS[""X"", SOUTH],AUTHORITY[""EPSG"",""2049""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5113_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Transverse_Mercator_South_Orientated"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",20.99999999999998],PARAMETER[""scale_factor"",1],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[INVERSE_MT[PARAM_MT[""Transverse_Mercator_South_Orientated"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",20.99999999999998],PARAMETER[""scale_factor"",1],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(0, 00, 0, CardinalPoint.N), Sexa2DecimalDegrees(22, 30, 0, CardinalPoint.E), -166998.442, 0, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(30, 00, 0, CardinalPoint.S), Sexa2DecimalDegrees(20, 30, 0, CardinalPoint.E), 48243.449, 3320218.65, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(35, 00, 0, CardinalPoint.S), Sexa2DecimalDegrees(19, 30, 0, CardinalPoint.E), 136937.651, 3875621.182, 1E-3);

            TestInverseTransform(i, Sexa2DecimalDegrees(25, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(21, 30, 00.000, CardinalPoint.E), -50475.46, 2766147.248, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(35, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(19, 30, 00.000, CardinalPoint.E), 136937.651, 3875621.182, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(0, 00, 0, CardinalPoint.N), Sexa2DecimalDegrees(22, 30, 0, CardinalPoint.E));
        }
    }
}
