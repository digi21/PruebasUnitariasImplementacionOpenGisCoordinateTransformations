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
    public class Test5112Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5112_part_1()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62034");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5112_part_1_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS Y24"",GEOGCS[""GIGS geogCRS Y"",DATUM[""GIGS geodetic datum Y"",SPHEROID[""GIGS ellipsoid Y"",6378245,298.3,AUTHORITY[""GIGS"",""67024""]],AUTHORITY[""GIGS"",""66014""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64017""]],PROJECTION[""Mercator_2SP""],PARAMETER[""standard_parallel_1"",41.99999999999996],PARAMETER[""central_meridian"",50.99999999999995],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378245],PARAMETER[""semi_minor"",6356863.018773047],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""Y"", NORTH],AXIS[""X"", EAST],AUTHORITY[""GIGS"",""62034""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5112_part_1_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(3388);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5112_part_1_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""Pulkovo 1942 / Caspian Sea Mercator"",GEOGCS[""Pulkovo 1942"",DATUM[""Pulkovo 1942"",SPHEROID[""Krassowsky 1940"",6378245,298.3,AUTHORITY[""EPSG"",""7024""]],AUTHORITY[""EPSG"",""6284""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4284""]],PROJECTION[""Mercator_2SP""],PARAMETER[""standard_parallel_1"",41.99999999999996],PARAMETER[""central_meridian"",50.99999999999995],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0],PARAMETER[""semi_major"",6378245],PARAMETER[""semi_minor"",6356863.018773047],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""none"", NORTH],AXIS[""none"", EAST],AUTHORITY[""EPSG"",""3388""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5112_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Mercator_2SP"",PARAMETER[""semi_major"",6378245],PARAMETER[""semi_minor"",6356863.018773047],PARAMETER[""standard_parallel_1"",41.99999999999996],PARAMETER[""central_meridian"",50.99999999999995],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""Mercator_2SP"",PARAMETER[""semi_major"",6378245],PARAMETER[""semi_minor"",6356863.018773047],PARAMETER[""standard_parallel_1"",41.99999999999996],PARAMETER[""central_meridian"",50.99999999999995],PARAMETER[""false_easting"",0],PARAMETER[""false_northing"",0]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(51, 00, 00.000, CardinalPoint.E), 0.00, 0.00, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(20, 30, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(54, 00, 00.000, CardinalPoint.E), 1724781.50, 248556.44, 3E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.S), Sexa2DecimalDegrees(67, 00, 00.000, CardinalPoint.E), -3709687.25, 1325634.35, 3E-2);

            TestInverseTransform(i, Sexa2DecimalDegrees(42, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(51, 00, 00.000, CardinalPoint.E), 3819897.85, 0.00, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(57, 00, 00.000, CardinalPoint.E), 0.00, 497112.88, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(51, 00, 00.000, CardinalPoint.E));
        }
    }
}
