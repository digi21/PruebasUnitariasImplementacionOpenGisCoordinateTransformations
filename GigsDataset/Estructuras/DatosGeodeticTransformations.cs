using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gigs
{
    public struct DatosGeodeticTransformations
    {
        public int Code;
        public string Name { get; set; }
        public int SourceCrsCode { get; set; }
        public string SourceCrsName { get; set; }
        public int TargetCrsCode { get; set; }
        public string TargetCrsName { get; set; }
        public int TfmVariant { get; set; }
        public string EpsgTfmMethodName { get; set; }

        public string Parameter1Name { get; set; }
        public double Parameter1Value { get; set; }
        public int Parameter1Unit { get; set; }

        public string Parameter2Name { get; set; }
        public double Parameter2Value { get; set; }
        public int Parameter2Unit { get; set; }

        public string Parameter3Name { get; set; }
        public double Parameter3Value { get; set; }
        public int Parameter3Unit { get; set; }

        public string Parameter4Name { get; set; }
        public double Parameter4Value { get; set; }
        public int Parameter4Unit { get; set; }

        public string Parameter5Name { get; set; }
        public double Parameter5Value { get; set; }
        public int Parameter5Unit { get; set; }

        public string Parameter6Name { get; set; }
        public double Parameter6Value { get; set; }
        public int Parameter6Unit { get; set; }

        public string Parameter7Name { get; set; }
        public double Parameter7Value { get; set; }
        public int Parameter7Unit { get; set; }

        public string Parameter8Name { get; set; }
        public double Parameter8Value { get; set; }
        public int Parameter8Unit { get; set; }

        public string Parameter9Name { get; set; }
        public double Parameter9Value { get; set; }
        public int Parameter9Unit { get; set; }

        public string Parameter10Name { get; set; }
        public double Parameter10Value { get; set; }
        public int Parameter10Unit { get; set; }
    }
}
