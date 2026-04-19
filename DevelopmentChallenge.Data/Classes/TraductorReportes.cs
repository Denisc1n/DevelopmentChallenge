using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal static class TraductorReportes
    {
        public static string ObtenerListaVacia(EIdioma idioma)
        {
            switch (idioma)
            {
                case EIdioma.Castellano:
                    return "<h1>Lista vacía de formas!</h1>";
                case EIdioma.Italiano:
                    return "<h1>Lista vuota di forme!</h1>";
                default:
                    return "<h1>Empty list of shapes!</h1>";
            }
        }

        public static string ObtenerTituloReporte(EIdioma idioma)
        {
            switch (idioma)
            {
                case EIdioma.Castellano:
                    return "<h1>Reporte de Formas</h1>";
                case EIdioma.Italiano:
                    return "<h1>Rapporto di forme</h1>";
                default:
                    return "<h1>Shapes report</h1>";
            }
        }

        public static string ObtenerEtiquetaFormas(EIdioma idioma)
        {
            switch (idioma)
            {
                case EIdioma.Castellano:
                    return Constants.FormaCastellano.Plural;
                case EIdioma.Italiano:
                    return Constants.FormaItaliano.Plural;
                default:
                    return Constants.FormaIngles.Plural;
            }
        }

        public static string ObtenerEtiquetaPerimetro(EIdioma idioma)
        {
            switch (idioma)
            {
                case EIdioma.Ingles:
                    return Constants.PerimetroIngles.Singular;
                case EIdioma.Castellano:
                    return Constants.PerimetroCastellano.Singular;
                case EIdioma.Italiano:
                    return Constants.PerimetroItaliano.Singular;
                default:
                    return Constants.PerimetroCastellano.Singular;
            }
        }

        public static string ObtenerDescripcionForma(EForma tipo, EIdioma idioma, int cantidad)
        {
            switch (tipo)
            {
                case EForma.Cuadrado:
                    return ObtenerTraduccion(idioma, cantidad, Constants.CuadradoIngles, Constants.CuadradoCastellano, Constants.CuadradoItaliano);
                case EForma.Circulo:
                    return ObtenerTraduccion(idioma, cantidad, Constants.CirculoIngles, Constants.CirculoCastellano, Constants.CirculoItaliano);
                case EForma.TrianguloEquilatero:
                    return ObtenerTraduccion(idioma, cantidad, Constants.TrianguloEquilateroIngles, Constants.TrianguloEquilateroCastellano, Constants.TrianguloEquilateroItaliano);
                case EForma.Rectangulo:
                    return ObtenerTraduccion(idioma, cantidad, Constants.RectanguloIngles, Constants.RectanguloCastellano, Constants.RectanguloItaliano);
                case EForma.Trapecio:
                    return ObtenerTraduccion(idioma, cantidad, Constants.TrapecioIngles, Constants.TrapecioCastellano, Constants.TrapecioItaliano);
                default:
                    throw new ArgumentOutOfRangeException("tipo", @"Forma desconocida");
            }
        }

        private static string ObtenerTraduccion(
            EIdioma idioma,
            int cantidad,
            TraduccionForma ingles,
            TraduccionForma castellano,
            TraduccionForma italiano)
        {
            var esSingular = cantidad == 1;

            switch (idioma)
            {
                case EIdioma.Castellano:
                    return esSingular ? castellano.Singular : castellano.Plural;
                case EIdioma.Italiano:
                    return esSingular ? italiano.Singular : italiano.Plural;
                default:
                    return esSingular ? ingles.Singular : ingles.Plural;
            }
        }
    }
}
