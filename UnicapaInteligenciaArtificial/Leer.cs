using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BlocNotasToDatagridview
{
   public class Leer
   {
        public int Ent = 0;
        public int Sal = 0;
        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;
            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;
            do
            {
                sLine = objReader.ReadLine();
                if ((sLine != null))
                {
                    if (fila == 0)
                    {
                        tabla.ColumnCount = sLine.Split(caracter).Length;
                        nombrarTitulo(tabla, sLine.Split(caracter));
                        fila += 1;
                    }
                    else
                    {
                        agregarFilaDatagridview(tabla, sLine, caracter);
                        fila += 1;
                    }
                }
            }
            while (!(sLine == null));
            objReader.Close();
        }
        public void nombrarTitulo(DataGridView tabla, string[] titulos)
        {
            Ent = 0;
            Sal = 0;
            int x = 0;
            for (x = 0; x <= tabla.ColumnCount - 1; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];

                if (tabla.Columns[x].HeaderText.Contains("X"))
                {
                    Ent++;
                }
                else if (tabla.Columns[x].HeaderText.Contains("Y"))
                {
                    Sal++;
                }
            }
        }
        public void agregarFilaDatagridview(DataGridView tabla, string linea, char caracter)
        {
            string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }

    }
}

