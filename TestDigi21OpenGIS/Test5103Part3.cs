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
    public class Test5103Part3 : MapProjectionTestBase
    {
        [TestMethod]
        public void Test5103_part_3()
        {
            IProjectedCoordinateSystem pcs = gigsFactory.CreateProjectedCoordinateSystem("62025");
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5103_part_3_Wkt()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""GIGS projCRS G18"",GEOGCS[""GIGS geogCRS G"",DATUM[""GIGS geodetic datum G"",SPHEROID[""GIGS ellipsoid F"",6378137,298.257222169001,AUTHORITY[""GIGS"",""67019""]],AUTHORITY[""GIGS"",""66007""]],PRIMEM[""GIGS PM A"",0,AUTHORITY[""GIGS"",""68901""]],UNIT[""GIGS unit A2 (degree)"",0.01745329251994328,AUTHORITY[""GIGS"",""69102""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""GIGS"",""64010""]],PROJECTION[""Lambert_Conformal_Conic_2SP""],PARAMETER[""latitude_of_origin"",40.33333329999996],PARAMETER[""central_meridian"",-111.4999999999999],PARAMETER[""standard_parallel1"",41.78333329999996],PARAMETER[""standard_parallel2"",40.71666669999996],PARAMETER[""false_easting"",500000.0001016001],PARAMETER[""false_northing"",999999.9998983998],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],UNIT[""GIGS unit L3 (US survey foot)"",0.3048006096012192,AUTHORITY[""GIGS"",""69003""]],AXIS[""X"", EAST],AXIS[""Y"", NORTH],AUTHORITY[""GIGS"",""62025""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;
            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5103_part_3_Epsg()
        {
            IProjectedCoordinateSystem pcs = CoordinateSystemAuthorityFactory.CreateProjectedCoordinateSystem(3568);
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5103_part_3_WktEpsg()
        {
            ICoordinateSystem cs = factory.CreateFromWkt(@"PROJCS[""NAD83(HARN) / Utah North (ftUS)"",GEOGCS[""NAD83(HARN)"",DATUM[""NAD83 (High Accuracy Regional Network)"",SPHEROID[""GRS 1980"",6378137,298.257222101,AUTHORITY[""EPSG"",""7019""]],AUTHORITY[""EPSG"",""6152""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree (supplier to define representation)"",0.01745329251994328,AUTHORITY[""EPSG"",""9122""]],AXIS[""Lat"", NORTH],AXIS[""Long"", EAST],AUTHORITY[""EPSG"",""4152""]],PROJECTION[""Lambert_Conformal_Conic_2SP""],PARAMETER[""latitude_of_origin"",40.33333333333334],PARAMETER[""central_meridian"",-111.5],PARAMETER[""standard_parallel1"",41.78333333333333],PARAMETER[""standard_parallel2"",40.71666666666667],PARAMETER[""false_easting"",500000.0000101601],PARAMETER[""false_northing"",999999.9999898401],PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314140356],UNIT[""US survey foot"",0.3048006096012192,AUTHORITY[""EPSG"",""9003""]],AXIS[""X"", EAST],AXIS[""Y"", NORTH],AUTHORITY[""EPSG"",""3568""]]");

            IProjectedCoordinateSystem pcs = cs as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem gcs = pcs.GeographicCoordinateSystem;

            ExecuteTests(gcs, pcs);
        }

        [TestMethod]
        public void Test5103_part_3_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]],PARAM_MT[""Lambert_Conformal_Conic_2SP"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""standard_parallel1"",41.78333329999996],PARAMETER[""standard_parallel2"",40.71666669999996],PARAMETER[""latitude_of_origin"",40.33333329999996],PARAMETER[""central_meridian"",-111.4999999999999],PARAMETER[""false_easting"",500000.0001016001],PARAMETER[""false_northing"",999999.9998983998]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",3.280833333333334],PARAMETER[""elt_0_1"",0],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",0],PARAMETER[""elt_1_1"",3.280833333333334],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",3.280833333333334]]]");
            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0.3048006096012192],PARAMETER[""elt_0_1"",0],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",0],PARAMETER[""elt_1_1"",0.3048006096012192],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",0.3048006096012192]],INVERSE_MT[PARAM_MT[""Lambert_Conformal_Conic_2SP"",PARAMETER[""semi_major"",6378137],PARAMETER[""semi_minor"",6356752.314145231],PARAMETER[""standard_parallel1"",41.78333329999996],PARAMETER[""standard_parallel2"",40.71666669999996],PARAMETER[""latitude_of_origin"",40.33333329999996],PARAMETER[""central_meridian"",-111.4999999999999],PARAMETER[""false_easting"",500000.0001016001],PARAMETER[""false_northing"",999999.9998983998]]],PARAM_MT[""Affine"",PARAMETER[""num_row"",3],PARAMETER[""num_col"",3],PARAMETER[""elt_0_0"",0],PARAMETER[""elt_0_1"",1],PARAMETER[""elt_0_2"",0],PARAMETER[""elt_1_0"",1],PARAMETER[""elt_1_1"",0],PARAMETER[""elt_1_2"",0],PARAMETER[""elt_2_0"",0],PARAMETER[""elt_2_1"",0],PARAMETER[""elt_2_2"",1]]]");

            ExecuteTests(d, i);
        }

        protected override void ExecuteTests(IMathTransform d, IMathTransform i)
        {
            TestDirectTransform(d, Sexa2DecimalDegrees(47, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2016617.897, 5717717.179, 2E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(43, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2041850.997, 4256081.225, 2E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2054432.46, 3527295.672, 2E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(106, 00, 00.000, CardinalPoint.W), 3157536.542, 3571750.248, 2E-2);
            TestDirectTransform(d, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(102, 00, 00.000, CardinalPoint.W), 4257426.541, 3666917.555, 2E-2);

            TestInverseTransform(i, Sexa2DecimalDegrees(49, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2003933.266, 6452478.797, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(45, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2029251.514, 4985910.592, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W), 2054432.46, 3527295.672, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(108, 00, 00.000, CardinalPoint.W), 2606240.302, 3543175.461, 1E-6);
            TestInverseTransform(i, Sexa2DecimalDegrees(41, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(104, 00, 00.000, CardinalPoint.W), 3708029.155, 3613004.897, 1E-6);

            ExecuteIterations(d, i, Sexa2DecimalDegrees(47, 00, 00.000, CardinalPoint.N), Sexa2DecimalDegrees(110, 00, 00.000, CardinalPoint.W));
        }
    }
}
