﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;

namespace Gigs
{
    public struct DatosProjectedCRSConComponentesLibrería
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int BaseCrsCode { get; set; }
        public string BaseCrsName { get; set; }
        public int EPSGProjCode { get; set; }
        public string ProjectionName { get; set; }
        public int CsCode { get; set; }
        public string CsAxis1Name { get; set; }
        public string CsAxis1Abbreviation { get; set; }
        public AxisOrientationEnum Cs1Axis1Orientation { get; set; }
        public int CsAxis1Unit { get; set; }
        public string CsAxis2Name { get; set; }
        public string CsAxis2Abbreviation { get; set; }
        public AxisOrientationEnum CsAxis2Orientation { get; set; }
        public int CsAxis2Unit { get; set; }
    }
}
