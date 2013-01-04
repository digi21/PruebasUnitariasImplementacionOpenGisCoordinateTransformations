﻿using System;
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
    public class Test5110Part1 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5110_part_1()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62023");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5110_part_1_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS G16"",GEOGCS[""GIGS geogCRS G"",DATUM[""GIGS geodetic datum G"",SPHEROID[""GIGS ellipsoid F"",6378137,298.257222169001,AUTHORITY[""GIGS"",""67019""]],AUTHORITY[""GIGS"",""66007""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64010""]],PROJECTION[""Lambert_azimuthal_equal_area""],PARAMETER[""latitude_of_center"",51.99999999999995],PARAMETER[""longitude_of_center"",9.999999999999989],PARAMETER[""false_easting"",4321000],PARAMETER[""false_northing"",3210000],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""Y"", NORTH],AXIS[""X"", EAST],AUTHORITY[""GIGS"",""62023""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5110_part_1_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(3035);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5110_part_1_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""ETRS89 / LAEA Europe"",GEOGCS[""ETRS89"",DATUM[""European Terrestrial Reference System 1989"",SPHEROID[""GRS 1980"",6378137,298.257222101,AUTHORITY[""EPSG"",""7019""]],AUTHORITY[""EPSG"",""6258""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4258""]],PROJECTION[""Lambert_Azimuthal_Equal_Area""],PARAMETER[""latitude_of_center"",51.99999999999995],PARAMETER[""longitude_of_center"",9.999999999999989],PARAMETER[""false_easting"",4321000],PARAMETER[""false_northing"",3210000],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314140356],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""Y"", NORTH],AXIS[""X"", EAST],AUTHORITY[""EPSG"",""3035""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5110_part_1_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Lambert_Azimuthal_Equal_Area"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""latitude_of_center"",51.99999999999995],PARAMETER[""longitude_of_center"",9.999999999999989],PARAMETER[""false_easting"",4321000],PARAMETER[""false_northing"",3210000]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],INVERSE_MT[PARAM_MT[""Lambert_Azimuthal_Equal_Area"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""latitude_of_center"",51.99999999999995],PARAMETER[""longitude_of_center"",9.999999999999989],PARAMETER[""false_easting"",4321000],PARAMETER[""false_northing"",3210000]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(70, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 5214090.649, 4127824.658, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(50, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 2999718.853, 3962799.451, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(30, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E), 796781.677, 3830117.902, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(52, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(10, 0, 0, CardinalPoint.E), 3210000, 4321000, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(50, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(3, 0, 0, CardinalPoint.E), 3011432.894, 3819948.288, 1E-3);
            TestDirectTransform(d, Sexa2DecimalDegrees(50, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(8, 0, 0, CardinalPoint.E), 2989464.315, 4177612.521, 1E-3);

            TestInverseTransform(i, Sexa2DecimalDegrees(60, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(5, 00, 00.000, CardinalPoint.E), 4109791.66, 4041548.125, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(40, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(5, 00, 00.000, CardinalPoint.E), 1892578.962, 3892127.02, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(50, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(0, 00, 00.000, CardinalPoint.E), 3036305.967, 3606514.431, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(50, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(5, 00, 00.000, CardinalPoint.E), 2999718.853, 3962799.451, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(50, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(10, 00, 00.000, CardinalPoint.E), 2987510.567, 4321000, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(70, 0, 0, CardinalPoint.N), Sexa2DecimalDegrees(5, 0, 0, CardinalPoint.E));
        }
    }
}
