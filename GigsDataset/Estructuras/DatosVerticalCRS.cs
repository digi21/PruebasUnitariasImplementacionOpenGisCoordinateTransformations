using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digi21.OpenGis.CoordinateSystems;

namespace Gigs
{
    public struct DatosVerticalCRS
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int GigsDatumCode { get; set; }
        public int EpsgCsCode { get; set; }
        public string CsAxis1Name { get; set; }
        public string CsAxis1Abbreviation { get; set; }
        public AxisOrientationEnum CsAxis1Orientation { get; set; }
        public int CsAxis1Unit { get; set; }
    }
}
