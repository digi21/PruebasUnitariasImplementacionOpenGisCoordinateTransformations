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
    public class TestEPSGVerticalOffsetPart1 : VerticalCoordinateSystemTestBase
    {
        [TestMethod]
        public void TestEPSGVerticalOffset_part_1()
        {
            var vertA = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5790);
            var vertB = CoordinateSystemAuthorityFactory.CreateVerticalCoordinateSystem(5614);

            ExecuteTests(vertA, vertB);
        }

        protected override void ExecuteTests(IMathTransform d)
        {
            TestDirectTransform(d, 2.55, 7.18, 1E-2);
        }
    }
}
