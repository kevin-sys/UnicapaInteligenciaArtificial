using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DatosMulticapa
    {
        public string NumeroCapas;
        public string NumeroNeuronasXCapas;
        public string FuncionActivacion;
        public string CapaSalida;
        public decimal W;
        public decimal U;
        public decimal NumFuncionActivacion;

        public decimal Identidad(decimal X)
        {
            decimal Y = X;
            return Y;
        }
        public decimal Escalon(decimal X)
        {
            decimal Y = Math.Sign(X);
            return Y;
        }
        public decimal Lineal_Tramos(decimal X)
        {
            decimal Y;

            if (X < -1)
            {
                Y = -1;
            }
            else if(1 <= X &&  X <= -1)
            {
                Y = X;
            }
            else
            {
                Y = 1;
            }
            return Y;
        }
        public decimal Sigmoidea(double X)
        {
            double Y = Math.Tanh(X);
            return Convert.ToDecimal(Y);
        }
        public decimal Gaussiana(double X)
        {
            double Y = Math.Exp(-(Math.Pow(X,2)));
            return Convert.ToDecimal(Y);
        }
        public decimal Sinusoidal(double X)
        {
            double Y = Math.Sin(X);
            return Convert.ToDecimal(Y);
        }
        public decimal Capa(decimal X, decimal W, decimal U )
        {
            return (X*W)-(U);
        }
        public decimal CalcularEL(decimal YD, decimal Salida)
        {
            return YD-Salida;
        }
        public decimal CalcularEP(decimal EL, decimal CantidadSalida)
        {
            return Math.Abs(EL)/CantidadSalida;
        }
        public decimal W_Actualizar(decimal W, decimal rata, decimal Ep, decimal X)
        {
            return W+rata*Ep*X;
        }
        public decimal U_Actualizar(decimal U, decimal rata, decimal Ep)
        {
            int Xo = 1;
            return U + rata * Ep * Xo;
        }
        public decimal Calcular_ERMS(IList<decimal> Ep, int NumeroPatrones)
        {
            return Ep.Sum() / NumeroPatrones;
        }
    
    }
}
