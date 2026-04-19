using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    //Elegi implementar trapecio separado del rectangulo ya que el trapecio y el rectangulo tienen formulas diferentes.
    internal sealed class TrapecioForma : FormaGeometricaBase
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public TrapecioForma(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            // Asumimos que los lados no paralelos son iguales
            var ladoNoParalelo = Math.Sqrt(Math.Pow((double)(_baseMayor - _baseMenor) / 2, 2) + Math.Pow((double)_altura, 2));
            return _baseMayor + _baseMenor + 2 * (decimal)ladoNoParalelo;
        }
    }
}
