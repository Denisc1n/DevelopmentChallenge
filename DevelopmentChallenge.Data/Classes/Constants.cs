using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal sealed class TraduccionForma
    {
        public TraduccionForma(string singular, string plural)
        {
            Singular = singular;
            Plural = plural;
        }

        public string Singular { get; }
        public string Plural { get; }
    }

    internal static class Constants
    {
        public static readonly TraduccionForma CuadradoIngles = new TraduccionForma("Square", "Squares");
        public static readonly TraduccionForma CuadradoCastellano = new TraduccionForma("Cuadrado", "Cuadrados");
        public static readonly TraduccionForma CuadradoItaliano = new TraduccionForma("Quadrato", "Quadrati");

        public static readonly TraduccionForma RectanguloIngles = new TraduccionForma("Rectangle", "Rectangles");
        public static readonly TraduccionForma RectanguloCastellano = new TraduccionForma("Rectángulo", "Rectángulos");
        public static readonly TraduccionForma RectanguloItaliano = new TraduccionForma("Rettangolo", "Rettangoli");

        public static readonly TraduccionForma CirculoIngles = new TraduccionForma("Circle", "Circles");
        public static readonly TraduccionForma CirculoCastellano = new TraduccionForma("Círculo", "Círculos");
        public static readonly TraduccionForma CirculoItaliano = new TraduccionForma("Cerchio", "Cerchi");

        public static readonly TraduccionForma TrianguloEquilateroIngles = new TraduccionForma("Triangle", "Triangles");
        public static readonly TraduccionForma TrianguloEquilateroCastellano = new TraduccionForma("Triángulo", "Triángulos");
        public static readonly TraduccionForma TrianguloEquilateroItaliano = new TraduccionForma("Triangolo", "Triangoli");

        public static readonly TraduccionForma TrapecioIngles = new TraduccionForma("Trapezoid", "Trapezoids");
        public static readonly TraduccionForma TrapecioCastellano = new TraduccionForma("Trapecio", "Trapecios");
        public static readonly TraduccionForma TrapecioItaliano = new TraduccionForma("Trapezio", "Trapezi");

        public static readonly TraduccionForma FormaIngles = new TraduccionForma("shape", "shapes");
        public static readonly TraduccionForma FormaCastellano = new TraduccionForma("forma", "formas");
        public static readonly TraduccionForma FormaItaliano = new TraduccionForma("forma", "forme");


        public static readonly TraduccionForma PerimetroIngles = new TraduccionForma("Perimeter", "Perimeters");
        public static readonly TraduccionForma PerimetroCastellano = new TraduccionForma("Perímetro", "Perímetros");
        public static readonly TraduccionForma PerimetroItaliano = new TraduccionForma("Perimetro", "Perimetri");

    }
}
