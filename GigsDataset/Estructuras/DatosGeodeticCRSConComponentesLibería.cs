using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gigs
{
    public struct DatosGeodeticCRSConComponentesLibrería
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public CRS_TYPE CrsType { get; set; }
        public int GigsDatumCode { get; set; }
        public int EpsgCoordinateSystem { get; set; }
    }
}
