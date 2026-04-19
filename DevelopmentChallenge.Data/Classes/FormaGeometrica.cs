/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    internal interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }

    public abstract class FormaGeometricaBase : IFormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();

        protected static bool EsSingular(int cantidad)
        {
            return cantidad == 1;
        }
    }

    public class FormaGeometrica
    {
        private delegate IFormaGeometrica CreadorForma(decimal[] medidas);

        private sealed class DatosForma
        {
            public int Cantidad { get; set; }
            public decimal Area { get; set; }
            public decimal Perimetro { get; set; }
            public FormaGeometrica Muestra { get; set; }
        }

        private static readonly IDictionary<EForma, CreadorForma> CreadoresForma = new Dictionary<EForma, CreadorForma>
        {
            { EForma.Cuadrado, medidas => new CuadradoForma(ObtenerMedida(medidas, 0)) },
            { EForma.Circulo, medidas => new CirculoForma(ObtenerMedida(medidas, 0)) },
            { EForma.TrianguloEquilatero, medidas => new TrianguloEquilateroForma(ObtenerMedida(medidas, 0)) },
            { EForma.Rectangulo, medidas => new RectanguloForma(ObtenerMedida(medidas, 0), ObtenerMedida(medidas, 1)) },
            { EForma.Trapecio, medidas => new TrapecioForma(ObtenerMedida(medidas, 0), ObtenerMedida(medidas, 1), ObtenerMedida(medidas, 2)) }
        };

        private readonly IFormaGeometrica _forma;

        public EForma Tipo { get; }

        public FormaGeometrica(EForma tipo, decimal ancho)
            : this(tipo, new[] { ancho })
        {
        }

        public FormaGeometrica(EForma tipo, params decimal[] medidas)
        {
            Tipo = tipo;
            _forma = CrearForma(tipo, medidas);
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            return Imprimir(formas, (EIdioma)idioma);
        }

        public static string Imprimir(List<FormaGeometrica> formas, EIdioma idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(TraductorReportes.ObtenerListaVacia(idioma));
            }
            else
            {
                sb.Append(TraductorReportes.ObtenerTituloReporte(idioma));

                var resumenFormas = formas
                    .GroupBy(x => x.Tipo)
                    .Select(grupo =>
                    {
                        var formasAgrupadas = grupo.ToList();
                        var cantidad = formasAgrupadas.Count;
                        var primeraForma = formasAgrupadas.First();

                        return new DatosForma
                        {
                            Cantidad = cantidad,
                            Area = formasAgrupadas.Sum(x => x.CalcularArea()),
                            Perimetro = formasAgrupadas.Sum(x => x.CalcularPerimetro()),
                            Muestra = primeraForma
                        };
                    })
                    .ToList();

                foreach (var resumenForma in resumenFormas)
                {
                    sb.Append(ObtenerLinea(resumenForma, idioma));
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(resumenFormas.Sum(x => x.Cantidad) + " " + TraductorReportes.ObtenerEtiquetaFormas(idioma) + " ");
                sb.Append(TraductorReportes.ObtenerEtiquetaPerimetro(idioma) + " " + resumenFormas.Sum(x => x.Perimetro).ToString("#.##") + " ");
                sb.Append("Area " + resumenFormas.Sum(x => x.Area).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(DatosForma resumenForma, EIdioma idioma)
        {
            if (resumenForma.Cantidad > 0)
            {
                var descripcion = resumenForma.Muestra.ObtenerDescripcion(idioma, resumenForma.Cantidad);
                return $"{resumenForma.Cantidad} {descripcion} | Area {resumenForma.Area:#.##} | {TraductorReportes.ObtenerEtiquetaPerimetro(idioma)} {resumenForma.Perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static IFormaGeometrica CrearForma(EForma tipo, decimal[] medidas)
        {

            if (CreadoresForma.TryGetValue(tipo, out CreadorForma creadorForma))
            {
                return creadorForma(medidas);
            }

            throw new ArgumentOutOfRangeException("tipo", @"Forma desconocida");
        }

        private static decimal ObtenerMedida(decimal[] medidas, int indice)
        {
            if (medidas == null || medidas.Length <= indice)
            {
                throw new ArgumentException("La forma no tiene las medidas requeridas.", "medidas");
            }

            return medidas[indice];
        }

        public decimal CalcularArea()
        {
            return _forma.CalcularArea();
        }

        public decimal CalcularPerimetro()
        {
            return _forma.CalcularPerimetro();
        }

        public string ObtenerDescripcion(int idioma, int cantidad)
        {
            return ObtenerDescripcion((EIdioma)idioma, cantidad);
        }

        public string ObtenerDescripcion(EIdioma idioma, int cantidad)
        {
            return TraductorReportes.ObtenerDescripcionForma((EForma)Tipo, idioma, cantidad);
        }
    }
}
