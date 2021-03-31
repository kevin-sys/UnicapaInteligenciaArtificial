using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace DAL
{
    public class DatosMulticapaRepository
    {
        private List<DatosMulticapa> DatosMulticapas;
        private string ruta;//= "Datos de peso iniciales.txt";

        //-------------------------------------------------------------------------------------------
        public IList<DatosMulticapa> PintarUmbral(string ruta)
        {

            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.U = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        public IList<DatosMulticapa> PintarPesoInicial(string ruta)
        {

            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.W = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Funcion Activacion{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosMulticapa> PintarFuncionActivacion(string tipo)
        {
            ruta = $"Funcion Activacion{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        public void EliminarArchivoFuncionActivacion(string tipo)
        {
            ruta = $"Funcion Activacion{tipo}.txt";
            File.Delete(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesos(string W, string tipo)
        {
            ruta = $"peso iniciales{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoPesoIniciales(string tipo)
        {
            ruta = $"peso iniciales{tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosMulticapa> PintarPesoInicialActualizar(string tipo)
        {
            ruta = $"peso iniciales{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.W = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        //-------------------------------------------------------------------------------------------/
        public void GuardarUmbrales(string U, string tipo)
        {
            ruta = $"Umbrales{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosMulticapa> PintarUmbralActualizar(string tipo)
        {
            ruta = $"Umbrales{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.U = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        public void EliminarArchivoUmbrales(string tipo)
        {
            ruta = $"Umbrales{tipo}.txt";
            File.Delete(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesosActualizar(string W, string tipo)
        {
            ruta = $"peso iniciales Actualizar Final{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoPesoInicialesActualizados(string tipo)
        {
            ruta = $"peso iniciales Actualizar Final{tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosMulticapa> PintarPesoInicialActualizarFinal(string tipo)
        {
            ruta = $"peso iniciales Actualizar Final{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.W = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarUmbralesActualizar(string U, string tipo)
        {
            ruta = $"Umbrales Actualizar Final{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoUmbralesActualizados(string tipo)
        {
            ruta = $"Umbrales Actualizar Final{tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosMulticapa> PintarUmbralActualizarFinal(string tipo)
        {
            ruta = $"Umbrales Actualizar Final{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.U = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Funcion Activacion Simulacion{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosMulticapa> PintarFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Funcion Activacion Simulacion{tipo}.txt";
            DatosMulticapas = new List<DatosMulticapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosMulticapa datosMulticapa = new DatosMulticapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosMulticapa.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                DatosMulticapas.Add(datosMulticapa);
            }
            reader.Close();
            file.Close();
            return DatosMulticapas;
        }
        public void EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Funcion Activacion Simulacion{tipo}.txt";
            File.Delete(ruta);
        }
    }
}
