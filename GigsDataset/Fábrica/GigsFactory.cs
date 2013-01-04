#define DEFINE_GIGS_AS_AUTHORITY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digi21.OpenGis.CoordinateSystems;
using Digi21.OpenGis.CoordinateTransformations;
using Digi21.OpenGis.Epsg;

namespace Gigs
{
    public class GigsFactory
    {
        CoordinateSystemFactory fábrica = new CoordinateSystemFactory();
        CoordinateSystemAuthorityFactory fábricaEPSG = new CoordinateSystemAuthorityFactory();

        public ILinearUnit CreateLinearUnit(string code)
        {
            var unidadLineal = from unidad in GIGSDataSet.longitudes
                               where unidad.Code == int.Parse(code)
                               select unidad;

            if (0 == unidadLineal.Count())
                throw new ArgumentException(string.Format("No existe ningúna unidad lineal con el código {0}", code));

            var nodoUnidad = unidadLineal.First();

#if DEFINE_GIGS_AS_AUTHORITY
            return new LinearUnit(nodoUnidad.Name, "GIGS", code.ToString(), "", "", nodoUnidad.MetersPerUnit);
#else
            return new LinearUnit(nodoUnidad.Name, "", "", "", "", nodoUnidad.MetersPerUnit);
#endif
        }

        public IAngularUnit CreateAngularUnit(string code)
        {
            var nodosÁngulo = from ángulo in GIGSDataSet.ángulos
                              where ángulo.Code == int.Parse(code)
                              select ángulo;

            if (0 == nodosÁngulo.Count())
                throw new ArgumentException(string.Format("No existe ningúna unidad angular con el código {0}", code));

            var nodoÁngulo = nodosÁngulo.First();

#if DEFINE_GIGS_AS_AUTHORITY
            return new AngularUnit(nodoÁngulo.Name, "GIGS", code.ToString(), "", "", nodoÁngulo.RadiansPerUnit);
#else
            return new AngularUnit(nodoÁngulo.Name, "", "", "", "", nodoÁngulo.RadiansPerUnit);
#endif
        }

        public IEllipsoid CreateEllipsoid(string code)
        {
            var consulta = from nodoElipdoide in GIGSDataSet.elipsoides
                           where nodoElipdoide.Code == int.Parse(code)
                           select nodoElipdoide;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún elipsoide con el código {0}", code));

            var elipsoide = consulta.First();

#if DEFINE_GIGS_AS_AUTHORITY
            if (elipsoide.SemiMinorAxis.HasValue)
                return Ellipsoid.CreateFromSemiMajorAxisSemiMinorAxis(
                    elipsoide.Name,
                    "GIGS",
                    code,
                    elipsoide.SemiMajorAxis, elipsoide.SemiMinorAxis.Value,
                    CreateLinearUnit(elipsoide.Unit.ToString()));
            else
                return Ellipsoid.CreateFromSemiMajorAxisInverseFlattening(
                    elipsoide.Name,
                    "GIGS",
                    code,
                    elipsoide.SemiMajorAxis, elipsoide.InverseFlattening.Value,
                    CreateLinearUnit(elipsoide.Unit.ToString()));
#else
            if (elipsoide.SemiMinorAxis.HasValue)
                return fábrica.CreateEllipsoid(elipsoide.Name, elipsoide.SemiMajorAxis, elipsoide.SemiMinorAxis.Value, CreateLinearUnit(elipsoide.Unit.ToString()));
            else
                return fábrica.CreateFlattenedSphere(elipsoide.Name, elipsoide.SemiMajorAxis, elipsoide.InverseFlattening.Value, CreateLinearUnit(elipsoide.Unit.ToString()));
#endif
        }

        public IEllipsoid CreateEllipsoidByName(string name)
        {
            var consulta = from nodoElipdoide in GIGSDataSet.elipsoides
                           where nodoElipdoide.Name == name
                           select nodoElipdoide;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún elipsoide con el nombre {0}", name));

            var elipsoide = consulta.First();

#if DEFINE_GIGS_AS_AUTHORITY
            if (elipsoide.SemiMinorAxis.HasValue)
                return Ellipsoid.CreateFromSemiMajorAxisSemiMinorAxis(
                    elipsoide.Name,
                    "GIGS",
                    elipsoide.Code.ToString(),
                    elipsoide.SemiMajorAxis, elipsoide.SemiMinorAxis.Value,
                    CreateLinearUnit(elipsoide.Unit.ToString()));
            else
                return Ellipsoid.CreateFromSemiMajorAxisInverseFlattening(
                    elipsoide.Name,
                    "GIGS",
                    elipsoide.Code.ToString(),
                    elipsoide.SemiMajorAxis, elipsoide.InverseFlattening.Value,
                    CreateLinearUnit(elipsoide.Unit.ToString()));
#else
            if (elipsoide.SemiMinorAxis.HasValue)
                return fábrica.CreateEllipsoid(elipsoide.Name, elipsoide.SemiMajorAxis, elipsoide.SemiMinorAxis.Value, CreateLinearUnit(elipsoide.Unit.ToString()));
            else
                return fábrica.CreateFlattenedSphere(elipsoide.Name, elipsoide.SemiMajorAxis, elipsoide.InverseFlattening.Value, CreateLinearUnit(elipsoide.Unit.ToString()));
#endif
        }

        public IPrimeMeridian CreatePrimeMeridian(string code)
        {
            var consulta = from nodoMeridiano in GIGSDataSet.meridianos
                           where nodoMeridiano.Code == int.Parse(code)
                           select nodoMeridiano;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún meridiano con el código {0}", code));

            var meridiano = consulta.First();
#if DEFINE_GIGS_AS_AUTHORITY
            return new PrimeMeridian(
                meridiano.Name, 
                "GIGS", 
                code, 
                "",
                "",
                CreateAngularUnit(meridiano.Unit.ToString()), 
                meridiano.LongitudeFromGreenwich);
#else
            return fábrica.CreatePrimeMeridian(meridiano.Name, CreateAngularUnit(meridiano.Unit.ToString()), meridiano.LongitudeFromGreenwich);
#endif
        }

        public IHorizontalDatum CreateHorizontalDatum(string code)
        {
            IHorizontalDatum datum = _CreateHorizontalDatum(code);
            if (null != datum)
                return datum;

            datum = _CreateHorizontalDatumLibraryComponents(code);
            if (null != datum)
                return datum;

            throw new ArgumentException(string.Format("No existe ningún datum con el código {0}", code));
        }

        private IHorizontalDatum _CreateHorizontalDatum(string code)
        {
            var consulta = from nodoDatum in GIGSDataSet.datum
                           where nodoDatum.Code == int.Parse(code)
                           select nodoDatum;

            if (0 == consulta.Count())
                return null;

            var datum = consulta.First();

#if DEFINE_GIGS_AS_AUTHORITY
            return new HorizontalDatum(datum.Name, "GIGS", code, "", "", DatumType.HD_Geocentric, CreateEllipsoidByName(datum.EllipsoidName));
#else
            return fábrica.CreateHorizontalDatum(datum.Name, DatumType.HD_Other, CreateEllipsoidByName(datum.EllipsoidName), null);
#endif
        }

        private IHorizontalDatum _CreateHorizontalDatumLibraryComponents(string code)
        {
            // No lo desarrollo porque no entiendo que pinta el prime meridian
            throw new NotImplementedException();

            //var consulta = from nodoDatum in GIGSDataSet.datumLibraryComponents
            //               where nodoDatum.Code == int.Parse(code)
            //               select nodoDatum;

            //if (0 == consulta.Count())
            //    return null;

            //var datum = consulta.First();
            //return fábrica.CreateHorizontalDatum(datum.Name, DatumType.VD_Ellipsoidal, CreateEllipsoidByName(datum..EllipsoidName), null);
        }

        public IGeographicCoordinateSystem CreateGeographicCoordinateSystem(string code)
        {
            var consulta = from geodeticCRS in GIGSDataSet.geodeticCRS
                           where geodeticCRS.Code == int.Parse(code)
                           select geodeticCRS;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún sistema de coordenadas geográfico con el código {0}", code));

            var crs = consulta.First();

            IHorizontalDatum datum = CreateHorizontalDatum(crs.DatumCode.ToString());
            int? códigoPrimeMeridian = GIGSDataSet.datum.GetPrimeMeridianCodeFromDatumCode(crs.DatumCode);
            if (null == códigoPrimeMeridian)
                return null;

            IPrimeMeridian primeMeridian = CreatePrimeMeridian(códigoPrimeMeridian.Value.ToString());

            AxisInfo axis0, axis1;

            if (crs.AxesChanged.HasValue && crs.AxesChanged.Value)
            {
                axis0 = new AxisInfo("Long", AxisOrientationEnum.East);
                axis1 = new AxisInfo("Lat", AxisOrientationEnum.North);
            }
            else
            {
                axis0 = new AxisInfo("Lat", AxisOrientationEnum.North);
                axis1 = new AxisInfo("Long", AxisOrientationEnum.East);
            }

#if DEFINE_GIGS_AS_AUTHORITY
            return new GeographicCoordinateSystem(
                crs.Name, 
                "GIGS",
                code,
                "",
                "",
                primeMeridian.AngularUnit, 
                datum, 
                primeMeridian, 
                axis0, 
                axis1);
#else
            return fábrica.CreateGeographicCoordinateSystem(crs.Name, primeMeridian.AngularUnit, datum, primeMeridian, axis0, axis1);
#endif
        }

        void AnadeParámetroAListaParámetros(List<ProjectionParameter> parámetros, string nombre, double valor, int unidad)
        {
            if (null != nombre)
            {
                if (GIGSDataSet.EsUnidadLineal(unidad))
                    AnadeParámetroAListaParámetros(parámetros, nombre, valor, CreateLinearUnit(unidad.ToString()));
                else if (GIGSDataSet.EsUnidadAngular(unidad))
                    AnadeParámetroAListaParámetros(parámetros, nombre, valor, CreateAngularUnit(unidad.ToString()));
                else
                    parámetros.Add(new ProjectionParameter(nombre, valor));
            }
        }

        void AnadeParámetroAListaParámetros(List<ProjectionParameter> parámetros, string nombre, double valor, ILinearUnit unidad)
        {
            valor = unidad.MetersPerUnit * valor;
            parámetros.Add(new ProjectionParameter(nombre, valor));
        }

        void AnadeParámetroAListaParámetros(List<ProjectionParameter> parámetros, string nombre, double valor, IAngularUnit unidad)
        {
            valor = unidad.RadiansPerUnit * valor * 180.0 / Math.PI;
            parámetros.Add(new ProjectionParameter(nombre, valor));
        }

        public Projection CreateProjection(int code)
        {
            var consulta = from nodo in GIGSDataSet.projections
                           where nodo.Code == code
                           select nodo;

            if (0 == consulta.Count())
                return null;

            var dato = consulta.First();

            List<ProjectionParameter> parámetros = new List<ProjectionParameter>();
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter1Name, dato.Parameter1Value, dato.Parameter1Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter2Name, dato.Parameter2Value, dato.Parameter2Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter3Name, dato.Parameter3Value, dato.Parameter3Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter4Name, dato.Parameter4Value, dato.Parameter4Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter5Name, dato.Parameter5Value, dato.Parameter5Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter6Name, dato.Parameter6Value, dato.Parameter6Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter7Name, dato.Parameter7Value, dato.Parameter7Unit);

            return new Projection(dato.NombreOGS, parámetros.ToArray());
        }

        private Projection CreateProjection(int code, IEllipsoid elipsoid)
        {
            var consulta = from nodo in GIGSDataSet.projections
                           where nodo.Code == code
                           select nodo;

            if (0 == consulta.Count())
                return null;

            var dato = consulta.First();

            List<ProjectionParameter> parámetros = new List<ProjectionParameter>();
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter1Name, dato.Parameter1Value, dato.Parameter1Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter2Name, dato.Parameter2Value, dato.Parameter2Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter3Name, dato.Parameter3Value, dato.Parameter3Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter4Name, dato.Parameter4Value, dato.Parameter4Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter5Name, dato.Parameter5Value, dato.Parameter5Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter6Name, dato.Parameter6Value, dato.Parameter6Unit);
            AnadeParámetroAListaParámetros(parámetros, dato.Parameter7Name, dato.Parameter7Value, dato.Parameter7Unit);

            return new Projection(dato.NombreOGS, parámetros.ToArray());
        }

        public IProjectedCoordinateSystem CreateProjectedCoordinateSystem(string code)
        {
            // Obtenemos los parámetros de proyección.
            var consulta = from projectedCRS in GIGSDataSet.userProjectedCRS
                           where projectedCRS.Code == int.Parse(code)
                           select projectedCRS;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún sistema de coordenadas proyectado con el código {0}", code));

            var crs = consulta.First();
            //crs.ProjCode
            IGeographicCoordinateSystem geocrs = CreateGeographicCoordinateSystem(crs.BaseCrsCode.ToString());

#if DEFINE_GIGS_AS_AUTHORITY
            return new ProjectedCoordinateSystem(
                crs.Name,
                "GIGS",
                code,
                "",
                "",
                geocrs,
                CreateProjection(crs.ProjCode, geocrs.HorizontalDatum.Ellipsoid),
                CreateLinearUnit(crs.CsAxis1Unit.ToString()),
                new AxisInfo(crs.CsAxis1Abbreviation, crs.CsAxis1Orientation),
                new AxisInfo(crs.CsAxis2Abbreviation, crs.CsAxis2Orientation));
#else
            return fábrica.CreateProjectedCoordinateSystem(
                crs.Name,
                geocrs,
                CreateProjection(crs.ProjCode, geocrs.HorizontalDatum.Ellipsoid),
                CreateLinearUnit(crs.CsAxis1Unit.ToString()),
                new AxisInfo(crs.CsAxis1Abbreviation, crs.CsAxis1Orientation),
                new AxisInfo(crs.CsAxis2Abbreviation, crs.CsAxis2Orientation));
#endif
        }

        public IVerticalDatum CreateVerticalDatum(string code)
        {
            // Obtenemos los parámetros de proyección.
            var consulta = from verticalDatum in GIGSDataSet.verticalDatums
                           where verticalDatum.Code == int.Parse(code)
                           select verticalDatum;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún datum vertical con el código {0}", code));

            var crs = consulta.First();

            return new VerticalDatum(
                crs.Name,
                "GIGS",
                code,
                "",
                "",
                DatumType.VD_GeoidModelDerived);
        }

        public IVerticalCoordinateSystem CreateVerticalCoordinateSystem(string code)
        {
            // Obtenemos los parámetros de proyección.
            var consulta = from verticalCoordinateSystem in GIGSDataSet.verticalCrs
                           where verticalCoordinateSystem.Code == int.Parse(code)
                           select verticalCoordinateSystem;

            if (0 == consulta.Count())
                throw new ArgumentException(string.Format("No existe ningún sistema de coordenadas vertical con el código {0}", code));

            var crs = consulta.First();

            return new VerticalCoordinateSystem(
                crs.Name,
                "GIGS",
                code,
                "",
                "",
                CreateLinearUnit(crs.CsAxis1Unit.ToString()),
                CreateVerticalDatum(crs.GigsDatumCode.ToString()),
                new AxisInfo(crs.CsAxis1Abbreviation, crs.CsAxis1Orientation));
        }
    }
}
