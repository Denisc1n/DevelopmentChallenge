using System;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class FormaGeometricaTests
    {
        [TestCase]
        public void CalcularAreaYPerimetroDeCuadrado()
        {
            var forma = new FormaGeometrica(EForma.Cuadrado, 5m);

            Assert.That(forma.CalcularArea(), Is.EqualTo(25m));
            Assert.That(forma.CalcularPerimetro(), Is.EqualTo(20m));
        }

        [TestCase]
        public void CalcularAreaYPerimetroDeRectangulo()
        {
            var forma = new FormaGeometrica(EForma.Rectangulo, 4m, 3m);

            Assert.That(forma.CalcularArea(), Is.EqualTo(12m));
            Assert.That(forma.CalcularPerimetro(), Is.EqualTo(14m));
        }

        [TestCase]
        public void CalcularAreaYPerimetroDeCirculo()
        {
            var forma = new FormaGeometrica(EForma.Circulo, 3m);

            Assert.That(forma.CalcularArea(), Is.EqualTo(7.06858m).Within(0.00001m));
            Assert.That(forma.CalcularPerimetro(), Is.EqualTo(9.42478m).Within(0.00001m));
        }

        [TestCase]
        public void CalcularAreaYPerimetroDeTrianguloEquilatero()
        {
            var forma = new FormaGeometrica(EForma.TrianguloEquilatero, 4m);

            Assert.That(forma.CalcularArea(), Is.EqualTo(6.92820m).Within(0.00001m));
            Assert.That(forma.CalcularPerimetro(), Is.EqualTo(12m));
        }

        [TestCase]
        public void CalcularAreaYPerimetroDeTrapecio()
        {
            var forma = new FormaGeometrica(EForma.Trapecio, 6m, 4m, 2m);

            Assert.That(forma.CalcularArea(), Is.EqualTo(10m));
            Assert.That(forma.CalcularPerimetro(), Is.EqualTo(14.47214m).Within(0.00001m));
        }

        [TestCase]
        public void CrearRectanguloSinAlturaLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentException>(() => new FormaGeometrica(EForma.Rectangulo, 4m));

            Assert.That(ex.ParamName, Is.EqualTo("medidas"));
        }

        [TestCase]
        public void CrearTrapecioSinTodasLasMedidasLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentException>(() => new FormaGeometrica(EForma.Trapecio, 6m, 4m));

            Assert.That(ex.ParamName, Is.EqualTo("medidas"));
        }

        [TestCase]
        public void CrearFormaConTipoDesconocidoLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new FormaGeometrica((EForma)999, 1m));

            Assert.That(ex.ParamName, Is.EqualTo("tipo"));
        }

        [TestCase]
        public void CrearRectanguloConBaseCeroLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new FormaGeometrica(EForma.Rectangulo, 0m, 3m));

            Assert.That(ex.ParamName, Is.EqualTo("medidas"));
        }

        [TestCase]
        public void CrearRectanguloConAlturaNegativaLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new FormaGeometrica(EForma.Rectangulo, 4m, -1m));

            Assert.That(ex.ParamName, Is.EqualTo("medidas"));
        }

        [TestCase]
        public void CrearCirculoConDiametroNegativoLanzaExcepcion()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new FormaGeometrica(EForma.Circulo, -3m));

            Assert.That(ex.ParamName, Is.EqualTo("medidas"));
        }
    }
}
