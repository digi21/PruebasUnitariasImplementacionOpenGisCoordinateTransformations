using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gigs;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDigi21OpenGIS
{
    public abstract class VerticalCoordinateSystemTestBase
    {
        protected GigsFactory gigsFactory = new GigsFactory();
        protected CoordinateSystemFactory factory = new CoordinateSystemFactory();

        protected void ExecuteTests(IVerticalCoordinateSystem source, IVerticalCoordinateSystem target)
        {
            ExecuteTests(source, target, false);
        }

        protected void ExecuteTests(IVerticalCoordinateSystem source, IVerticalCoordinateSystem target, bool inverse)
        {
            CoordinateTransformationFactory ctf = new CoordinateTransformationFactory();
            ICoordinateTransformation coordinateTransformation = ctf.CreateFromCoordinateSystems(source, target);

            if( inverse )
                ExecuteTests(coordinateTransformation.MathTransform.Inverse);
            else
                ExecuteTests(coordinateTransformation.MathTransform);
        }

        protected abstract void ExecuteTests(IMathTransform t);

        protected void TestDirectTransform(IMathTransform t, double original, double transformated, double sigma)
        {
            double[] transformado = t.Transform(new double[] { original });

            Assert.AreNotEqual(transformado[0], double.NaN);
            Assert.AreNotEqual(transformado[0], double.PositiveInfinity);
            Assert.AreNotEqual(transformado[0], double.NegativeInfinity);
            Assert.AreEqual(transformated, transformado[0], sigma);
        }
    }
}
