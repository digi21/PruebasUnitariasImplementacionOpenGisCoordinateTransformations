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
    public class Test5210Part7 : VerticalCoordinateSystemTestBase
    {
        [TestMethod]
        public void Test5210_part_7_Epsg()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5705);
            var vertB = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5611);

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_7_WktEpsg()
        {
            IVerticalCoordinateSystem vertA = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Baltic height"",VERT_DATUM[""Baltic Sea"",2005,AUTHORITY[""EPSG"",""5105""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""H"", Up],AUTHORITY[""EPSG"",""5705""]]");
            IVerticalCoordinateSystem vertB = (IVerticalCoordinateSystem)factory.CreateFromWkt(@"VERT_CS[""Caspian height"",VERT_DATUM[""Caspian Sea"",2005,AUTHORITY[""EPSG"",""5106""]],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""H"", Up],AUTHORITY[""EPSG"",""5611""]]");

            ExecuteTests(vertA, vertB);
        }

        [TestMethod]
        public void Test5210_part_7_MathTransform()
        {
            MathTransformFactory mtf = new MathTransformFactory();

            IMathTransform i = mtf.CreateFromWkt(@"PARAM_MT[""vertical_offset"",PARAMETER[""vertical_offset"",28]]");

            ExecuteTests(i);
        }

        protected override void ExecuteTests(IMathTransform d)
        {
            TestDirectTransform(d, 72, 100, 1E-6);
            TestDirectTransform(d, 66.67, 94.67, 1E-6);
            TestDirectTransform(d, 17, 45, 1E-6);
            TestDirectTransform(d, 0, 28, 1E-6);
            TestDirectTransform(d, -28, 0, 1E-6);
            TestDirectTransform(d, -36, -8, 1E-6);
            TestDirectTransform(d, -44.3, -16.3, 1E-6);
            TestDirectTransform(d, -210, -182, 1E-6);
        }
    }
}
