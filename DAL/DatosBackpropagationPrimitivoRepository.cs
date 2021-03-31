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
    public class DatosBackpropagationPrimitivoRepository
    {
        private List<DatosBackpropagationPrimitivo> datosBackpropagationPrimitivos;
        private string ruta;

        //-------------------------------------------------------------------------------------------
        public IList<DatosBackpropagationPrimitivo> PintarUmbral(string ruta)
        {

            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public IList<DatosBackpropagationPrimitivo> PintarPesoInicial(string ruta)
        {

            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesosActualizar(string W, string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo Actualizar {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoPesoInicialesActualizar(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo Actualizar {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationPrimitivo> PintarPesoInicialActualizar(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo Actualizar {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarPesosIniciales(string W, string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W}");
            escritor.Close();
            file.Close();
        }
        public void EliminarPesoIniciales(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationPrimitivo> ConsultarPesosInicial(string tipo)
        {
            ruta = $"Peso Iniciales Backpropagation Primitivo {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.W = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarUmbralActualizar(string U, string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo Actualizar {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoUmbralActualizar(string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo Actualizar {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationPrimitivo> PintarUmbralActualizar(string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo Actualizar {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarUmbral(string U, string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U}");
            escritor.Close();
            file.Close();
        }
        public void EliminarArchivoUmbral(string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo {tipo}.txt";
            File.Delete(ruta);
        }
        public IList<DatosBackpropagationPrimitivo> ConsultarUmbral(string tipo)
        {
            ruta = $"Ubral Backpropagation Primitivo {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.U = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarFuncionActivacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationPrimitivo> PintarFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public void EliminarArchivoFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion {tipo}.txt";
            File.Delete(ruta);
        }
        //-------------------------------------------------------------------------------------------
        public void GuardarDerivadaFuncionActivacion(string DerivadaFuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Primitivo Derivada Funcion Activacion {tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{DerivadaFuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationPrimitivo> PintarDerivadaFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Derivada Funcion Activacion {tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.DerivadaFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public void EliminarArchivoDerivadaFuncionActivacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Derivada Funcion Activacion {tipo}.txt";
            File.Delete(ruta);
        }

        //-------------------------------------------------------------------------------------------
        public void GuardarENi(string ENi)
        {
            ruta = $"Backpropagation Primitivo ENi.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{ENi}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationPrimitivo> PintarENi()
        {
            ruta = $"Backpropagation Primitivo ENi.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.ENi = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public void EliminarENi()
        {
            ruta = $"Backpropagation Primitivo ENi.txt";
            File.Delete(ruta);
        }

        //-------------------------------------------------------------------------------------------
        public void GuardarENl(string ENl)
        {
            ruta = $"Backpropagation Primitivo ENl.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{ENl}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationPrimitivo> PintarENl()
        {
            ruta = $"Backpropagation Primitivo ENl.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.ENl = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public void EliminarENl()
        {
            ruta = $"Backpropagation Primitivo ENl.txt";
            File.Delete(ruta);
        }
        public void GuardarFuncionActivacionSimulacion(string FuncionActivacion, string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion Simulacion{tipo}.txt";
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{FuncionActivacion}");
            escritor.Close();
            file.Close();
        }
        public IList<DatosBackpropagationPrimitivo> PintarFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion Simulacion{tipo}.txt";
            datosBackpropagationPrimitivos = new List<DatosBackpropagationPrimitivo>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosBackpropagationPrimitivo.NumFuncionActivacion = Convert.ToDecimal(Datos[0]);
                datosBackpropagationPrimitivos.Add(datosBackpropagationPrimitivo);
            }
            reader.Close();
            file.Close();
            return datosBackpropagationPrimitivos;
        }
        public void EliminarArchivoFuncionActivacionSimulacion(string tipo)
        {
            ruta = $"Backpropagation Primitivo Funcion Activacion Simulacion{tipo}.txt";
            File.Delete(ruta);
        }
    }
}
