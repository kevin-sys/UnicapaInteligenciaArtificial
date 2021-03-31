using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class DatosBackpropagationPrimitivoService
    {
        private DatosBackpropagationPrimitivoRepository datosBackpropagationPrimitivoRepository;

        public DatosBackpropagationPrimitivoService()
        {
            datosBackpropagationPrimitivoRepository = new DatosBackpropagationPrimitivoRepository();
        }

        public IList<DatosBackpropagationPrimitivo> PintarUmbral(string ruta)
        {
            return datosBackpropagationPrimitivoRepository.PintarPesoInicial(ruta);
        }
        public IList<DatosBackpropagationPrimitivo> PintarPesoInicial(string ruta)
        {
            return datosBackpropagationPrimitivoRepository.PintarPesoInicial(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarPesosActualizar(string W, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarPesosActualizar(W, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public string EliminarArchivoPesoInicialesActualizar(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoPesoInicialesActualizar(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarPesoInicialActualizar(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.PintarPesoInicialActualizar(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarUmbralActualizar(string U, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarUmbralActualizar(U, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public string EliminarArchivoUmbralActualizar(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoUmbralActualizar(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarUmbralActualizar(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.PintarUmbralActualizar(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarFuncionActivacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarFuncionActivacion(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.PintarFuncionActivacion(tipo);
        }
        public string EliminarArchivoFuncionActivacion(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoFuncionActivacion(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarDerivadaFuncionActivacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarDerivadaFuncionActivacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarDerivadaFuncionActivacion(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.PintarDerivadaFuncionActivacion(tipo);
        }
        public string EliminarArchivoDerivadaFuncionActivacion(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoDerivadaFuncionActivacion(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarENi(string ENi)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarENi(ENi);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarENi()
        {
            return datosBackpropagationPrimitivoRepository.PintarENi();
        }
        public string EliminarENi()
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarENi();
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarENl(string ENl)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarENl(ENl);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarENl()
        {
            return datosBackpropagationPrimitivoRepository.PintarENl();
        }
        public string EliminarENl()
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarENl();
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarUmbral(string U, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarUmbral(U, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public string EliminarArchivoUmbral(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoUmbral(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> ConsultarUmbral(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.ConsultarUmbral(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarPesosIniciales(string W, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarPesosIniciales(W, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public string EliminarPesoIniciales(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarPesoIniciales(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> ConsultarPesosInicial(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.ConsultarPesosInicial(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.GuardarFuncionActivacionSimulacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationPrimitivo> PintarFuncionActivacionSimulacion(string tipo)
        {
            return datosBackpropagationPrimitivoRepository.PintarFuncionActivacionSimulacion(tipo);
        }
        public string EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            try
            {
                datosBackpropagationPrimitivoRepository.EliminarArchivoFuncionActivacionSimulacion(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
    }
}
