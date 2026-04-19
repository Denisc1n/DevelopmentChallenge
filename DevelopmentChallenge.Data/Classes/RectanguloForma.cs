using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal sealed class RectanguloForma : FormaGeometricaBase
    {
        private readonly decimal _base;
        private readonly decimal _altura;

        public RectanguloForma(decimal baseMedida, decimal alturaMedida)
        {
            _base = baseMedida;
            _altura = alturaMedida;
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }
    }
}
