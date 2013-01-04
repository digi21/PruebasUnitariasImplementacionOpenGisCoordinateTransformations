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
    public class Test5210Part2 : VerticalCoordinateSystemTestBase
    {
        [TestMethod]
        public void Test5210_part_2_Epsg()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5611);
            var vertB = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5705);

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_2_WktEpsg()
        {
            IVerticalCoordinateSystem vertA = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Caspian height"",VERT_DATUM[""Caspian Sea"",2005,AUTHORITY[""EPSG"",""5106""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""H"", Up],AUTHORITY[""EPSG"",""5611""]]");
            IVerticalCoordinateSystem vertB = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Baltic height"",VERT_DATUM[""Baltic Sea"",2005,AUTHORITY[""EPSG"",""5105""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""H"", Up],AUTHORITY[""EPSG"",""5705""]]");

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_2_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform d = mtf.CreateFromWkt(@"INVERSE_MT[PARAM_MT[""vertical_offset"",PARAMETER[""vertical_offset"",28]]]");

            ExecuteTests(d);
        }

        protected override void ExecuteTests(IMathTransform d)
        {
            TestDirectTransform(d, 100, 72, 1E-6);
            TestDirectTransform(d, 94.67, 66.67, 1E-6);
            TestDirectTransform(d, 45, 17, 1E-6);
            TestDirectTransform(d, 28, 0, 1E-6);
            TestDirectTransform(d, 0, -28, 1E-6);
            TestDirectTransform(d, -8, -36, 1E-6);
            TestDirectTransform(d, -16.3, -44.3, 1E-6);
            TestDirectTransform(d, -182, -210, 1E-6);
        }
    }
}
