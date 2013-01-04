using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gigs
{
    public struct DatosElipsoide
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double SemiMajorAxis { get; set; }
        public double? SemiMinorAxis { get; set; }
        public double? InverseFlattening { get; set; }
        public int Unit { get; set; }
    }
}
