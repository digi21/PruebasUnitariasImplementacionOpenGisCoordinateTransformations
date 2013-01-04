using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digi21.OpenGis.Epsg;
using Digi21.OpenGis.CoordinateTransformations;
using Digi21.OpenGis.CoordinateSystems;

namespace TestDigi21OpenGIS
{
    [TestClass]
    public class Test5210Part10 : VerticalCoordinateSystemTestBase
    {
        //[TestMethod]
        //public void Test5210_part_10()
        //{
        //    var vertA = gigsFactory.CreateVerticalCoordinateSystem("64507");
        //    var vertB = gigsFactory.CreateVerticalCoordinateSystem("64508");

        //    ExecuteTests(vertA, vertB);
        //}

        //[TestMethod]
        //public void Test5210_part_10_Wkt()
        //{
        //    IVerticalCoordinateSystem vertA = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""GIGS vertCRS W1 height"",VERT_DATUM[""GIGS vertical datum W"",2005,AUTHORITY[""GIGS"",""66603""]],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""H"", Up],AUTHORITY[""GIGS"",""64507""]]");
        //    IVerticalCoordinateSystem vertB = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""GIGS vertCRS W1 depth"",VERT_DATUM[""GIGS vertical datum W"",2005,AUTHORITY[""GIGS"",""66603""]],UNIT[""GIGS unit L0 (metre)"",1,AUTHORITY[""GIGS"",""69001""]],AXIS[""D"", Down],AUTHORITY[""GIGS"",""64508""]]");

        //    ExecuteTests(vertA, vertB);
        //}

        [TestMethod]
        public void Test5210_part_10_Epsg()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5612);
            var vertB = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5611);

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_10_WktEpsg()
        {
            IVerticalCoordinateSystem vertA = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Baltic depth"",VERT_DATUM[""Baltic Sea"",2005,AUTHORITY[""EPSG"",""5105""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""D"", Down],AUTHORITY[""EPSG"",""5612""]]");
            IVerticalCoordinateSystem vertB = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Caspian height"",VERT_DATUM[""Caspian Sea"",2005,AUTHORITY[""EPSG"",""5106""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""H"", Up],AUTHORITY[""EPSG"",""5611""]]");

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_10_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform i = mtf.CreateFromWkt(@"CONCAT_MT[PARAM_MT[""Affine"", PARAMETER[""num_row"",2], PARAMETER[""num_col"", 2],PARAMETER[""elt_0_0"", -1],PARAMETER[""elt_0_1"", 0],PARAMETER[""elt_1_0"", 0],PARAMETER[""elt_1_1"", -1]],PARAM_MT[""vertical_offset"",PARAMETER[""vertical_offset"",28]]]");

            ExecuteTests(i);
        }

        protected override void ExecuteTests(IMathTransform d)
        {
            TestDirectTransform(d, -72, 100, 1E-6);
            TestDirectTransform(d, -66.67, 94.67, 1E-6);
            TestDirectTransform(d, -17, 45, 1E-6);
            TestDirectTransform(d, 0, 28, 1E-6);
            TestDirectTransform(d, 28, 0, 1E-6);
            TestDirectTransform(d, 36, -8, 1E-6);
            TestDirectTransform(d, 44.3, -16.3, 1E-6);
            TestDirectTransform(d, 210, -182, 1E-6);
        }
    }
}
