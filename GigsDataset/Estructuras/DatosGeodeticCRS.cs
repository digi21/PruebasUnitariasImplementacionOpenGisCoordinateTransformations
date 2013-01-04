using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gigs
{
    public struct DatosGeodeticCRS
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public CRS_TYPE CrsType { get; set; }
        public int DatumCode { get; set; }
        public int EPSGCoordinateSystem { get; set; }
        public bool? AxesChanged { get; set; }
        public bool? UnitsAreGrads { get; set; }
    }
}
