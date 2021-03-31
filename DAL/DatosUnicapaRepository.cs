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
    public class DatosUnicapaRepository
    {
        private List<DatosUnicapa> DatosUnicapas;
        private string ruta;//= "Datos de peso iniciales.txt";

        // UBICACION DE LOS TXT DEL PROYECTO
        //Unicapa_IA\UnicapaInteligenciaArtificial\UnicapaInteligenciaArtificial\bin\Debug
        public List<DatosUnicapa> PintarTabla1(string ruta)
        {
            DatosUnicapas = new List<DatosUnicapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosUnicapa datosUnicapa = new DatosUnicapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);

                datosUnicapa.X1 = Convert.ToDouble(Datos[0]);
                datosUnicapa.X2 = Convert.ToDouble(Datos[1]);
                datosUnicapa.YD1 = Convert.ToDecimal(Datos[2]);
                DatosUnicapas.Add(datosUnicapa);

            }
            reader.Close();
            file.Close();
            return DatosUnicapas;

        }
        public List<DatosUnicapa> PintarTabla2(string ruta)
        {
            DatosUnicapas = new List<DatosUnicapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosUnicapa datosUnicapa = new DatosUnicapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosUnicapa.W1 = Convert.ToDecimal(Datos[0]);
                datosUnicapa.W2 = Convert.ToDecimal(Datos[1]);
                DatosUnicapas.Add(datosUnicapa);
            }
            reader.Close();
            file.Close();
            return DatosUnicapas;
        }
        public List<DatosUnicapa> PintarTabla3(string ruta)
        {

            DatosUnicapas = new List<DatosUnicapa>();
            string linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while ((linea = reader.ReadLine()) != null)
            {
                DatosUnicapa datosUnicapa = new DatosUnicapa();
                char delimiter = ';';
                string[] Datos = linea.Split(delimiter);
                datosUnicapa.U = Convert.ToDecimal(Datos[0]);
                DatosUnicapas.Add(datosUnicapa);
            }
            reader.Close();
            file.Close();
            return DatosUnicapas;
        }

        //decimal W11 = Convert.ToDecimal(TextoW11.Text), W21 = Convert.ToDecimal(TextoW11.Text);
        public void GuardarPesos(string W11, string W21)
        {
            ruta = $"Datos de peso iniciales_{W11+"_"+W21}.txt";
            FileStream file = new FileStream(ruta, FileMode.Create);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{W11};{W21}");
            escritor.Close();
            file.Close();
        }
        public void GuardarUmbrales(string U1)
        {
            ruta = $"Datos de umbrales_{U1}.txt";
            FileStream file = new FileStream(ruta, FileMode.Create);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{U1}");
            escritor.Close();
            file.Close();
        }
    }
}
