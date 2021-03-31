using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DatosUnicapa
    {
        public double Entrada;
        public double Salida;
        public double Patrones;
        public decimal W1;
        public decimal W2;
        public decimal U;
        public double X1;
        public double X2;
        public decimal YD1;
        public decimal EP;       
        public string Respuesta;

        public decimal CalcularSalidaFuncion(decimal X1, decimal X2, decimal W11, decimal W21, decimal U1)
        {
            return (((X1*W11)+(X2*W21))-(U1));
        }
        
        public decimal CalcularSalidaRed(decimal SI)
        {
            if (SI>=0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public decimal CalcularErroresLinealesProducidos(decimal YDl, decimal YRl)
        {
            return  YDl - YRl;
        }
        
        public decimal CalcularErrorPatron(decimal Eli, decimal N)
        {
            return (Math.Abs(Eli)) / N;
        }
        
        public decimal AjustarMatrizPesos(decimal W,decimal RataAprendizaje, decimal ELl, decimal X)
        {
            return  W + RataAprendizaje * ELl * X;
        }
        
        public decimal AjustarMatrizVectorUmbrales(decimal U1, decimal RataAprendizaje, decimal ELl, decimal Xo)
        {
            return U1 + RataAprendizaje * ELl * Xo;
        }

        public decimal CalcularErrorRMS(IList<decimal> LEp)
        {
            decimal sum = 0;
            foreach (var item in LEp)
            {
                sum = sum + item;
            }

            return sum/LEp.Count();
        }

        public Boolean EstadoIA(decimal ERMS, decimal ERROP)
        {
            Boolean estado;

            if (ERMS <= ERROP)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            return estado;
        }
        public string RespuestaIA(decimal ERMS, decimal ERROP)
        {
            if (ERMS <= ERROP)
            {
                Respuesta = "EXITO -- PESOS Y UMBRAL ENCONTRADOS"; 
            }
            else
            {
                Respuesta = "COMO NO SE CUMPLE, SE VUELVE A PRESENTAR LAS ITERACIONES CON LOS VALORES DE W Y U ACTUALES.";
            }
            return Respuesta;
        }

    }
}
