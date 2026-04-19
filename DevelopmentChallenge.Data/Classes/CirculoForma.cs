using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal sealed class CirculoForma : FormaGeometricaBase
    {
        private readonly decimal _diametro;

        public CirculoForma(decimal diametro)
        {
            _diametro = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }
    }
}
