using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class DatosUnicapaService
    {
        private DatosUnicapaRepository datosUnicapaRepository;

        public DatosUnicapaService()
        {
            datosUnicapaRepository = new DatosUnicapaRepository();
        }
        public List<DatosUnicapa> PintarTabla1(string ruta)
        {
            return datosUnicapaRepository.PintarTabla1(ruta);
        }
        public List<DatosUnicapa> PintarTabla2(string ruta)
        {
            return datosUnicapaRepository.PintarTabla2(ruta);
        }
        public List<DatosUnicapa> PintarTabla3(string ruta)
        {
            return datosUnicapaRepository.PintarTabla3(ruta);
        }
        public string GuardarPesos(string W11, string W21)
        {
            try
            {
                datosUnicapaRepository.GuardarPesos(W11, W21);
                return "PESOS GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            } 
        }
        public string GuardarUmbrales(string U1)
        {
            try
            {
                datosUnicapaRepository.GuardarUmbrales(U1);
                return "UMBRALES GUARDADOS CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return "REGISTRO FALLIDO " + e.Message;
            }
        }

    }
}
