using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;

namespace Gigs
{
    public static class GIGSDataSet
    {
        public static DatosLongitud[] longitudes = new[]
            {
                new DatosLongitud {Code=69001, Name="GIGS unit L0 (metre)", MetersPerUnit=1.0},
                new DatosLongitud {Code=69036, Name="GIGS unit L1 (kilometre)", MetersPerUnit=1000.0},
                new DatosLongitud {Code=69002, Name="GIGS unit L2 (foot)", MetersPerUnit=0.3048},
                new DatosLongitud {Code=69003, Name="GIGS unit L3 (US survey foot)", MetersPerUnit=0.30480060960121920243840487680975/*0.30480061*/},
                new DatosLongitud {Code=69031, Name="GIGS unit L4 (German legal metre)", MetersPerUnit=1.000013597},
                new DatosLongitud {Code=69005, Name="GIGS unit L5 (Clarke's foot)", MetersPerUnit=0.304797265},
                new DatosLongitud {Code=69039, Name="GIGS unit L6 (Clarke's link)", MetersPerUnit=0.201166195},
                new DatosLongitud {Code=69042, Name="GIGS unit L7 (British chain (Sears 1922))", MetersPerUnit=20.11676512},
                new DatosLongitud {Code=69041, Name="GIGS unit L8 (British foot (Sears 1922))", MetersPerUnit=0.304799472},
                new DatosLongitud {Code=69040, Name="GIGS unit L9 (British yard (Sears 1922))", MetersPerUnit=0.914398415},
                new DatosLongitud {Code=69301, Name="GIGS unit L10 (British chain (Sears 1922 truncated))", MetersPerUnit=20.116756},
                new DatosLongitud {Code=69084, Name="GIGS unit L11 (Indian yard )", MetersPerUnit=0.914398531},
                new DatosLongitud {Code=69094, Name="GIGS unit L12 (Gold Coast foot)", MetersPerUnit=0.30479971},
                new DatosLongitud {Code=69098, Name="GIGS unit L13 (link)", MetersPerUnit=0.201168}
            };

        public static DatosÁngulos[] ángulos = new[]
            {
                new DatosÁngulos {Code=69101, Name="GIGS unit A0 (radian)", RadiansPerUnit=1.0},
                new DatosÁngulos {Code=69109, Name="GIGS unit A1 (microradian)",RadiansPerUnit=0.000001},
                new DatosÁngulos {Code=69102, Name="GIGS unit A2 (degree)", RadiansPerUnit=0.01745329251994327777777777777778/*0.017453293*/},
                new DatosÁngulos {Code=69104, Name="GIGS unit A3 (arc-second)", RadiansPerUnit=4.85E-06},
                new DatosÁngulos {Code=69105, Name="GIGS unit A4 (grad)", RadiansPerUnit=0.01570796326794895/*0.015707963*/},
                new DatosÁngulos {Code=69113, Name="GIGS unit A5 (centesimal second)", RadiansPerUnit=1.57E-06}
            };

        public static DatosEscala[] escalas = new[]
            {
                new DatosEscala {Code=69201, Name="GIGS unit U0 (=9201)", PartsPerUnit=1.0},
                new DatosEscala {Code=69202, Name="GIGS unit U1 (parts per million)", PartsPerUnit=0.000001}
            };

        public static DatosElipsoide[] elipsoides = new[]
            {
                new DatosElipsoide { Code=67030, Name="GIGS ellipsoid A",SemiMajorAxis=6378137.000,Unit=69001, InverseFlattening=298.2572236},
                new DatosElipsoide{ Code=67001, Name="GIGS ellipsoid B",SemiMajorAxis=6377563.396,Unit=69001, InverseFlattening=299.324964669001},
                new DatosElipsoide { Code=67004, Name="GIGS ellipsoid C",SemiMajorAxis=6377397.155,Unit=69001, InverseFlattening=299.152812869001},
                new DatosElipsoide { Code=67022, Name="GIGS ellipsoid E",SemiMajorAxis=6378388.000,Unit=69001, InverseFlattening=297},
                new DatosElipsoide { Code=67019, Name="GIGS ellipsoid F",SemiMajorAxis=6378.137000,Unit=69036, InverseFlattening=298.257222169001},
                new DatosElipsoide { Code=67011, Name="GIGS ellipsoid H",SemiMajorAxis=6378249.200,Unit=69001, SemiMinorAxis=6356515},
                new DatosElipsoide { Code=67052, Name="GIGS ellipsoid I",SemiMajorAxis=6370997.000,Unit=69001, SemiMinorAxis=6370997.000},
                new DatosElipsoide { Code=67008, Name="GIGS ellipsoid J",SemiMajorAxis=20925832.16,Unit=69003, InverseFlattening=294.978698269001},
                new DatosElipsoide { Code=67036, Name="GIGS ellipsoid K",SemiMajorAxis=6378160.000,Unit=69001, InverseFlattening=298.247167469001},
                new DatosElipsoide { Code=67003, Name="GIGS ellipsoid X",SemiMajorAxis=6378160.000,Unit=69001, InverseFlattening=298.2569001},
                new DatosElipsoide { Code=67024, Name="GIGS ellipsoid Y",SemiMajorAxis=6378245.000,Unit=69001, InverseFlattening=298.3},
            };

        public static DatosMeridiano[] meridianos = new[]
            {
                new DatosMeridiano { Code=68901, Name="GIGS PM A", Unit=69102, LongitudeFromGreenwich=0.0 },
                new DatosMeridiano { Code=68908, Name="GIGS PM D", Unit=69102, LongitudeFromGreenwich=106.8077194},
                new DatosMeridiano { Code=68903, Name="GIGS PM H", Unit=69105, LongitudeFromGreenwich=2.33722917},
                new DatosMeridiano { Code=68904, Name="GIGS PM I", Unit=69102, LongitudeFromGreenwich=-73.91908333}
            };

        public static DatosDatum[] datum = new[]
            {
                new DatosDatum { Code=66001, Name="GIGS geodetic datum A", EllipsoidName="GIGS ellipsoid A", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66002, Name="GIGS geodetic datum B", EllipsoidName="GIGS ellipsoid B", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66003, Name="GIGS geodetic datum C", EllipsoidName="GIGS ellipsoid C", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66004, Name="GIGS geodetic datum D", EllipsoidName="GIGS ellipsoid C", PrimeMeridianName="GIGS PM D", Origin="" },
                new DatosDatum { Code=66005, Name="GIGS geodetic datum E", EllipsoidName="GIGS ellipsoid E", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66006, Name="GIGS geodetic datum F", EllipsoidName="GIGS ellipsoid F", PrimeMeridianName="GIGS PM A", Origin="F" },
                new DatosDatum { Code=66007, Name="GIGS geodetic datum G", EllipsoidName="GIGS ellipsoid F", PrimeMeridianName="GIGS PM A", Origin="G" },
                new DatosDatum { Code=66008, Name="GIGS geodetic datum H", EllipsoidName="GIGS ellipsoid H", PrimeMeridianName="GIGS PM H", Origin="" },
                new DatosDatum { Code=66009, Name="GIGS geodetic datum J", EllipsoidName="GIGS ellipsoid J", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66012, Name="GIGS geodetic datum K", EllipsoidName="GIGS ellipsoid K", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66011, Name="GIGS geodetic datum L", EllipsoidName="GIGS ellipsoid C", PrimeMeridianName="GIGS PM A", Origin="L" },
                new DatosDatum { Code=66016, Name="GIGS geodetic datum M", EllipsoidName="GIGS ellipsoid E", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66010, Name="GIGS geodetic datum T", EllipsoidName="GIGS ellipsoid H", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66013, Name="GIGS geodetic datum X", EllipsoidName="GIGS ellipsoid X", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66014, Name="GIGS geodetic datum Y", EllipsoidName="GIGS ellipsoid Y", PrimeMeridianName="GIGS PM A", Origin="" },
                new DatosDatum { Code=66015, Name="GIGS geodetic datum Z", EllipsoidName="GIGS ellipsoid F", PrimeMeridianName="GIGS PM A", Origin="Z" }
            };

        public static DatosDatumConComponenetesLibrería[] datumLibraryComponents = new[]
            {
                new DatosDatumConComponenetesLibrería { Code=66326, Name="GIGS geodetic datum AA", EllipsoidEpsgName="WGS 84", PrimeMeridianEpsgName="Greenwich" },
                new DatosDatumConComponenetesLibrería { Code=66277, Name="GIGS geodetic datum BB", EllipsoidEpsgName="Airy 1830", PrimeMeridianEpsgName="Greenwich" },
                new DatosDatumConComponenetesLibrería { Code=66289, Name="GIGS geodetic datum CC", EllipsoidEpsgName="Bessel 1841", PrimeMeridianEpsgName="Greenwich" },
                new DatosDatumConComponenetesLibrería { Code=66813, Name="GIGS geodetic datum DD", EllipsoidEpsgName="Bessel 1841", PrimeMeridianEpsgName="Jakarta" },
                new DatosDatumConComponenetesLibrería { Code=66313, Name="GIGS geodetic datum EE", EllipsoidEpsgName="International 1924", PrimeMeridianEpsgName="Greenwich" },
                new DatosDatumConComponenetesLibrería { Code=66283, Name="GIGS geodetic datum FF", EllipsoidEpsgName="GRS 1980", PrimeMeridianEpsgName="Greenwich" },
                new DatosDatumConComponenetesLibrería { Code=66807, Name="GIGS geodetic datum HH", EllipsoidEpsgName="Clarke 1880 (IGN)", PrimeMeridianEpsgName="Paris" },
                new DatosDatumConComponenetesLibrería { Code=66269, Name="GIGS geodetic datum ZZ", EllipsoidEpsgName="GRS 1980", PrimeMeridianEpsgName="Greenwich" }
            };

        public static DatosGeodeticCRS[] geodeticCRS = new[]
            {
                new DatosGeodeticCRS { Code=64001, Name="GIGS geocenCRS A", CrsType=CRS_TYPE.Geocentric, DatumCode=66001, EPSGCoordinateSystem=6500 },
                new DatosGeodeticCRS { Code=64002, Name="GIGS geog3DCRS A", CrsType=CRS_TYPE.Geographic_3D, DatumCode=66001,EPSGCoordinateSystem=6423 },
                new DatosGeodeticCRS { Code=64003, Name="GIGS geogCRS A",CrsType=CRS_TYPE.Geographic_2D, DatumCode=66001,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64004, Name="GIGS geogCRS Alonlat",CrsType=CRS_TYPE.Geographic_2D,DatumCode=66001,EPSGCoordinateSystem=6424, AxesChanged=true },
                new DatosGeodeticCRS { Code=64033, Name="GIGS geogCRS Agr", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66001,EPSGCoordinateSystem=6403 },
                new DatosGeodeticCRS { Code=64019, Name="GIGS geog3DCRS B", CrsType=CRS_TYPE.Geographic_3D, DatumCode=66002,EPSGCoordinateSystem=6423 },
                new DatosGeodeticCRS { Code=64005, Name="GIGS geogCRS B", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66002,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64021, Name="GIGS geog3DCRS C", CrsType=CRS_TYPE.Geographic_3D, DatumCode=66003,EPSGCoordinateSystem=6423 },
                new DatosGeodeticCRS { Code=64006, Name="GIGS geogCRS C", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66003,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64007, Name="GIGS geogCRS D", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66004,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64022, Name="GIGS geog3DCRS E", CrsType=CRS_TYPE.Geographic_3D, DatumCode=66005,EPSGCoordinateSystem=6423 },
                new DatosGeodeticCRS { Code=64008, Name="GIGS geogCRS E", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66005,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64009, Name="GIGS geogCRS F", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66006,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64010, Name="GIGS geogCRS G", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66007,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64011, Name="GIGS geogCRS H", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66008,EPSGCoordinateSystem=6403 },
                new DatosGeodeticCRS { Code=64012, Name="GIGS geogCRS J", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66009,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64015, Name="GIGS geogCRS K", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66012,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64014, Name="GIGS geogCRS L", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66011,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64020, Name="GIGS geogCRS M", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66016,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64013, Name="GIGS geogCRS T", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66010,EPSGCoordinateSystem=6403 },
                new DatosGeodeticCRS { Code=64016, Name="GIGS geogCRS X", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66013,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64017, Name="GIGS geogCRS Y", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66014,EPSGCoordinateSystem=6422 },
                new DatosGeodeticCRS { Code=64018, Name="GIGS geogCRS Z", CrsType=CRS_TYPE.Geographic_2D, DatumCode=66015,EPSGCoordinateSystem=6422 }
            };

        public static DatosGeodeticCRSConComponentesLibrería[] geodeticCRSLibraryComponents = new[]
            {
                new DatosGeodeticCRSConComponentesLibrería { Code=64326, Name="GIGS geogCRS AA", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66326, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64277, Name="GIGS geogCRS BB", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66277, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64289, Name="GIGS geogCRS CC", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66289, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64813, Name="GIGS geogCRS DD", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66813, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64313, Name="GIGS geogCRS EE", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66313, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64283, Name="GIGS geogCRS FF", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66283, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64807, Name="GIGS geogCRS HH", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66807, EpsgCoordinateSystem=6422},
                new DatosGeodeticCRSConComponentesLibrería { Code=64269, Name="GIGS geogCRS ZZ", CrsType=CRS_TYPE.Geographic_2D, GigsDatumCode=66269, EpsgCoordinateSystem=6422}
            };

        public static DatosProjectedCRS[] userProjectedCRS = new[]
            {
                new DatosProjectedCRS { Code=62001, Name="GIGS projCRS A1",   BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="N", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62002, Name="GIGS projCRS A1-2", BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4500, CsAxis1Name="Northing", CsAxis1Abbreviation="N", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="E",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62003, Name="GIGS projCRS A1-3", BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62004, Name="GIGS projCRS A1-4", BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4532, CsAxis1Name="Northing", CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62005, Name="GIGS projCRS A1-5", BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4498, CsAxis1Name="Easting",  CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62006, Name="GIGS projCRS A1-6", BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65001, ProjectionName="GIGS projection 1",        EpsgCsCode=4530, CsAxis1Name="Northing", CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62007, Name="GIGS projCRS A2",   BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65002, ProjectionName="GIGS projection 2",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62008, Name="GIGS projCRS A21",  BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65021, ProjectionName="GIGS projection 2 alt A",  EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62027, Name="GIGS projCRS A23",  BaseCrsCode=64003, BaseCrsName="GIGS geogCRS A", ProjCode=65023, ProjectionName="GIGS projection 23",       EpsgCsCode=4497, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69003, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69003 },
                //new DatosProjectedCRS { Code=62009, Name="GIGS projCRS B2",   BaseCrsCode=64005, BaseCrsName="GIGS geogCRS B", ProjCode=61002, ProjectionName="GIGS projection 2",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                //new DatosProjectedCRS { Code=62010, Name="GIGS projCRS B22",  BaseCrsCode=64005, BaseCrsName="GIGS geogCRS B", ProjCode=61022, ProjectionName="GIGS projection 2 alt B",  EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62011, Name="GIGS projCRS C4",   BaseCrsCode=64006, BaseCrsName="GIGS geogCRS C", ProjCode=65004, ProjectionName="GIGS projection 4",        EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62012, Name="GIGS projCRS D5",   BaseCrsCode=64007, BaseCrsName="GIGS geogCRS D", ProjCode=65005, ProjectionName="GIGS projection 5",        EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62013, Name="GIGS projCRS E6",   BaseCrsCode=64008, BaseCrsName="GIGS geogCRS E", ProjCode=65006, ProjectionName="GIGS projection 6",        EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62014, Name="GIGS projCRS F7",   BaseCrsCode=64009, BaseCrsName="GIGS geogCRS F", ProjCode=65007, ProjectionName="GIGS projection 7",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62015, Name="GIGS projCRS F8",   BaseCrsCode=64009, BaseCrsName="GIGS geogCRS F", ProjCode=65008, ProjectionName="GIGS projection 8",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62016, Name="GIGS projCRS F9",   BaseCrsCode=64009, BaseCrsName="GIGS geogCRS F", ProjCode=65009, ProjectionName="GIGS projection 9",        EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62017, Name="GIGS projCRS G10",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65010, ProjectionName="GIGS projection 10",       EpsgCsCode=6503, CsAxis1Name="Westing",  CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.West, CsAxis1Unit=69001, CsAxis2Name="Southing", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.South, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62018, Name="GIGS projCRS G11",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65011, ProjectionName="GIGS projection 11",       EpsgCsCode=4530, CsAxis1Name="Northing", CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62019, Name="GIGS projCRS G12",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65012, ProjectionName="GIGS projection 12",       EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62020, Name="GIGS projCRS G13",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65013, ProjectionName="GIGS projection 13",       EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62021, Name="GIGS projCRS G14",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65014, ProjectionName="GIGS projection 14",       EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62022, Name="GIGS projCRS G15",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65015, ProjectionName="GIGS projection 15",       EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62023, Name="GIGS projCRS G16",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65016, ProjectionName="GIGS projection 16",       EpsgCsCode=4532, CsAxis1Name="Northing", CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62024, Name="GIGS projCRS G17",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65017, ProjectionName="GIGS projection 17",       EpsgCsCode=4495, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69002, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69002 },
                new DatosProjectedCRS { Code=62025, Name="GIGS projCRS G18",  BaseCrsCode=64010, BaseCrsName="GIGS geogCRS G", ProjCode=65018, ProjectionName="GIGS projection 18",       EpsgCsCode=4497, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69003, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69003 },
                new DatosProjectedCRS { Code=62026, Name="GIGS projCRS H19",  BaseCrsCode=64011, BaseCrsName="GIGS geogCRS H", ProjCode=65019, ProjectionName="GIGS projection 19",       EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62038, Name="GIGS projCRS J28",  BaseCrsCode=64012, BaseCrsName="GIGS geogCRS J", ProjCode=65028, ProjectionName="GIGS projection 28",       EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62036, Name="GIGS projCRS K26",  BaseCrsCode=64015, BaseCrsName="GIGS geogCRS K", ProjCode=65026, ProjectionName="GIGS projection 26",       EpsgCsCode=4498, CsAxis1Name="Easting",  CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62037, Name="GIGS projCRS L27",  BaseCrsCode=64014, BaseCrsName="GIGS geogCRS L", ProjCode=65027, ProjectionName="GIGS projection 27",       EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62035, Name="GIGS projCRS M25",  BaseCrsCode=64020, BaseCrsName="GIGS geogCRS M", ProjCode=65025, ProjectionName="GIGS projection 25",       EpsgCsCode=4499, CsAxis1Name="Easting",  CsAxis1Abbreviation="X", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62034, Name="GIGS projCRS Y24",  BaseCrsCode=64017, BaseCrsName="GIGS geogCRS Y", ProjCode=65024, ProjectionName="GIGS projection 24",       EpsgCsCode=4532, CsAxis1Name="Northing", CsAxis1Abbreviation="Y", CsAxis1Orientation=AxisOrientationEnum.North, CsAxis1Unit=69001, CsAxis2Name="Easting", CsAxis2Abbreviation="X",CsAxis2Orientation=AxisOrientationEnum.East, CsAxis2Unit=69001 },
                new DatosProjectedCRS { Code=62039, Name="GIGS projCRS Z28",  BaseCrsCode=64012, BaseCrsName="GIGS geogCRS Z", ProjCode=65028, ProjectionName="GIGS projection 28",       EpsgCsCode=4400, CsAxis1Name="Easting",  CsAxis1Abbreviation="E", CsAxis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing", CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 }
            };

        public static DatosProjectedCRSConComponentesLibrería[] userProjectedCRSLibraryComponents = new[]
            {
                new DatosProjectedCRSConComponentesLibrería { Code=62028, Name="GIGS projCRS AA1", BaseCrsCode=64326, BaseCrsName="GIGS geogCRS AA",EPSGProjCode=16031, ProjectionName="UTM zone 31 N", CsCode=4400, CsAxis1Name="Easting", CsAxis1Abbreviation="E", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRSConComponentesLibrería { Code=62029, Name="GIGS projCRS BB2", BaseCrsCode=64277, BaseCrsName="GIGS geogCRS BB",EPSGProjCode=19916, ProjectionName="British National Grid", CsCode=4400, CsAxis1Name="Easting", CsAxis1Abbreviation="E", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRSConComponentesLibrería { Code=62030, Name="GIGS projCRS CC4", BaseCrsCode=64289, BaseCrsName="GIGS geogCRS CC",EPSGProjCode=19914, ProjectionName="RD New", CsCode=4499, CsAxis1Name="Easting", CsAxis1Abbreviation="X", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRSConComponentesLibrería { Code=62031, Name="GIGS projCRS EE6", BaseCrsCode=64313, BaseCrsName="GIGS geogCRS EE",EPSGProjCode=19961, ProjectionName="Belgian Lambert 72", CsCode=4499, CsAxis1Name="Easting", CsAxis1Abbreviation="X", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRSConComponentesLibrería { Code=62032, Name="GIGS projCRS FF8", BaseCrsCode=64283, BaseCrsName="GIGS geogCRS FF",EPSGProjCode=17355, ProjectionName="Map Grid of Australia zone 55", CsCode=4400, CsAxis1Name="Easting", CsAxis1Abbreviation="E", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="N",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 },
                new DatosProjectedCRSConComponentesLibrería { Code=62033, Name="GIGS projCRS HH19", BaseCrsCode=64807, BaseCrsName="GIGS geogCRS HH",EPSGProjCode=18082, ProjectionName="Lambert zone II", CsCode=4499, CsAxis1Name="Easting", CsAxis1Abbreviation="X", Cs1Axis1Orientation=AxisOrientationEnum.East, CsAxis1Unit=69001, CsAxis2Name="Northing",CsAxis2Abbreviation="Y",CsAxis2Orientation=AxisOrientationEnum.North, CsAxis2Unit=69001 }
            };

        public static DatosProyección[] projections = new[]
            {
                new DatosProyección { 
                    Code=65001, 
                    Name="GIGS projection 1", 
                    NombreOGS="Transverse_Mercator", 
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0, 
                    Parameter1Unit=69102, 
                    Parameter2Name="central_meridian", 
                    Parameter2Value=3.0, 
                    Parameter2Unit=69102, 
                    Parameter3Name="scale_factor", 
                    Parameter3Value=0.9996, 
                    Parameter3Unit=69201, 
                    Parameter4Name="false_easting", 
                    Parameter4Value=500000, 
                    Parameter4Unit=69001, 
                    Parameter5Name="false_northing", 
                    Parameter5Value=0, 
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65002, 
                    Name="GIGS projection 2", 
                    NombreOGS="Transverse_Mercator", 
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=49.0, 
                    Parameter1Unit=69102, 
                    Parameter2Name="central_meridian", 
                    Parameter2Value=-2.0, 
                    Parameter2Unit=69102, 
                    Parameter3Name="scale_factor", 
                    Parameter3Value=0.999601272, 
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=400000,
                    Parameter4Unit=69001, 
                    Parameter5Name="false_northing", 
                    Parameter5Value=-100000, 
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65021,
                    Name="GIGS projection 2 alt A",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-2.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.999601272,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=400000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=-5527462.688,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65022,
                    Name="GIGS projection 2 alt B",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-2.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.999601272,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=400000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=-5527063.816,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65004,
                    Name="GIGS projection 4",
                    NombreOGS="Oblique_Stereographic",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=52.1561606,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=5.3876389,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.9999079,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=155000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=463000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65005,
                    Name="GIGS projection 5",
                    NombreOGS="Mercator_1SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=3.1922806,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.997,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=3900000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=900000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65006,
                    Name="GIGS projection 6",
                    NombreOGS="Lambert_Conformal_Conic_2SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=90.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=4.367486667,
                    Parameter2Unit=69102,
                    Parameter3Name="standard_parallel1",
                    Parameter3Value=51.16666723,
                    Parameter3Unit=69102,
                    Parameter4Name="standard_parallel2",
                    Parameter4Value=49.8333339,
                    Parameter4Unit=69102,
                    Parameter5Name="false_easting",
                    Parameter5Value=150000.013,
                    Parameter5Unit=69001 , 
                    Parameter6Name="false_northing",
                    Parameter6Value=5400088.438,
                    Parameter6Unit=69001  
                },
                new DatosProyección { 
                    Code=65007,
                    Name="GIGS projection 7",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=141.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.9996,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=500000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=10000000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65008,
                    Name="GIGS projection 8",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=147.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.9996,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=500000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=10000000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65009,
                    Name="GIGS projection 9",
                    NombreOGS="Albers_Conic_Equal_Area",
                    Parameter1Name="latitude_of_center", 
                    Parameter1Value=0,
                    Parameter1Unit=69102,
                    Parameter2Name="longitude_of_center",
                    Parameter2Value=132,
                    Parameter2Unit=69102,
                    Parameter3Name="standard_parallel1",
                    Parameter3Value=-18,
                    Parameter3Unit=69102,
                    Parameter4Name="standard_parallel2",
                    Parameter4Value=-36,
                    Parameter4Unit=69102,
                    Parameter5Name="false_easting",
                    Parameter5Value=0,
                    Parameter5Unit=69001, 
                    Parameter6Name="false_northing",
                    Parameter6Value=0,
                    Parameter6Unit=69001  
                },
                new DatosProyección { 
                    Code=65010,
                    Name="GIGS projection 10",
                    NombreOGS="Transverse_Mercator_South_Orientated",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=21.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=1,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=0,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=0,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65011,
                    Name="GIGS projection 11",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=-90.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-60.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=1,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=5500000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=0,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65012,
                    Name="GIGS projection 12",
                    NombreOGS="polyconic",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-54,
                    Parameter2Unit=69102,
                    Parameter3Name="false_easting",
                    Parameter3Value=5000000,
                    Parameter3Unit=69001,
                    Parameter4Name="false_northing",
                    Parameter4Value=10000000,
                    Parameter4Unit=69001  
                },
                new DatosProyección { 
                    Code=65013,
                    Name="GIGS projection 13",
                    NombreOGS="Oblique_Mercator",
                    Parameter1Name="latitude_of_center", 
                    Parameter1Value=4,
                    Parameter1Unit=69102,
                    Parameter2Name="longitude_of_center",
                    Parameter2Value=115,
                    Parameter2Unit=69102,
                    Parameter3Name="azimuth",
                    Parameter3Value=53.31580994,
                    Parameter3Unit=69102,
                    Parameter4Name="rectified_grid_angle",
                    Parameter4Value=53.13010236,
                    Parameter4Unit=69102,
                    Parameter5Name="scale_factor",
                    Parameter5Value=0.99984,
                    Parameter5Unit=69201, 
                    Parameter6Name="false_easting",
                    Parameter6Value=590521.147,
                    Parameter6Unit=69001, 
                    Parameter7Name="false_northing",
                    Parameter7Value=442890.861,
                    Parameter7Unit=69001  
                },
                new DatosProyección { 
                    Code=65014,
                    Name="GIGS projection 14",
                    NombreOGS="Hotine_Oblique_Mercator",
                    Parameter1Name="latitude_of_center", 
                    Parameter1Value=4,
                    Parameter1Unit=69102,
                    Parameter2Name="longitude_of_center",
                    Parameter2Value=115,
                    Parameter2Unit=69102,
                    Parameter3Name="azimuth",
                    Parameter3Value=53.31580994,
                    Parameter3Unit=69102,
                    Parameter4Name="rectified_grid_angle",
                    Parameter4Value=53.13010236,
                    Parameter4Unit=69102,
                    Parameter5Name="scale_factor",
                    Parameter5Value=0.99984,
                    Parameter5Unit=69201, 
                    Parameter6Name="false_easting",
                    Parameter6Value=0,
                    Parameter6Unit=69001, 
                    Parameter7Name="false_northing",
                    Parameter7Value=0,
                    Parameter7Unit=69001  
                },
                new DatosProyección { 
                    Code=65015,
                    Name="GIGS projection 15",
                    NombreOGS="Cassini_Soldner",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=2.12167974,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=103.4279362361,
                    Parameter2Unit=69102,
                    Parameter3Name="false_easting",
                    Parameter3Value=-14810.562,
                    Parameter3Unit=69102,
                    Parameter4Name="false_northing",
                    Parameter4Value=8758.32,
                    Parameter4Unit=69102,
                },
                new DatosProyección { 
                    Code=65016,
                    Name="GIGS projection 16",
                    NombreOGS="Lambert_azimuthal_equal_area",
                    Parameter1Name="latitude_of_center", 
                    Parameter1Value=52,
                    Parameter1Unit=69102,
                    Parameter2Name="longitude_of_center",
                    Parameter2Value=10,
                    Parameter2Unit=69102,
                    Parameter3Name="false_easting",
                    Parameter3Value=4321000,
                    Parameter3Unit=69001, 
                    Parameter4Name="false_northing",
                    Parameter4Value=3210000,
                    Parameter4Unit=69001  
                },
                new DatosProyección { 
                    Code=65017,
                    Name="GIGS projection 17",
                    NombreOGS="Lambert_Conformal_Conic_2SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=40.3333333,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-111.5000000,
                    Parameter2Unit=69102,
                    Parameter3Name="standard_parallel1",
                    Parameter3Value=41.7833333,
                    Parameter3Unit=69102,
                    Parameter4Name="standard_parallel2",
                    Parameter4Value=40.7166667,
                    Parameter4Unit=69102,
                    Parameter5Name="false_easting",
                    Parameter5Value=1640419.948,
                    Parameter5Unit=69002, 
                    Parameter6Name="false_northing",
                    Parameter6Value=3280839.895,
                    Parameter6Unit=69002  
                },
                new DatosProyección { 
                    Code=65018,
                    Name="GIGS projection 18",
                    NombreOGS="Lambert_Conformal_Conic_2SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=40.3333333,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-111.5000000,
                    Parameter2Unit=69102,
                    Parameter3Name="standard_parallel1",
                    Parameter3Value=41.7833333,
                    Parameter3Unit=69102,
                    Parameter4Name="standard_parallel2",
                    Parameter4Value=40.7166667,
                    Parameter4Unit=69102,
                    Parameter5Name="false_easting",
                    Parameter5Value=1640416.667,
                    Parameter5Unit=69003, 
                    Parameter6Name="false_northing",
                    Parameter6Value=3280833.333,
                    Parameter6Unit=69003  
                },
                new DatosProyección { 
                    Code=65019,
                    Name="GIGS projection 19",
                    NombreOGS="Lambert_Conformal_Conic_1SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=52,
                    Parameter1Unit=69105,
                    Parameter2Name="central_meridian",
                    Parameter2Value=0,
                    Parameter2Unit=69105,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.99987742,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=600000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=2200000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65018,
                    Name="GIGS projection 18",
                    NombreOGS="Lambert_Conformal_Conic_2SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=40.3333333,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-111.5000000,
                    Parameter2Unit=69102,
                    Parameter3Name="standard_parallel1",
                    Parameter3Value=41.7833333,
                    Parameter3Unit=69102,
                    Parameter4Name="standard_parallel2",
                    Parameter4Value=40.7166667,
                    Parameter4Unit=69102,
                    Parameter5Name="false_easting",
                    Parameter5Value=1640416.667,
                    Parameter5Unit=69003, 
                    Parameter6Name="false_northing",
                    Parameter6Value=3280833.333,
                    Parameter6Unit=69003  
                },
                new DatosProyección { 
                    Code=65023,
                    Name="GIGS projection 23",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=3.0,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.9996,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=1640416.667,
                    Parameter4Unit=69003,
                    Parameter5Name="false_northing",
                    Parameter5Value=0,
                    Parameter5Unit=69003  
                },
                new DatosProyección { 
                    Code=65024,
                    Name="GIGS projection 24",
                    NombreOGS="Mercator_2SP",
                    Parameter1Name="standard_parallel_1", 
                    Parameter1Value=42,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=51,
                    Parameter2Unit=69102,
                    Parameter3Name="false_easting",
                    Parameter3Value=0,
                    Parameter3Unit=69001, 
                    Parameter4Name="false_northing",
                    Parameter4Value=0,
                    Parameter4Unit=69001  
                },
                new DatosProyección { 
                    Code=65025,
                    Name="GIGS projection 25",
                    NombreOGS="Lambert_Conformal_Conic_1SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=46.8000000,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=2.3372292,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.99987742,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=600000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=2200000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65026,
                    Name="GIGS projection 26",
                    NombreOGS="Oblique_Mercator",
                    Parameter1Name="latitude_of_center", 
                    Parameter1Value=47.14439372222222,
                    Parameter1Unit=69102,
                    Parameter2Name="longitude_of_center",
                    Parameter2Value=19.04857177777778,
                    Parameter2Unit=69102,
                    Parameter3Name="azimuth",
                    Parameter3Value=90,
                    Parameter3Unit=69102,
                    Parameter4Name="rectified_grid_angle",
                    Parameter4Value=90,
                    Parameter4Unit=69102,
                    Parameter5Name="scale_factor",
                    Parameter5Value=0.99993,
                    Parameter5Unit=69201, 
                    Parameter6Name="false_easting",
                    Parameter6Value=650000,
                    Parameter6Unit=69001, 
                    Parameter7Name="false_northing",
                    Parameter7Value=200000,
                    Parameter7Unit=69001  
                },
                new DatosProyección { 
                    Code=65027,
                    Name="GIGS projection 27",
                    NombreOGS="Mercator_1SP",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=110,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.997,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=3900000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=900000,
                    Parameter5Unit=69001  
                },
                new DatosProyección { 
                    Code=65028,
                    Name="GIGS projection 23",
                    NombreOGS="Transverse_Mercator",
                    Parameter1Name="latitude_of_origin", 
                    Parameter1Value=0.0,
                    Parameter1Unit=69102,
                    Parameter2Name="central_meridian",
                    Parameter2Value=-135,
                    Parameter2Unit=69102,
                    Parameter3Name="scale_factor",
                    Parameter3Value=0.9996,
                    Parameter3Unit=69201,
                    Parameter4Name="false_easting",
                    Parameter4Value=500000,
                    Parameter4Unit=69001,
                    Parameter5Name="false_northing",
                    Parameter5Value=0,
                    Parameter5Unit=69001  
                }
            };

        public static DatosGeodeticTransformations[] geodeticTransformations = new[]
            {
                new DatosGeodeticTransformations { 
                    Code=61196, 
                    Name="GIGS geogCRS B to GIGS geogCRS A (1)",
                    SourceCrsCode=64005,
                    SourceCrsName="GIGS geogCRS B",
                    TargetCrsCode=64003,
                    TargetCrsName="GIGS geogCRS A",
                    TfmVariant=1,
                    EpsgTfmMethodName="Geocentric_translation",
                    Parameter1Name="X_axis_translation",
                    Parameter1Value=371,
                    Parameter1Unit=69001,
                    Parameter2Name="Y_axis_translation",
                    Parameter2Value=-112,
                    Parameter2Unit=69001,
                    Parameter3Name="Z_axis_translation",
                    Parameter3Value=434,
                    Parameter3Unit=69001
                },
            };

        public static DatosVerticalDatum[] verticalDatums = new[]
            {
                new DatosVerticalDatum {Code=66601, Name="GIGS vertical datum U"},
                new DatosVerticalDatum {Code=66602, Name="GIGS vertical datum V"},
                new DatosVerticalDatum {Code=66603, Name="GIGS vertical datum W"},
            };

        public static DatosVerticalCRS[] verticalCrs = new[]
            {
                new DatosVerticalCRS{ Code=64501,Name="GIGS vertCRS U1 height",GigsDatumCode=66601,EpsgCsCode=6499,CsAxis1Name="Gravity-related height",CsAxis1Abbreviation="H",CsAxis1Orientation=AxisOrientationEnum.Up,CsAxis1Unit=69001},
                new DatosVerticalCRS{ Code=64502,Name="GIGS vertCRS U1 depth",GigsDatumCode=66601,EpsgCsCode=6498,CsAxis1Name="Gravity-related depth",CsAxis1Abbreviation="D",CsAxis1Orientation=AxisOrientationEnum.Down,CsAxis1Unit=69001},
                new DatosVerticalCRS{ Code=64503,Name="GIGS vertCRS U2 height",GigsDatumCode=66601,EpsgCsCode=1030,CsAxis1Name="Gravity-related height",CsAxis1Abbreviation="H",CsAxis1Orientation=AxisOrientationEnum.Up,CsAxis1Unit=69002},
                new DatosVerticalCRS{ Code=64504,Name="GIGS vertCRS U2 depth",GigsDatumCode=66601,EpsgCsCode=6495,CsAxis1Name="Gravity-related depth",CsAxis1Abbreviation="D",CsAxis1Orientation=AxisOrientationEnum.Down,CsAxis1Unit=69002},
                new DatosVerticalCRS{ Code=64505,Name="GIGS vertCRS V1 height",GigsDatumCode=66602,EpsgCsCode=6499,CsAxis1Name="Gravity-related height",CsAxis1Abbreviation="H",CsAxis1Orientation=AxisOrientationEnum.Up,CsAxis1Unit=69001},
                new DatosVerticalCRS{ Code=64506,Name="GIGS vertCRS V1 depth",GigsDatumCode=66602,EpsgCsCode=6498,CsAxis1Name="Gravity-related depth",CsAxis1Abbreviation="D",CsAxis1Orientation=AxisOrientationEnum.Down,CsAxis1Unit=69001},
                new DatosVerticalCRS{ Code=64509,Name="GIGS vertCRS V2 height",GigsDatumCode=66602,EpsgCsCode=6497,CsAxis1Name="Gravity-related height",CsAxis1Abbreviation="H",CsAxis1Orientation=AxisOrientationEnum.Up,CsAxis1Unit=69003},
                new DatosVerticalCRS{ Code=64507,Name="GIGS vertCRS W1 height",GigsDatumCode=66603,EpsgCsCode=6499,CsAxis1Name="Gravity-related height",CsAxis1Abbreviation="H",CsAxis1Orientation=AxisOrientationEnum.Up,CsAxis1Unit=69001},
                new DatosVerticalCRS{ Code=64508,Name="GIGS vertCRS W1 depth",GigsDatumCode=66603,EpsgCsCode=6498,CsAxis1Name="Gravity-related depth",CsAxis1Abbreviation="D",CsAxis1Orientation=AxisOrientationEnum.Down,CsAxis1Unit=69001},
            };


        public static bool DefineCódigo(this DatosLongitud[] pThis, int code)
        {
            return 0 != (from valor in pThis where valor.Code == code select valor).Count();
        }

        public static bool DefineCódigo(this DatosÁngulos[] pThis, int code)
        {
            return 0 != (from valor in pThis where valor.Code == code select valor).Count();
        }

        public static bool DefineCódigo(this DatosEscala[] pThis, int code)
        {
            return 0 != (from valor in pThis where valor.Code == code select valor).Count();
        }

        public static bool EsUnidadLineal(int code)
        {
            return GIGSDataSet.longitudes.DefineCódigo(code);
        }

        public static bool EsUnidadAngular(int code)
        {
            return GIGSDataSet.ángulos.DefineCódigo(code);
        }

        public static bool EsUnidadEscala(int code)
        {
            return GIGSDataSet.escalas.DefineCódigo(code);
        }

        public static string GetPrimeMeridianNameFromDatumCode(this DatosDatum[] pThis, int datumCode)
        {
            var consulta = from datosDatum in pThis
                           where datosDatum.Code == datumCode
                           select datosDatum;

            if (0 == consulta.Count())
                return null;

            var datum = consulta.First();
            return datum.PrimeMeridianName;
        }

        public static int? GetPrimeMeridianCodeFromName(this DatosMeridiano[] pThis, string name)
        {
            if (name == null)
                return null;

            var consulta = from datosPM in pThis
                           where datosPM.Name == name
                           select datosPM;

            if (0 == consulta.Count())
                return null;

            var pm = consulta.First();
            return pm.Code;
        }

        public static int? GetPrimeMeridianCodeFromDatumCode(this DatosDatum[] pThis, int datumCode)
        {
            return meridianos.GetPrimeMeridianCodeFromName(datum.GetPrimeMeridianNameFromDatumCode(datumCode));
        }
    }
}
