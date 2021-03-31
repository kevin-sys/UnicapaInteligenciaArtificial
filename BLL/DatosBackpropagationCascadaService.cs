using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class DatosBackpropagationCascadaService
    {
        private DatosBackpropagationCascadaRepository datosBackpropagationCascadaRepository;

        public DatosBackpropagationCascadaService()
        {
            datosBackpropagationCascadaRepository = new DatosBackpropagationCascadaRepository();
        }

        public IList<DatosBackpropagationCascada> PintarUmbral(string ruta)
        {
            return datosBackpropagationCascadaRepository.PintarPesoInicial(ruta);
        }
        public IList<DatosBackpropagationCascada> PintarPesoInicial(string ruta)
        {
            return datosBackpropagationCascadaRepository.PintarPesoInicial(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarPesosActualizar(string W, string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.GuardarPesosActualizar(W,tipo);
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
                datosBackpropagationCascadaRepository.EliminarArchivoPesoInicialesActualizar(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarPesoInicialActualizar(string tipo)
        {
            return datosBackpropagationCascadaRepository.PintarPesoInicialActualizar(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarUmbralActualizar(string U, string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.GuardarUmbralActualizar(U, tipo);
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
                datosBackpropagationCascadaRepository.EliminarArchivoUmbralActualizar(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarUmbralActualizar(string tipo)
        {
            return datosBackpropagationCascadaRepository.PintarUmbralActualizar(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.GuardarFuncionActivacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarFuncionActivacion(string tipo)
        {
            return datosBackpropagationCascadaRepository.PintarFuncionActivacion(tipo);
        }
        public string EliminarArchivoFuncionActivacion(string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.EliminarArchivoFuncionActivacion(tipo);
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
                datosBackpropagationCascadaRepository.GuardarDerivadaFuncionActivacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarDerivadaFuncionActivacion(string tipo)
        {
            return datosBackpropagationCascadaRepository.PintarDerivadaFuncionActivacion(tipo);
        }
        public string EliminarArchivoDerivadaFuncionActivacion(string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.EliminarArchivoDerivadaFuncionActivacion(tipo);
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
                datosBackpropagationCascadaRepository.GuardarENi(ENi);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarENi()
        {
            return datosBackpropagationCascadaRepository.PintarENi();
        }
        public string EliminarENi()
        {
            try
            {
                datosBackpropagationCascadaRepository.EliminarENi();
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
                datosBackpropagationCascadaRepository.GuardarENl(ENl);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarENl()
        {
            return datosBackpropagationCascadaRepository.PintarENl();
        }
        public string EliminarENl()
        {
            try
            {
                datosBackpropagationCascadaRepository.EliminarENl();
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
                datosBackpropagationCascadaRepository.GuardarUmbral(U, tipo);
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
                datosBackpropagationCascadaRepository.EliminarArchivoUmbral(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> ConsultarUmbral(string tipo)
        {
            return datosBackpropagationCascadaRepository.ConsultarUmbral(tipo);
        }
        //-------------------------------------------------------------------------------------------
        public string GuardarPesosIniciales(string W, string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.GuardarPesosIniciales(W, tipo);
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
                datosBackpropagationCascadaRepository.EliminarPesoIniciales(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> ConsultarPesosInicial(string tipo)
        {
            return datosBackpropagationCascadaRepository.ConsultarPesosInicial(tipo);
        }
        //-------------------------------------------------------------------------------------------

        public string GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.GuardarFuncionActivacionSimulacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosBackpropagationCascada> PintarFuncionActivacionSimulacion(string tipo)
        {
            return datosBackpropagationCascadaRepository.PintarFuncionActivacionSimulacion(tipo);
        }
        public string EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            try
            {
                datosBackpropagationCascadaRepository.EliminarArchivoFuncionActivacionSimulacion(tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }

    }
}
