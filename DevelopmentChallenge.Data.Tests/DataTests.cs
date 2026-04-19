using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EIdioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EIdioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EIdioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(EForma.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, EIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 5),
                new FormaGeometrica(EForma.Cuadrado, 1),
                new FormaGeometrica(EForma.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, EIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 5),
                new FormaGeometrica(EForma.Circulo, 3),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4),
                new FormaGeometrica(EForma.Rectangulo, 4m, 3m),
                new FormaGeometrica(EForma.Cuadrado, 2),
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 9),
                new FormaGeometrica(EForma.Circulo, 2.75m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Rectangle | Area 12 | Perimeter 14 <br/>1 Trapezoid | Area 10 | Perimeter 14,47 <br/>TOTAL:<br/>9 shapes Perimeter 126,14 Area 113,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 5),
                new FormaGeometrica(EForma.Circulo, 3),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4),
                new FormaGeometrica(EForma.Rectangulo, 4m, 3m),
                new FormaGeometrica(EForma.Cuadrado, 2),
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 9),
                new FormaGeometrica(EForma.Circulo, 2.75m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>1 Rectángulo | Area 12 | Perímetro 14 <br/>1 Trapecio | Area 10 | Perímetro 14,47 <br/>TOTAL:<br/>9 formas Perímetro 126,14 Area 113,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 5),
                new FormaGeometrica(EForma.Circulo, 3),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4),
                new FormaGeometrica(EForma.Rectangulo, 4m, 3m),
                new FormaGeometrica(EForma.Cuadrado, 2),
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 9),
                new FormaGeometrica(EForma.Circulo, 2.75m),
                new FormaGeometrica(EForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>1 Rettangolo | Area 12 | Perimetro 14 <br/>1 Trapezio | Area 10 | Perimetro 14,47 <br/>TOTAL:<br/>9 forme Perimetro 126,14 Area 113,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Rectangulo, 4m, 3m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Rectángulo | Area 12 | Perímetro 14 <br/>TOTAL:<br/>1 formas Perímetro 14 Area 12",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConRectangulosEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Rectangulo, 4m, 3m),
                new FormaGeometrica(EForma.Rectangulo, 2m, 5m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>2 Rettangoli | Area 22 | Perimetro 28 <br/>TOTAL:<br/>2 forme Perimetro 28 Area 22",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Area 10 | Perímetro 14,47 <br/>TOTAL:<br/>1 formas Perímetro 14,47 Area 10",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 2m),
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Ingles);
            Assert.AreEqual(
                "<h1>Shapes report</h1>1 Square | Area 4 | Perimeter 8 <br/>1 Trapezoid | Area 10 | Perimeter 14,47 <br/>TOTAL:<br/>2 shapes Perimeter 22,47 Area 14",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EForma.Cuadrado, 2m),
                new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EIdioma.Italiano);
            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>1 Quadrato | Area 4 | Perimetro 8 <br/>1 Trapezio | Area 10 | Perimetro 14,47 <br/>TOTAL:<br/>2 forme Perimetro 22,47 Area 14",
                resumen);
        }
    }
}
