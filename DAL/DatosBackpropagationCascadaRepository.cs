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
    public class DatosBackpropagationCascadaRepository
    {
        private List<DatosBackpropagationCascada> datosBackpropagationCascadas;
        private string ruta;

        //-------------------------------------------------------------------------------------------
        public IList<DatosBackpropagationCascada> PintarUmbral(string ruta)
        {

            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public IList<DatosBackpropagationCascada> PintarPesoInicial(string ruta)
        {

            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesosActualizar(string W, string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas Actualizar {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoPesoInicialesActualizar(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas Actualizar {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationCascada> PintarPesoInicialActualizar(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas Actualizar {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesosIniciales(string W, string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarPesoIniciales(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationCascada> ConsultarPesosInicial(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Cascadas {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarUmbralActualizar(string U, string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas Actualizar {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoUmbralActualizar(string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas Actualizar {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationCascada> PintarUmbralActualizar(string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas Actualizar {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarUmbral(string U, string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoUmbral(string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationCascada> ConsultarUmbral(string tipo)
        {
            ruta = $"Ubral Backpropagation Cascadas {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationCascada> PintarFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public void EliminarArchivoFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion {tipo}.txt";
            File.Delete(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarDerivadaFuncionActivacion(string DerivadaFuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Cascadas Derivada Funcion Activacion {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{DerivadaFuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationCascada> PintarDerivadaFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Derivada Funcion Activacion {tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.DerivadaFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public void EliminarArchivoDerivadaFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Derivada Funcion Activacion {tipo}.txt";
            File.Delete(ruta);
        }

        //-------------------------------------------------------------------------------------------
        public void GuardarENi(string ENi)
        {
            ruta = $"Backpropagation Cascadas ENi.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{ENi}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationCascada> PintarENi()
        {
            ruta = $"Backpropagation Cascadas ENi.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.ENi = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public void EliminarENi()
        {
            ruta = $"Backpropagation Cascadas ENi.txt";
            File.Delete(ruta);
        }

        //-------------------------------------------------------------------------------------------
        public void GuardarENl(string ENl)
        {
            ruta = $"Backpropagation Cascadas ENl.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{ENl}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationCascada> PintarENl()
        {
            ruta = $"Backpropagation Cascadas ENl.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.ENl = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public void EliminarENl()
        {
            ruta = $"Backpropagation Cascadas ENl.txt";
            File.Delete(ruta);
        }
        public void GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion Simulacion{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationCascada> PintarFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion Simulacion{tipo}.txt";
            datosBackpropagationCascadas = new List<DatosBackpropagationCascada>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationCascada datosBackpropagationCascada = new DatosBackpropagationCascada();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationCascada.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationCascadas.Add(datosBackpropagationCascada);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationCascadas;
        }
        public void EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Backpropagation Cascadas Funcion Activacion Simulacion{tipo}.txt";
            File.Delete(ruta);
        }
    }
}
