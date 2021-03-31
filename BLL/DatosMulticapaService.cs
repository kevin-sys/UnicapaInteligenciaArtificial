using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class DatosMulticapaService
    {
        private DatosMulticapaRepository datosMulticapaRepository;

        public DatosMulticapaService()
        {
            datosMulticapaRepository = new DatosMulticapaRepository();
        }
        public string GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarFuncionActivacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosMulticapa> PintarFuncionActivacion(string tipo)
        {
            return datosMulticapaRepository.PintarFuncionActivacion(tipo);
        }
        public void EliminarArchivoFuncionActivacion(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoFuncionActivacion(tipo);
            }
            catch (Exception)
            {

            }
        }
        public string GuardarPesos(string W, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarPesos(W, tipo);
                return "PESOS GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public void EliminarArchivoUmbrales(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoUmbrales(tipo);
            }
            catch (Exception)
            {
                
            }
        }
        public void EliminarArchivoPesoIniciales(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoPesoIniciales(tipo);
            }
            catch (Exception)
            {

            }
        }
        public void EliminarArchivoUmbralesActualizados(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoUmbralesActualizados(tipo);
            }
            catch (Exception)
            {

            }
        }
        public void EliminarArchivoPesoInicialesActualizados(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoPesoInicialesActualizados(tipo);
            }
            catch (Exception)
            {

            }
        }
        public string GuardarUmbrales(string U, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarUmbrales(U,tipo);
                return "Umbrales GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosMulticapa> PintarUmbral(string ruta)
        {
            return datosMulticapaRepository.PintarUmbral(ruta);
        }
        public IList<DatosMulticapa> PintarPesoInicial(string ruta)
        {
            return datosMulticapaRepository.PintarPesoInicial(ruta);
        }
        public IList<DatosMulticapa> PintarUmbralActualizar(string tipo)
        {
            return datosMulticapaRepository.PintarUmbralActualizar(tipo);
        }
        public IList<DatosMulticapa> PintarPesoInicialActualizar(string tipo)
        {
            return datosMulticapaRepository.PintarPesoInicialActualizar(tipo);
        }
        public IList<DatosMulticapa> PintarUmbralActualizarFinal(string tipo)
        {
            return datosMulticapaRepository.PintarUmbralActualizarFinal(tipo);
        }
        public IList<DatosMulticapa> PintarPesoInicialActualizarFinal(string tipo)
        {
            return datosMulticapaRepository.PintarPesoInicialActualizarFinal(tipo);
        }
        public string GuardarPesosActualizar(string W, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarPesosActualizar(W, tipo);
                return "PESOS GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public string GuardarUmbralesActualizar(string U, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarUmbralesActualizar(U, tipo);
                return "Umbrales GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }

        public string GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            try
            {
                datosMulticapaRepository.GuardarFuncionActivacionSimulacion(FuncionActivacion, tipo);
                return "FUNCION DE ACTIVACION GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }
        public IList<DatosMulticapa> PintarFuncionActivacionSimulacion(string tipo)
        {
            return datosMulticapaRepository.PintarFuncionActivacionSimulacion(tipo);
        }
        public void EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            try
            {
                datosMulticapaRepository.EliminarArchivoFuncionActivacionSimulacion(tipo);
            }
            catch (Exception)
            {

            }
        }
    }
}
