using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DatosBackpropagationCascada
    {
        public string NumeroCapas;
        public string NumeroNeuronasXCapas;
        public string NumeroCapaSalida;
        public string FuncionActivacion;

        public decimal W;
        public decimal U;
        public decimal ENi;
        public decimal ENl;
        public decimal NumFuncionActivacion;
        public decimal DerivadaFuncionActivacion;

        public decimal Identidad(decimal X)
        {
            decimal Y = X;
            return Y;
        }
        public decimal Derivada_Identidad(decimal X)
        {
            decimal Y = 1;
            return Y;
        }
        public decimal Escalon(decimal X)
        {
            decimal Y = Math.Sign(X);
            return Y;
        }
        public decimal Derivada_Escalon(decimal X)
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
            else if (1 <= X && X <= -1)
            {
                Y = X;
            }
            else
            {
                Y = 1;
            }
            return Y;
        }
        public decimal Derivada_Lineal_Tramos(decimal X)
        {
            decimal Y;

            if (X < -1)
            {
                Y = 0;
            }
            else if (1 <= X && X <= -1)
            {
                Y = 1;
            }
            else
            {
                Y = 0;
            }
            return Y;
        }
        public decimal Sigmoidea(double X)
        {
            double Y = Math.Tanh(X);
            return Convert.ToDecimal(Y);
        }
        public decimal Derivada_Sigmoidea(double X)
        {
            double Y = 1/(Math.Pow(Math.Cosh(X),2));
            return Convert.ToDecimal(Y);
        }
        public decimal Gaussiana(double X)
        {
            double Y = Math.Exp(-(Math.Pow(X, 2)));
            return Convert.ToDecimal(Y);
        }
        public decimal Derivada_Gaussiana(double X)
        {
            double Y = -((2 * X) / (Math.Exp(Math.Pow(X, 2))));
            return Convert.ToDecimal(Y);
        }
        public decimal Sinusoidal(double X)
        {
            double Y = Math.Sin(X);
            return Convert.ToDecimal(Y);
        }
        public decimal Derivada_Sinusoidal(double X)
        {
            double Y = Math.Cos(X);
            return Convert.ToDecimal(Y);
        }
        public decimal Capa(decimal X, decimal W, decimal U)
        {
            return (X * W) - (U);
        }
        public decimal CalcularEL(decimal YD, decimal Salida)
        {
            return YD - Salida;
        }
        public decimal CalcularEP(decimal EL, decimal CantidadSalida)
        {
            return Math.Abs(EL) / CantidadSalida;
        }
        public decimal W_Actualizar(decimal W, decimal rata, decimal En, decimal DFA, decimal X)
        {
            return W - 2 * rata * En * DFA * X;
            //=B3+2*$AC$56*AA$62*X$15*$B$47
        }
        public decimal W2_Actualizar(decimal W, decimal rata, decimal En, decimal DFA)
        {
            return W - 2 * rata * En * DFA;
            //=B3+2*$AC$56*AA$62*X$15*$B$47
        }
        public decimal W3_Actualizar(decimal W, decimal rata, decimal ELK, decimal FA)
        {
            return W - 2 * rata * ELK * FA;
            //=B3+2*$AC$56*AA$62*X$15*$B$47
        }
        public decimal U_Actualizar(decimal U, decimal rata, decimal En)
        {
            int Xo = 1;
            return U -2 * rata * En * Xo;
        }
        public decimal U2_Actualizar(decimal U, decimal rata, decimal El)
        {
            int Xo = 1;
            return U - rata * El * Xo;
        }
        public decimal Calcular_ERMS(IList<decimal> Ep, int NumeroPatrones)
        {
            return Ep.Sum() / NumeroPatrones;
        }
        public decimal Error_EN_l(decimal El, decimal W)
        {
            return El * W;
        }
        public decimal Error_EN_i(decimal El_l, decimal W)
        {
            return El_l * W;
        }
    }
}
