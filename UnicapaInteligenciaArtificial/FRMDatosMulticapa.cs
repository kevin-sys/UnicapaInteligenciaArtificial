using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BlocNotasToDatagridview;
using ENTITY;

namespace UnicapaInteligenciaArtificial
{
    public partial class FRMDatosMulticapa : Form
    {
        Leer l = new Leer();
        public string ARCHIVO = "";

        DatosMulticapa datosMulticapa = new DatosMulticapa();
        DatosMulticapaService datosMulticapaService = new DatosMulticapaService();

        IList<DatosMulticapa> listaEntradaSalida = new List<DatosMulticapa>();
        IList<DatosMulticapa> listaNumeroNeuronasxCapa = new List<DatosMulticapa>();
        IList<DatosMulticapa> listaFuncionActivacionCapaSalida = new List<DatosMulticapa>();

        IList<DatosMulticapa> listaPesosActualizar = new List<DatosMulticapa>();
        IList<DatosMulticapa> listaUmbralActualzar = new List<DatosMulticapa>();
        IList<DatosMulticapa> listaNumActivacion = new List<DatosMulticapa>();
        IList<DatosMulticapa> listaSimulacion = new List<DatosMulticapa>();

        IList<decimal> lista_EP = new List<decimal>();
        IList<decimal> lista_ERMS = new List<decimal>();

        IList<decimal> listaW = new List<decimal>();
        IList<decimal> listaU = new List<decimal>();
        IList<decimal> listaX = new List<decimal>();
        IList<decimal> listaCapa = new List<decimal>();
        IList<decimal> listaActivacion = new List<decimal>();
        IList<decimal> listaActivacion2 = new List<decimal>();
        IList<decimal> listaActivacion3 = new List<decimal>();

        IList<decimal> listaPesos = new List<decimal>();
        IList<decimal> listaUmbrales = new List<decimal>();

        public FRMDatosMulticapa()
        {
            InitializeComponent();
            Ocultar();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FRMDatosUnicapa_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            FRMInicial inicial = new FRMInicial();
            inicial.Show();
            this.Hide();
        }

        private void BotonSali_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void Ocultar()
        {
            TextoEntradasC.Enabled = false;
            TextoSalidaC.Enabled = false;
            TextoPatronesC.Enabled = false;
            ComboFuncionActivacion.SelectedIndex = 0;
            ComboFuncionActivacionSalida.SelectedIndex = 0;
            TextoCapaOculta.Text = "";
            TextoCapaOculta.Enabled = false;

            TextoEntradas.Enabled = false;
            TextoSalidas.Enabled = false;
            TextoPatrones.Enabled = false;
        }

        private void BotonDatosE_S_Click(object sender, EventArgs e)
        {
            cargarArchivo();
            TextoEntradasC.Text = l.Ent.ToString();
            TextoSalidaC.Text = l.Sal.ToString();
            TextoPatronesC.Text = TablaDatosEntradaSalida.RowCount.ToString();

            TextoEntradas.Text = l.Ent.ToString();
            TextoSalidas.Text = l.Sal.ToString();
            TextoPatrones.Text = TablaDatosEntradaSalida.RowCount.ToString();
        }
        public void cargarArchivo()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " TXT | *.txt;";
                openFileDialog.Title = " IMPORTAR DATOS DE ENTRADA Y SALIDA ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                        ARCHIVO = openFileDialog.FileName;
                        l.lecturaArchivo(TablaDatosEntradaSalida,';',ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString());
            }
        }
        
        int Num = 1;
        int Num3 = 1;
        int Cont_Capas = 0;
        string resp;
        int cotResp = 0;
        decimal NumW = 0;
        private void BotonNumeroNeuronas_Click(object sender, EventArgs e)
        { 
            int Capas = Convert.ToInt32(TextoNumeroCapasOcultasC.Text);

            if (Capas >= Num)
            {
                listaNumeroNeuronasxCapa.Clear();

                datosMulticapa.NumeroCapas = Num.ToString();
                datosMulticapa.NumeroNeuronasXCapas = TextoNumeroNeuronasXCapaC.Text;
                datosMulticapa.FuncionActivacion = ComboFuncionActivacion.Text;

                listaNumeroNeuronasxCapa.Add(datosMulticapa);
                
                foreach (var item in listaNumeroNeuronasxCapa)
                {   
                    TablaCapasNeurona.Rows.Add(item.NumeroCapas,item.NumeroNeuronasXCapas,item.FuncionActivacion);
                }

                TextoNumeroNeuronasXCapaC.Text = "";
                ComboFuncionActivacion.SelectedIndex = 0;
                Num++;
            }
            else
            {
                MessageBox.Show(" Numero de neuronas por capas guardadas correctamente");
                TextoNumeroNeuronasXCapaC.Text = "";
                TextoNumeroCapasOcultasC.Enabled = false;
                TextoNumeroNeuronasXCapaC.Enabled = false;
                ComboFuncionActivacion.Enabled = false;
                BotonNumeroNeuronas.Enabled = false;
                ComboFuncionActivacion.SelectedIndex = 0;
                Num = 1;
            }
        }

        private void BotonRegistrarFunActivaSalida_Click(object sender, EventArgs e)
        {
            int Capas = Convert.ToInt32(TextoSalidaC.Text);

            if (Capas >= Num3)
            {
                listaFuncionActivacionCapaSalida.Clear();

                datosMulticapa.NumeroCapas = Num3.ToString();
                datosMulticapa.FuncionActivacion = ComboFuncionActivacionSalida.Text;

                listaFuncionActivacionCapaSalida.Add(datosMulticapa);
                
                foreach (var item in listaFuncionActivacionCapaSalida)
                {
                    TablaCapaSalida.Rows.Add(item.NumeroCapas, item.FuncionActivacion);
                }
                ComboFuncionActivacionSalida.SelectedIndex = 0;
                Num3++;
            }
            else
            {
                MessageBox.Show("Funcion de activacion de las capas de salida guardadas correctamente");
                ComboFuncionActivacionSalida.Enabled = false;
                BotonRegistrarFunActivaSalida.Enabled = false;
                ComboFuncionActivacionSalida.SelectedIndex = 0;
                Num3 = 1;
            }
        }

        private void BotonReiniciar_Click(object sender, EventArgs e)
        {
            TextoEntradasC.Text = "";
            TextoSalidaC.Text = "";
            TextoPatronesC.Text = "";
            
            TextoNumeroNeuronasXCapaC.Text = "";
            TextoNumeroCapasOcultasC.Text = "";

            TextoNumeroCapasOcultasC.Enabled = true;
            TextoNumeroNeuronasXCapaC.Enabled = true;

            ComboFuncionActivacion.Enabled = true;
            BotonNumeroNeuronas.Enabled = true;
            BotonRegistrarFunActivaSalida.Enabled = true;
            ComboFuncionActivacionSalida.Enabled = true;

            ComboFuncionActivacionSalida.SelectedIndex = 0;
            ComboFuncionActivacion.SelectedIndex = 0;

            NumUmbral = 0;
            NumPesosI = 0;
            Num3 = 1;

            FRMDatosMulticapa fRMDatosMulticapa = new FRMDatosMulticapa();
            fRMDatosMulticapa.Refresh();

            TablaCapaSalida.Rows.Clear();
            TablaCapasNeurona.Rows.Clear();
            TablaDatosEntradaSalida.Rows.Clear();
            TablaDatosPesosIniciales.Rows.Clear();
            TablaDatosUmbrales.Rows.Clear();
        }
        private void BotonPeso_Iniciales_Click(object sender, EventArgs e)
        {
            cargarPeso();
        }
        public void cargarPeso()
        {
            MapearPeso();
        }

        int NumUmbral = 0;
        int NumPesosI = 0;
        private void MapearPeso()
        {
            NumPesosI++;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " TXT | *.txt;";
                openFileDialog.Title = " IMPORTAR PESO INICIAL ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ARCHIVO = openFileDialog.FileName;
                    l.lecturaArchivo(TablaDatosPesosIniciales, ';', ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void BotonDatosUmbrales_Click(object sender, EventArgs e)
        {
            cargarUmbral();
        }
        public void cargarUmbral()
        {
            MapearUmbral();
        }

        private void MapearUmbral()
        {
            NumUmbral++;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " TXT | *.txt;";
                openFileDialog.Title = " IMPORTAR UMBRAL";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ARCHIVO = openFileDialog.FileName;
                    l.lecturaArchivo(TablaDatosUmbrales, ';', ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        int aX = 0, bW = 0, cU = 0;
        decimal X = 0, W = 0, U = 0;
        int i = 0, j = 0, k = 0, m = 0;
        int num4 = 1;
        decimal NumCapa = 0;
        decimal Sum = 0;
        decimal FunActivacion = 0;
        int CapaOculta = 0;
        string Nombrefunciaon;
        int Var1 = 0;
        int Var2 = 0;
        int Var3 = 0;
        int Cont = 1;
        int final = 1;
        int ContaGlo = 1;
        int YD = 0;
        decimal EP = 0;
        decimal ERMS = 0;
        decimal EL = 0;

        public void cargarArchivoSimulacion()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " TXT | *.txt;";
                openFileDialog.Title = " IMPORTAR DATOS DE SIMULACION ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ARCHIVO = openFileDialog.FileName;
                    l.lecturaArchivo(TablaSimulacion, ';', ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void BotonDatosEntradaSalidaSimulacion_Click(object sender, EventArgs e)
        {
            cargarArchivoSimulacion();
        }

        int sum1,sum2;
        private void BotonSimulacion_Click(object sender, EventArgs e)
        {

            patron++;
            
            int suma1 = 0;
            int suma2 = 0;

            suma1 = Convert.ToInt32(TextoNumeroCapasOcultasC.Text);
            suma2 = Convert.ToInt32(TextoSalidaC.Text);

            for (int p = 0; p < (Convert.ToInt32(TextoEntradas.Text)); p++)
            {
                for (int q = 0; q < TablaSimulacion.RowCount; q++)
                {
                    if (q == m)
                    {
                        X = Convert.ToDecimal(TablaSimulacion.Rows[q].Cells[p].Value.ToString());
                        //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                        listaX.Add(X);
                    }
                }
            }

            listaPesosActualizar.Clear();
            listaUmbralActualzar.Clear();
            listaCapa.Clear();
            listaActivacion.Clear();
            listaActivacion2.Clear();

            for (int p = 1; p <= (suma1 + suma2); p++)
            {
                listaPesosActualizar = datosMulticapaService.PintarPesoInicialActualizarFinal(p.ToString());
                listaUmbralActualzar = datosMulticapaService.PintarUmbralActualizarFinal(p.ToString());

                int index = 0;
                int index2 = 0;
                int Cont_index = 1;

                if (p == 1)
                {
                    for (int q = 0; q < listaUmbralActualzar.Count; q++)
                    {
                        for (int i = 0; i < listaPesosActualizar.Count; i++)
                        {
                            for (int t = 0; t < listaX.Count; t++)
                            {
                                if (i == index && t == index2 && Cont_index <= listaX.Count)
                                {
                                    W = listaPesosActualizar[i].W;
                                    U = listaUmbralActualzar[q].U;
                                    X = listaX[t];
                                    //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                    NumCapa = datosMulticapa.Capa(X, W, U);
                                    listaCapa.Add(NumCapa);
                                    index++;
                                    index2++;
                                    Cont_index++;
                                }
                            }
                        }
                        Sum = listaCapa.Sum();
                        //MessageBox.Show(Sum.ToString());
                        listaActivacion.Add(Sum);
                        listaCapa.Clear();
                        Cont_index = 1;
                        index2 = 0;
                    }
                }
                else
                {
                    listaNumActivacion = datosMulticapaService.PintarFuncionActivacion((p - 1).ToString());

                    for (int q = 0; q < listaUmbralActualzar.Count; q++)
                    {
                        for (int i = 0; i < listaPesosActualizar.Count; i++)
                        {
                            for (int t = 0; t < listaNumActivacion.Count; t++)
                            {
                                if (i == index && t == index2 && Cont_index <= listaNumActivacion.Count)
                                {
                                    W = listaPesosActualizar[i].W;
                                    U = listaUmbralActualzar[q].U;
                                    X = listaNumActivacion[t].NumFuncionActivacion;
                                    //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                    NumCapa = datosMulticapa.Capa(X, W, U);
                                    //MessageBox.Show(NumCapa.ToString());
                                    listaCapa.Add(NumCapa);
                                    index++;
                                    index2++;
                                    Cont_index++;
                                }
                            }
                        }
                        Sum = listaCapa.Sum();
                        //MessageBox.Show(Sum.ToString());
                        listaActivacion.Add(Sum);
                        listaCapa.Clear();
                        Cont_index = 1;
                        index2 = 0;
                    }
                }


                if (p <= Convert.ToInt32(TextoNumeroCapasOcultasC.Text))
                {
                    for (int t = 0; t < TablaCapasNeurona.RowCount - 1; t++)
                    {
                        int num5 = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[0].Value.ToString());
                        if (num5 == p)
                        {
                            TextoCapaOculta.Text = TablaCapasNeurona.Rows[t].Cells[0].Value.ToString();
                            Nombrefunciaon = TablaCapasNeurona.Rows[t].Cells[2].Value.ToString();
                            CapaOculta = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[1].Value.ToString());
                        }
                    }
                }
                else
                {
                    for (int t = 0; t < TablaCapaSalida.RowCount - 1; t++)
                    {
                        int num5 = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                        if (p == (suma1 + num5))
                        {
                            CapaOculta = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                            Nombrefunciaon = TablaCapaSalida.Rows[t].Cells[1].Value.ToString();
                        }
                    }
                }

                //MessageBox.Show(Nombrefunciaon);

                foreach (var item in listaActivacion)
                {
                    if (Nombrefunciaon == "IDENTIDAD")
                    {
                        FunActivacion = datosMulticapa.Identidad(item);
                    }
                    else if (Nombrefunciaon == "ESCALON")
                    {
                        FunActivacion = datosMulticapa.Escalon(item);
                    }
                    else if (Nombrefunciaon == "LINEA A TRAMOS")
                    {
                        FunActivacion = datosMulticapa.Lineal_Tramos(item);
                    }
                    else if (Nombrefunciaon == "SIGMOIDEA")
                    {
                        FunActivacion = datosMulticapa.Sigmoidea(Convert.ToDouble(item));
                    }
                    else if (Nombrefunciaon == "GAUSSIANA")
                    {
                        FunActivacion = datosMulticapa.Gaussiana(Convert.ToDouble(item));
                    }
                    else if (Nombrefunciaon == "SINUSOIDAL")
                    {
                        FunActivacion = datosMulticapa.Sinusoidal(Convert.ToDouble(item));
                    }
                    //MessageBox.Show("FUNCION ACTIV = " + FunActivacion.ToString());
                    listaActivacion2.Add(FunActivacion);
                }

                foreach (var item in listaActivacion2)
                {
                    datosMulticapaService.GuardarFuncionActivacionSimulacion(item.ToString(), p.ToString());
                }

                listaActivacion2.Clear();
                listaActivacion.Clear();

                if (p == (suma1 + suma2))
                {
                    for (int i = 0; i < (suma1 + suma2); i++)
                    {
                        listaSimulacion = datosMulticapaService.PintarFuncionActivacionSimulacion((i+1).ToString());

                        for (int j = 0; j < listaSimulacion.Count; j++)
                        {
                            Grafica2.Series["ChartLinea"].Points.AddXY(iteracion2, listaSimulacion[j].NumFuncionActivacion);
                            iteracion2++;
                        }

                        MessageBox.Show("CAPA");
                        listaSimulacion.Clear();
                        Grafica2.ResetAutoValues();
                    } 
                }
            }
            m++;
    }

        private void TablaSimulacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        Boolean segir = false;
        int iteracion = 1;
        int iteracion2 = 1;
        int patron = 1;
        Boolean iteracion_Siguiente = false;
        Boolean patron_Siguiente = false;

        private void BotonEntrenar_Click(object sender, EventArgs e)
        {
            int suma1 = 0;
            int suma2 = 0;

            TextoRataAprendizaje.Enabled = false;
            TextoErrorPermitido.Enabled = false;
            TextoNumeroMaxIteraciones.Enabled = false;

            suma1 = Convert.ToInt32(TextoNumeroCapasOcultasC.Text);
            suma2 = Convert.ToInt32(TextoSalidaC.Text);
            for (int p = 1; p <= (suma1+suma2); p++)
            {
                datosMulticapaService.EliminarArchivoPesoIniciales(p.ToString());
                datosMulticapaService.EliminarArchivoUmbrales(p.ToString());
            }

            do
            {
                MapearDatos();

                do
                {
                    for (int q = 0; q < listaX.Count; q++)
                    {
                        if (q == Var1)
                        {
                            X = listaX[q];
                        }
                    }
                    for (int q = 0; q < listaW.Count; q++)
                    {
                        if (q == Var1)
                        {
                            W = listaW[q];
                        }
                    }

                    for (int q = 0; q < listaU.Count; q++)
                    {
                        if (q == Var2)
                        {
                            U = listaU[q];
                        }
                    }

                    NumCapa = datosMulticapa.Capa(X, W, U);
                    listaCapa.Add(NumCapa);

                    if (Cont == (TablaDatosEntradaSalida.Columns.Count - l.Sal))
                    {
                        Var3 = 1;
                        Var2++;
                        Var1 = 0;
                        Cont = 1;
                        foreach (var item in listaCapa)
                        {
                            Sum = listaCapa.Sum();
                        }
                        listaCapa.Clear();
                        //hacer funciaon de activacion

                        if (Nombrefunciaon == "IDENTIDAD")
                        {
                            FunActivacion = datosMulticapa.Identidad(Sum);
                        }
                        else if (Nombrefunciaon == "ESCALON")
                        {
                            FunActivacion = datosMulticapa.Escalon(Sum);
                        }
                        else if (Nombrefunciaon == "LINEA A TRAMOS")
                        {
                            FunActivacion = datosMulticapa.Lineal_Tramos(Sum);
                        }
                        else if (Nombrefunciaon == "SIGMOIDEA")
                        {
                            FunActivacion = datosMulticapa.Sigmoidea(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "GAUSSIANA")
                        {
                            FunActivacion = datosMulticapa.Gaussiana(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "SINUSOIDAL")
                        {
                            FunActivacion = datosMulticapa.Sinusoidal(Convert.ToDouble(Sum));
                        }
                        listaActivacion.Add(FunActivacion);
                        
                    }
                    else
                    {
                        Var1++;
                        Cont++;
                    }

                } while (Var3 == 0);
                
                Var3 = 0;
                
                if (ContaGlo == CapaOculta)
                {
                    segir = true;
                    NumCapa = 0;
                    Sum = 0;
                    FunActivacion = 0;
                    CapaOculta = 0;
                    Var1 = 0;
                    Var2 = 0;
                    Var3 = 0;
                    Cont = 1;
                    final = 1;
                    ContaGlo = 0;
                    aX = 0; bW = 0; cU = 0;
                    X = 0; W = 0; U = 0;
                    i = 0; j = 0; k = 0; m = 0;
                }

                ContaGlo++;

                if (i == TablaDatosPesosIniciales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    bW++;
                    i = 0;
                    listaW.Clear();
                }

                if (j == TablaDatosUmbrales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    cU++;
                    j = 0;
                    listaU.Clear();
                }

                if (k == (TablaDatosEntradaSalida.Columns.Count - l.Sal))
                {
                    //MessageBox.Show("SIGUIENTE FILA");
                    aX++;
                    m++;
                    k = 0;
                    listaU.Clear();
                }

                if (segir == true)
                {
                    final = 0;

                    foreach (var item in listaPesos)
                    {
                        resp = datosMulticapaService.GuardarPesos(item.ToString(), NumPesosI.ToString());
                    }

                    foreach (var item in listaUmbrales)
                    {
                        resp = datosMulticapaService.GuardarUmbrales(item.ToString(), NumUmbral.ToString());
                    }

                    foreach (var item in listaActivacion)
                    {
                        resp = datosMulticapaService.GuardarFuncionActivacion(item.ToString(), num4.ToString());
                    }

                    listaUmbrales.Clear();
                    listaPesos.Clear();
                }

            } while (final == 1);

            aX = 0; bW = 0; cU = 0;
            X = 0; W = 0; U = 0;
            cotResp = 0;
            num4++;
            i = 0; j = 0; k = 0; m = 0;
            listaU.Clear();
            listaW.Clear();
            listaX.Clear();

            segir = false;
            final = 1;
            MessageBox.Show("SIGUIENTE CAPA");
            
            TablaDatosPesosIniciales.Rows.Clear();
            TablaDatosUmbrales.Rows.Clear();

            MapearPeso();
            MapearUmbral();

            do
            {
                for (int p = 0; p < TablaCapasNeurona.RowCount - 1; p++)
                {
                    int num5 = Convert.ToInt32(TablaCapasNeurona.Rows[p].Cells[0].Value.ToString());
                    if (num5 == num4)
                    {
                        TextoCapaOculta.Text = TablaCapasNeurona.Rows[p].Cells[0].Value.ToString();
                        Nombrefunciaon = TablaCapasNeurona.Rows[p].Cells[2].Value.ToString();
                        CapaOculta = Convert.ToInt32(TablaCapasNeurona.Rows[p].Cells[1].Value.ToString());
                    }
                }

                
                for (int p = 0; p < TablaDatosPesosIniciales.Columns.Count; p++)
                {
                    for (int q = 0; q < TablaDatosPesosIniciales.RowCount; q++)
                    {
                        if (p == bW)
                        {
                            W = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[q].Cells[p].Value.ToString());
                            //MessageBox.Show("["+(q+1)+"]["+p+"] "+W.ToString());
                            i++;
                            listaW.Add(W);
                            listaPesos.Add(W);
                        }
                    }
                }

                
                for (int p = 0; p < TablaDatosUmbrales.Columns.Count; p++)
                {
                    for (int q = 0; q < TablaDatosUmbrales.RowCount; q++)
                    {
                        if (p == cU)
                        {
                            U = Convert.ToDecimal(TablaDatosUmbrales.Rows[q].Cells[p].Value.ToString());
                            //MessageBox.Show("[" + (q + 1) + "][" + p + "] " + U.ToString());
                            j++;
                            listaU.Add(U);
                            listaUmbrales.Add(U);
                        }
                    }
                }

                //MessageBox.Show((TablaDatosEntradaSalida.Columns.Count - l.Sal).ToString() +"//"+(TablaDatosEntradaSalida.RowCount).ToString());
                
                for (int p = 0; p < listaActivacion.Count ; p++)
                {
                      if (p == aX)
                        {
                            //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                            k++;
                        }

                    X = listaActivacion[p];
                    listaX.Add(X);
                }
                //RECTIFICAR VALOR DE X

                if (cU == TablaDatosUmbrales.Columns.Count)
                {
                    cU = 0;
                }

                if (bW == TablaDatosPesosIniciales.Columns.Count)
                {
                    bW = 0;
                }

                if (aX == listaActivacion.Count)
                {
                    aX = 0;
                    m = 0;
                }

                do
                {
                    for (int q = 0; q < listaX.Count; q++)
                    {
                        if (q == Var1)
                        {
                            X = listaX[q];
                        }
                    }

                    for (int q = 0; q < listaW.Count; q++)
                    {
                        if (q == Var1)
                        {
                            W = listaW[q];
                        }
                    }

                    for (int q = 0; q < listaU.Count; q++)
                    {
                        if (q == Var2)
                        {
                            U = listaU[q];
                        }
                    }

                    //MessageBox.Show(X+"//"+W + "//" + U);
                    NumCapa = datosMulticapa.Capa(X, W, U);
                    listaCapa.Add(NumCapa);

                    if (Cont == listaActivacion.Count)
                    {
                        Var3 = 1;
                        Var2++;
                        Var1 = 0;
                        Cont = 1;
                        foreach (var item in listaCapa)
                        {
                            Sum = listaCapa.Sum();
                        }
                        listaCapa.Clear();
                        //hacer funciaon de activacion

                        if (Nombrefunciaon == "IDENTIDAD")
                        {
                            FunActivacion = datosMulticapa.Identidad(Sum);
                        }
                        else if (Nombrefunciaon == "ESCALON")
                        {
                            FunActivacion = datosMulticapa.Escalon(Sum);
                        }
                        else if (Nombrefunciaon == "LINEA A TRAMOS")
                        {
                            FunActivacion = datosMulticapa.Lineal_Tramos(Sum);
                        }
                        else if (Nombrefunciaon == "SIGMOIDEA")
                        {
                            FunActivacion = datosMulticapa.Sigmoidea(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "GAUSSIANA")
                        {
                            FunActivacion = datosMulticapa.Gaussiana(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "SINUSOIDAL")
                        {
                            FunActivacion = datosMulticapa.Sinusoidal(Convert.ToDouble(Sum));
                        }
                        listaActivacion2.Add(FunActivacion);
                    }
                    else
                    {
                        Var1++;
                        Cont++;
                    }

                } while (Var3 == 0);


                Var3 = 0;
                //MessageBox.Show(ContaGlo + "//" + Sum + "--->" + FunActivacion);

                if (ContaGlo == CapaOculta)
                {
                    segir = true;
                    NumCapa = 0;
                    Sum = 0;
                    FunActivacion = 0;
                    CapaOculta = 0;
                    Var1 = 0;
                    Var2 = 0;
                    Var3 = 0;
                    Cont = 1;
                    final = 1;
                    ContaGlo = 0;
                    aX = 0; bW = 0; cU = 0;
                    X = 0; W = 0; U = 0;
                    i = 0; j = 0; k = 0; m = 0;
                }

                ContaGlo++;

                if (i == TablaDatosPesosIniciales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    bW++;
                    i = 0;
                    listaW.Clear();
                }

                if (j == TablaDatosUmbrales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    cU++;
                    j = 0;
                    listaU.Clear();
                }

                if (k == listaActivacion.Count)
                {
                    //MessageBox.Show("SIGUIENTE FILA");
                    aX++;
                    m = 0;
                    k = 0;
                    listaX.Clear();
                }

                if (segir == true)
                {
                    foreach (var item in listaActivacion2)
                    {
                        resp = datosMulticapaService.GuardarFuncionActivacion(item.ToString(), num4.ToString());
                    }

                    if (num4 == Convert.ToInt32(TextoNumeroCapasOcultasC.Text))
                    {
                        final = 0;
                    }
                    else
                    {
                        num4++;
                        TablaDatosPesosIniciales.Rows.Clear();
                        TablaDatosUmbrales.Rows.Clear();
                        MapearPeso();
                        MapearUmbral();
                        listaActivacion.Clear();
                        listaActivacion = listaActivacion2;
                        listaActivacion2.Clear();
                    }

                    foreach (var item in listaPesos)
                    {
                        resp = datosMulticapaService.GuardarPesos(item.ToString(), NumPesosI.ToString());
                    }

                    foreach (var item in listaUmbrales)
                    {
                        resp = datosMulticapaService.GuardarUmbrales(item.ToString(), NumUmbral.ToString());
                    }

                    listaUmbrales.Clear();
                    listaPesos.Clear();
                }
            } while (final == 1);
            
            aX = 0; bW = 0; cU = 0;
            X = 0; W = 0; U = 0;
            Cont_Capas = num4;
            Cont_Capas++;
            num4 = 1;
            i = 0; j = 0; k = 0; m = 0;
            listaU.Clear();
            listaW.Clear();
            listaX.Clear();
            lista_EP.Clear();
            segir = false;
            final = 1;
            MessageBox.Show("SIGUIENTE CAPA");

            TablaDatosPesosIniciales.Rows.Clear();
            TablaDatosUmbrales.Rows.Clear();

            MapearPeso();
            MapearUmbral();
            //realizar capa de salida

            do
            {
                for (int p = 0; p < TablaCapaSalida.RowCount - 1; p++)
                {
                    int num5 = Convert.ToInt32(TablaCapaSalida.Rows[p].Cells[0].Value.ToString());
                    if (num5 == num4)
                    {
                        CapaOculta = Convert.ToInt32(TablaCapaSalida.Rows[p].Cells[0].Value.ToString());
                        Nombrefunciaon = TablaCapaSalida.Rows[p].Cells[1].Value.ToString();
                        
                    }
                }

                for (int p = 0; p < TablaDatosPesosIniciales.Columns.Count; p++)
                {
                    for (int q = 0; q < TablaDatosPesosIniciales.RowCount; q++)
                    {
                        if (p == bW)
                        {
                            W = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[q].Cells[p].Value.ToString());
                            //MessageBox.Show("["+(q+1)+"]["+p+"] "+W.ToString());
                            i++;
                            listaW.Add(W);
                            listaPesos.Add(W);
                        }
                    }
                }

                for (int p = 0; p < TablaDatosUmbrales.Columns.Count; p++)
                {
                    for (int q = 0; q < TablaDatosUmbrales.RowCount; q++)
                    {
                        if (p == cU)
                        {
                            U = Convert.ToDecimal(TablaDatosUmbrales.Rows[q].Cells[p].Value.ToString());
                            //MessageBox.Show("[" + (q + 1) + "][" + p + "] " + U.ToString());
                            j++;
                            listaU.Add(U);
                            listaUmbrales.Add(U);
                        }
                    }
                }

                //MessageBox.Show((TablaDatosEntradaSalida.Columns.Count - l.Sal).ToString() +"//"+(TablaDatosEntradaSalida.RowCount).ToString());

                for (int p = 0; p < listaActivacion2.Count; p++)
                {
                    if (p == aX)
                    {
                        //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                        k++;
                    }

                    X = listaActivacion2[p];
                    listaX.Add(X);
                }
                //RECTIFICAR VALOR DE X

                if (cU == TablaDatosUmbrales.Columns.Count)
                {
                    cU = 0;
                }

                if (bW == TablaDatosPesosIniciales.Columns.Count)
                {
                    bW = 0;
                }

                if (aX == listaActivacion2.Count)
                {
                    aX = 0;
                    m = 0;
                }

                do
                {
                    for (int q = 0; q < listaX.Count; q++)
                    {
                        if (q == Var1)
                        {
                            X = listaX[q];
                        }
                    }

                    for (int q = 0; q < listaW.Count; q++)
                    {
                        if (q == Var1)
                        {
                            W = listaW[q];
                        }
                    }

                    for (int q = 0; q < listaU.Count; q++)
                    {
                        if (q == Var2)
                        {
                            U = listaU[q];
                        }
                    }

                    //MessageBox.Show(X+"//"+W + "//" + U);
                    NumCapa = datosMulticapa.Capa(X, W, U);
                    listaCapa.Add(NumCapa);

                    if (Cont == listaActivacion2.Count)
                    {
                        Var3 = 1;
                        Var2++;
                        Var1 = 0;
                        Cont = 1;
                        foreach (var item in listaCapa)
                        {
                            Sum = listaCapa.Sum();
                        }
                        //MessageBox.Show(Sum.ToString());
                        listaCapa.Clear();
                        //hacer funciaon de activacion

                        if (Nombrefunciaon == "IDENTIDAD")
                        {
                            FunActivacion = datosMulticapa.Identidad(Sum);
                        }
                        else if (Nombrefunciaon == "ESCALON")
                        {
                            FunActivacion = datosMulticapa.Escalon(Sum);
                        }
                        else if (Nombrefunciaon == "LINEA A TRAMOS")
                        {
                            FunActivacion = datosMulticapa.Lineal_Tramos(Sum);
                        }
                        else if (Nombrefunciaon == "SIGMOIDEA")
                        {
                            FunActivacion = datosMulticapa.Sigmoidea(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "GAUSSIANA")
                        {
                            FunActivacion = datosMulticapa.Gaussiana(Convert.ToDouble(Sum));
                        }
                        else if (Nombrefunciaon == "SINUSOIDAL")
                        {
                            FunActivacion = datosMulticapa.Sinusoidal(Convert.ToDouble(Sum));
                        }
                        listaActivacion3.Add(FunActivacion);
                    }
                    else
                    {
                        Var1++;
                        Cont++;
                    }

                } while (Var3 == 0);

                Var3 = 0;
                //MessageBox.Show(ContaGlo + "//" + Sum + "--->" + FunActivacion);

                if (ContaGlo == CapaOculta)
                {
                    segir = true;
                    NumCapa = 0;
                    Sum = 0;
                    //FunActivacion = 0;
                    CapaOculta = 0;
                    Var1 = 0;
                    Var2 = 0;
                    Var3 = 0;
                    Cont = 1;
                    final = 1;
                    ContaGlo = 0;
                    aX = 0; bW = 0; cU = 0;
                    X = 0; W = 0; U = 0;
                    i = 0; j = 0; k = 0; m = 0;
                }

                ContaGlo++;

                if (i == TablaDatosPesosIniciales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    bW++;
                    i = 0;
                    listaW.Clear();
                }

                if (j == TablaDatosUmbrales.RowCount)
                {
                    //MessageBox.Show("SIGUIENTE COLUMNA");
                    cU++;
                    j = 0;
                    listaU.Clear();
                }

                if (k == listaActivacion3.Count)
                {
                    //MessageBox.Show("SIGUIENTE FILA");
                    aX++;
                    m = 0;
                    k = 0;
                    listaX.Clear();
                }

                if (segir == true)
                {
                    foreach (var item in listaPesos)
                    {
                        resp = datosMulticapaService.GuardarPesos(item.ToString(), NumPesosI.ToString());
                    }
                    foreach (var item in listaUmbrales)
                    {
                        resp = datosMulticapaService.GuardarUmbrales(item.ToString(), NumUmbral.ToString());
                    }

                    foreach (var item in listaActivacion3)
                    {
                        resp = datosMulticapaService.GuardarFuncionActivacion(item.ToString(), Cont_Capas.ToString());
                    }

                    listaUmbrales.Clear();
                    listaPesos.Clear();

                    if (num4 == Convert.ToInt32(TextoSalidaC.Text))
                    {
                        final = 0;
                        EL = datosMulticapa.CalcularEL(YD, FunActivacion);
                        EP = datosMulticapa.CalcularEP(EL, Convert.ToInt32(TextoSalidaC.Text));
                        //MessageBox.Show("["+ YD +"/-/"+ FunActivacion + "] --> "+EL + "//" +EP);
                        lista_EP.Add(EP);
                        FunActivacion = 0;
                        NumUmbral = 0;
                        NumPesosI = 0;
                    }
                    else
                    {
                        num4++;
                        Cont_Capas++;
                        TablaDatosPesosIniciales.Rows.Clear();
                        TablaDatosUmbrales.Rows.Clear();
                        MapearPeso();
                        MapearUmbral();
                        listaActivacion2.Clear();
                        listaActivacion2 = listaActivacion3;
                        listaActivacion3.Clear();
                    }
                }
            } while (final == 1);

             decimal W2;
             decimal U2;
             decimal rata;
             decimal W_Actualizado;
             decimal U_Actualizado;
             
             rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
             listaX.Clear();

            for (int p = 0; p < Convert.ToInt32(TextoEntradas.Text); p++)
            {
                for (int q = 0; q < TablaDatosEntradaSalida.RowCount; q++)
                {
                    if (q == m && q == aX)
                    {
                        X = Convert.ToDecimal(TablaDatosEntradaSalida.Rows[q].Cells[p].Value.ToString());
                        k++;
                        listaX.Add(X);
                    }
                }
            }

            if (aX == TablaDatosEntradaSalida.Columns.Count)
            {
                aX = 0;
                m = 0;
            }
            
            int cont3 = 1;
            int cont4 = 1;
            int VAR2 = 0;

            for (int p = 1; p <= (suma1 + suma2); p++)
            {
                if (p == 1)
                {
                    for (int pp = 1; pp <= (suma1 + suma2); pp++)
                    {
                        datosMulticapaService.EliminarArchivoPesoInicialesActualizados(pp.ToString());
                        datosMulticapaService.EliminarArchivoUmbralesActualizados(pp.ToString());
                    }

                    listaPesosActualizar = datosMulticapaService.PintarPesoInicialActualizar(p.ToString());
                    listaUmbralActualzar = datosMulticapaService.PintarUmbralActualizar(p.ToString());

                    foreach (var item in listaPesosActualizar)
                    {
                        W2 = Convert.ToDecimal(item.W);

                        for (int q = 0; q < listaX.Count; q++)
                        {
                            if (q == VAR2)
                            {
                                X = listaX[q];
                            }
                        }
                        //rectificar
                        
                        if (VAR2 == (listaX.Count - 1))
                        {
                            VAR2 = 0;
                        }
                        else
                        {
                            VAR2++;
                        }

                        W_Actualizado = datosMulticapa.W_Actualizar(W2, rata, EP, X);
                        listaPesos.Add(W_Actualizado);
                        
                        if (listaPesosActualizar.Count == cont3)
                        {
                            foreach (var item2 in listaPesos)
                            {
                                resp = datosMulticapaService.GuardarPesosActualizar(item2.ToString(), p.ToString());
                            }
                            //MessageBox.Show(" W actualizado " + cont3.ToString());
                        }
                        cont3++;
                    }
                    cont3 = 1;
                    foreach (var item in listaUmbralActualzar)
                    {
                        U2 = Convert.ToDecimal(item.U);
                        
                        U_Actualizado = datosMulticapa.U_Actualizar(U2, rata, EP);
                        listaUmbrales.Add(U_Actualizado);
                        

                        if (listaUmbralActualzar.Count == cont3)
                        {
                            foreach (var item2 in listaUmbrales)
                            {
                                resp = datosMulticapaService.GuardarUmbralesActualizar(item2.ToString(), p.ToString());
                                
                            }
                            //MessageBox.Show(" U actualizado " + cont3.ToString());
                        }
                        cont3++;
                    }
                }
                else
                {
                    
                    listaPesos.Clear();
                    listaPesosActualizar.Clear();
                    listaNumActivacion.Clear();
                    listaUmbralActualzar.Clear();
                    listaUmbrales.Clear();

                    listaPesosActualizar = datosMulticapaService.PintarPesoInicialActualizar(p.ToString());
                    listaUmbralActualzar = datosMulticapaService.PintarUmbralActualizar(p.ToString());
                    listaNumActivacion = datosMulticapaService.PintarFuncionActivacion(cont4.ToString());
                    cont3 = 1;
                    VAR2 = 0;

                    foreach (var item in listaPesosActualizar)
                    {
                        W2 = Convert.ToDecimal(item.W);
                        
                        for (int q = 0; q < (listaNumActivacion.Count-1 ); q++)
                        {
                            if (q == VAR2)
                            {
                                X = listaNumActivacion[q].NumFuncionActivacion;
                            }
                        }
                        //rectificar

                        if (VAR2 == (listaNumActivacion.Count - 1))
                        {
                            VAR2 = 0;
                        }
                        else
                        {
                            VAR2++;
                        }

                        W_Actualizado = datosMulticapa.W_Actualizar(W2, rata, EP, X);
                        listaPesos.Add(W_Actualizado);

                        if (listaPesosActualizar.Count == cont3)
                        {
                            foreach (var item2 in listaPesos)
                            {
                                resp = datosMulticapaService.GuardarPesosActualizar(item2.ToString(), p.ToString());
                            }
                            //MessageBox.Show(" W actualizado " + cont3.ToString());
                        }
                        cont3++;
                    }
                    cont3 = 1;
                    foreach (var item in listaUmbralActualzar)
                    {
                        U2 = Convert.ToDecimal(item.U);

                        U_Actualizado = datosMulticapa.U_Actualizar(U2, rata, EP);
                        listaUmbrales.Add(U_Actualizado);

                        if (listaUmbralActualzar.Count == cont3)
                        {
                            foreach (var item2 in listaUmbrales)
                            {
                                resp = datosMulticapaService.GuardarUmbralesActualizar(item2.ToString(), p.ToString());
                            }
                            //MessageBox.Show(" U actualizado " + cont3.ToString());
                        }
                        cont3++;
                    }
                    cont4++;
                }
            }

            if (k == (TablaDatosEntradaSalida.Columns.Count - l.Sal))
            {
                //MessageBox.Show("SIGUIENTE FILA");
                aX++;
                m++;
                k = 0;
            }

            m = 1;

            NumCapa = 0;
            Sum = 0;
            FunActivacion = 0;

            do
            {
                //MessageBox.Show((patron).ToString() + " PATRON REALIZADO -_-");
                
                listaU.Clear();
                listaW.Clear();
                listaX.Clear();
                
                if (patron == Convert.ToInt32(TextoPatrones.Text))
                {
                    ERMS = datosMulticapa.Calcular_ERMS(lista_EP, Convert.ToInt32(TextoPatronesC.Text));

                    Grafico.Series["ChartLinea"].Points.AddXY(iteracion, ERMS);

                    lista_ERMS.Add(ERMS);

                    TablaERMS.Rows.Clear();

                    foreach (var item in lista_ERMS)
                    {
                        TablaERMS.Rows.Add(Math.Round(item, 5).ToString());
                    }

                    if (iteracion == Convert.ToInt32(TextoNumeroMaxIteraciones.Text) || ERMS <= Convert.ToDecimal(TextoErrorPermitido.Text))
                    {
                        patron_Siguiente = true;
                        MessageBox.Show(" ENTRENAMIENTO FINALIZADO ....");
                    }
                    else
                    {
                        patron = 0;
                        lista_EP.Clear();
                        iteracion++;
                        m = 0;
                    }
                }
                else
                {
                    patron++;
                    patron_Siguiente = false;

                    for (int p = 0; p < (Convert.ToInt32(TextoEntradas.Text)); p++)
                    {
                        for (int q = 0; q < TablaDatosEntradaSalida.RowCount; q++)
                        {
                            if (q == m)
                            {
                                X = Convert.ToDecimal(TablaDatosEntradaSalida.Rows[q].Cells[p].Value.ToString());
                                //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                                listaX.Add(X);
                            }
                        }
                    }

                    for (int p = 0; p <= Convert.ToInt32(TextoEntradas.Text); p++)
                    {
                        for (int q = 0; q < TablaDatosEntradaSalida.RowCount; q++)
                        {
                            if (p == Convert.ToInt32(TextoEntradas.Text) && q == m)
                            {
                                YD = Convert.ToInt32(TablaDatosEntradaSalida.Rows[q].Cells[p].Value.ToString());
                                //MessageBox.Show(YD.ToString());
                            }
                        }
                    }

                    listaPesosActualizar.Clear();
                    listaUmbralActualzar.Clear();
                    listaCapa.Clear();
                    listaActivacion.Clear();
                    listaActivacion2.Clear();

                    for (int p = 1; p <= (suma1 + suma2); p++)
                    {
                        listaPesosActualizar = datosMulticapaService.PintarPesoInicialActualizarFinal(p.ToString());
                        listaUmbralActualzar = datosMulticapaService.PintarUmbralActualizarFinal(p.ToString());

                        datosMulticapaService.EliminarArchivoPesoIniciales(p.ToString());
                        datosMulticapaService.EliminarArchivoUmbrales(p.ToString());
                        datosMulticapaService.EliminarArchivoFuncionActivacion(p.ToString());

                        int index = 0;
                        int index2 = 0;
                        int Cont_index = 1;

                        if (p == 1 )
                        {
                            for (int q = 0; q < listaUmbralActualzar.Count; q++)
                            {
                                for (int i = 0; i < listaPesosActualizar.Count; i++)
                                {
                                    for (int t = 0; t < listaX.Count; t++)
                                    {
                                        if (i == index && t == index2 && Cont_index <= listaX.Count)
                                        {
                                            W = listaPesosActualizar[i].W;
                                            U = listaUmbralActualzar[q].U;
                                            X = listaX[t];
                                            //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                            NumCapa = datosMulticapa.Capa(X, W, U);
                                            listaCapa.Add(NumCapa);
                                            index++;
                                            index2++;
                                            Cont_index++;
                                        }
                                    }
                                }
                                Sum = listaCapa.Sum();
                                //MessageBox.Show(Sum.ToString());
                                listaActivacion.Add(Sum);
                                listaCapa.Clear();
                                Cont_index = 1;
                                index2 = 0;
                            }
                        }
                        else
                        {
                            listaNumActivacion = datosMulticapaService.PintarFuncionActivacion((p-1).ToString());

                            for (int q = 0; q < listaUmbralActualzar.Count; q++)
                            {
                                for (int i = 0; i < listaPesosActualizar.Count; i++)
                                {
                                    for (int t = 0; t < listaNumActivacion.Count; t++)
                                    {
                                        if (i == index && t == index2 && Cont_index <= listaNumActivacion.Count)
                                        {
                                            W = listaPesosActualizar[i].W;
                                            U = listaUmbralActualzar[q].U;
                                            X = listaNumActivacion[t].NumFuncionActivacion;
                                            //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                            NumCapa = datosMulticapa.Capa(X, W, U);
                                            //MessageBox.Show(NumCapa.ToString());
                                            listaCapa.Add(NumCapa);
                                            index++;
                                            index2++;
                                            Cont_index++;
                                        }
                                    }
                                }
                                Sum = listaCapa.Sum();
                                //MessageBox.Show(Sum.ToString());
                                listaActivacion.Add(Sum);
                                listaCapa.Clear();
                                Cont_index = 1;
                                index2 = 0;
                            }
                        }
                        

                        if (p <= Convert.ToInt32(TextoNumeroCapasOcultasC.Text) )
                        {
                            for (int t = 0; t < TablaCapasNeurona.RowCount - 1; t++)
                            {
                                int num5 = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[0].Value.ToString());
                                if (num5 == p)
                                {
                                    TextoCapaOculta.Text = TablaCapasNeurona.Rows[t].Cells[0].Value.ToString();
                                    Nombrefunciaon = TablaCapasNeurona.Rows[t].Cells[2].Value.ToString();
                                    CapaOculta = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[1].Value.ToString());
                                }
                            }
                        }
                        else
                        {
                            for (int t = 0; t < TablaCapaSalida.RowCount - 1; t++)
                            {
                                int num5 = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                                if (p == (suma1 + num5))
                                {
                                    CapaOculta = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                                    Nombrefunciaon = TablaCapaSalida.Rows[t].Cells[1].Value.ToString();
                                }
                            }
                        }

                        //MessageBox.Show(Nombrefunciaon);

                        foreach (var item in listaActivacion)
                        {
                            if (Nombrefunciaon == "IDENTIDAD")
                            {
                                FunActivacion = datosMulticapa.Identidad(item);
                            }
                            else if (Nombrefunciaon == "ESCALON")
                            {
                                FunActivacion = datosMulticapa.Escalon(item);
                            }
                            else if (Nombrefunciaon == "LINEA A TRAMOS")
                            {
                                FunActivacion = datosMulticapa.Lineal_Tramos(item);
                            }
                            else if (Nombrefunciaon == "SIGMOIDEA")
                            {
                                FunActivacion = datosMulticapa.Sigmoidea(Convert.ToDouble(item));
                            }
                            else if (Nombrefunciaon == "GAUSSIANA")
                            {
                                FunActivacion = datosMulticapa.Gaussiana(Convert.ToDouble(item));
                            }
                            else if (Nombrefunciaon == "SINUSOIDAL")
                            {
                                FunActivacion = datosMulticapa.Sinusoidal(Convert.ToDouble(item));
                            }
                            //MessageBox.Show("FUNCION ACTIV = " + FunActivacion.ToString());
                            listaActivacion2.Add(FunActivacion);
                        }

                        foreach (var item in listaActivacion2)
                        {
                            datosMulticapaService.GuardarFuncionActivacion(item.ToString() ,p.ToString());
                        }
                        
                        listaActivacion2.Clear();
                        listaActivacion.Clear();

                        if (p == (suma1 + suma2))
                        {
                            EL = datosMulticapa.CalcularEL(YD, FunActivacion);
                            EP = datosMulticapa.CalcularEP(EL, Convert.ToInt32(TextoSalidaC.Text));
                            lista_EP.Add(EP); 

                            for (int t = 1; t <= (suma1 + suma2); t++)
                            {
                                listaPesosActualizar.Clear();
                                listaUmbralActualzar.Clear();
                                listaPesos.Clear();
                                listaUmbrales.Clear();

                                index = 0;
                                index2 = 0;
                                Cont_index = 1;

                                listaPesosActualizar = datosMulticapaService.PintarPesoInicialActualizarFinal(t.ToString());
                                listaUmbralActualzar = datosMulticapaService.PintarUmbralActualizarFinal(t.ToString());

                                if (t == 1)
                                {
                                    for (int q = 0; q < listaPesosActualizar.Count; q++)
                                    {
                                        for (int w = 0; w < listaX.Count; w++)
                                        {
                                            if (q == index && w == index2 && Cont_index <= listaX.Count)
                                            {
                                                rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                W = listaPesosActualizar[q].W;
                                                X = listaX[w];
                                                W_Actualizado = datosMulticapa.W_Actualizar(W,rata,EP,X);
                                                listaPesos.Add(W_Actualizado);
                                                //MessageBox.Show(W_Actualizado.ToString());
                                                //MessageBox.Show("["+ W.ToString() +"]-["+ rata.ToString() + "]-["+ EP.ToString() + "]-["+ X.ToString()+ "] "+ (w+1).ToString());
                                                index++;
                                                index2++;
                                                Cont_index++;
                                            }
                                        }
                                        if ((Cont_index - 1) == listaX.Count)
                                        {
                                            index2 = 0;
                                            Cont_index = 1;
                                        }
                                    }

                                    for (int q = 0; q < listaUmbralActualzar.Count; q++)
                                    {
                                        rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                        U = listaUmbralActualzar[q].U;
                                        U_Actualizado = datosMulticapa.U_Actualizar(U,rata,EP);
                                        //MessageBox.Show(U_Actualizado.ToString());
                                        listaUmbrales.Add(U_Actualizado);
                                    }

                                    datosMulticapaService.EliminarArchivoPesoInicialesActualizados(t.ToString());
                                    datosMulticapaService.EliminarArchivoUmbralesActualizados(t.ToString());

                                    foreach (var item in listaPesos)
                                    {
                                        resp = datosMulticapaService.GuardarPesosActualizar(item.ToString(),t.ToString());
                                    }
                                    foreach (var item in listaUmbrales)
                                    {
                                        resp = datosMulticapaService.GuardarUmbralesActualizar(item.ToString(),t.ToString());
                                    }
                                }
                                else
                                {
                                    listaNumActivacion = datosMulticapaService.PintarFuncionActivacion((t-1).ToString());

                                    for (int q = 0; q < listaPesosActualizar.Count; q++)
                                    {
                                        for (int w = 0; w < listaNumActivacion.Count; w++)
                                        {
                                            if (q == index && w == index2 && Cont_index <= listaNumActivacion.Count)
                                            {
                                                rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                W = listaPesosActualizar[q].W;
                                                X = listaNumActivacion[w].NumFuncionActivacion;
                                                W_Actualizado = datosMulticapa.W_Actualizar(W, rata, EP, X);
                                                listaPesos.Add(W_Actualizado);
                                                //MessageBox.Show(W_Actualizado.ToString());
                                                //MessageBox.Show("["+ W.ToString() +"]-["+ rata.ToString() + "]-["+ EP.ToString() + "]-["+ X.ToString()+ "] "+ (w+1).ToString());
                                                index++;
                                                index2++;
                                                Cont_index++;
                                            }
                                        }
                                        if ((Cont_index - 1) == listaNumActivacion.Count)
                                        {
                                            index2 = 0;
                                            Cont_index = 1;
                                        }
                                    }

                                    for (int q = 0; q < listaUmbralActualzar.Count; q++)
                                    {
                                        rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                        U = listaUmbralActualzar[q].U;
                                        U_Actualizado = datosMulticapa.U_Actualizar(U, rata, EP);
                                        //MessageBox.Show(U_Actualizado.ToString());
                                        listaUmbrales.Add(U_Actualizado);
                                    }

                                    datosMulticapaService.EliminarArchivoPesoInicialesActualizados(t.ToString());
                                    datosMulticapaService.EliminarArchivoUmbralesActualizados(t.ToString());

                                    foreach (var item in listaPesos)
                                    {
                                        resp = datosMulticapaService.GuardarPesosActualizar(item.ToString(), t.ToString());
                                    }
                                    foreach (var item in listaUmbrales)
                                    {
                                        resp = datosMulticapaService.GuardarUmbralesActualizar(item.ToString(), t.ToString());
                                    }
                                }
                                //-------------
                            }
                        }
                    }
                    m++;
                }

            } while (patron_Siguiente == false);
        }

        // rectificar umbrales ------------

        private void MapearDatos()
        {
            for (int p = 0; p < TablaCapasNeurona.RowCount - 1; p++)
            {
                int num5 = Convert.ToInt32(TablaCapasNeurona.Rows[p].Cells[0].Value.ToString());
                if (num5 == num4)
                {
                    TextoCapaOculta.Text = TablaCapasNeurona.Rows[p].Cells[0].Value.ToString();
                    Nombrefunciaon = TablaCapasNeurona.Rows[p].Cells[2].Value.ToString();
                    CapaOculta = Convert.ToInt32(TablaCapasNeurona.Rows[p].Cells[1].Value.ToString());
                }
            }

            //listaPesos.Clear();
            for (int p = 0; p < TablaDatosPesosIniciales.Columns.Count; p++)
            {
                for (int q = 0; q < TablaDatosPesosIniciales.RowCount; q++)
                {
                    if (p == bW)
                    {
                        W = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[q].Cells[p].Value.ToString());
                        //MessageBox.Show("["+(q+1)+"]["+p+"] "+W.ToString());
                        i++;
                        listaW.Add(W);
                        listaPesos.Add(W);
                    }  
                }
            }

            //listaUmbrales.Clear();
            for (int p = 0; p < TablaDatosUmbrales.Columns.Count; p++)
            {
                for (int q = 0; q < TablaDatosUmbrales.RowCount; q++)
                {
                    if (p == cU)
                    {
                        U = Convert.ToDecimal(TablaDatosUmbrales.Rows[q].Cells[p].Value.ToString());
                        //MessageBox.Show("[" + (q + 1) + "][" + p + "] " + U.ToString());
                        j++;
                        listaU.Add(U);
                        listaUmbrales.Add(U);
                    }
                }
            }

            //MessageBox.Show((TablaDatosEntradaSalida.Columns.Count - l.Sal).ToString() +"//"+(TablaDatosEntradaSalida.RowCount).ToString());

            for (int p = 0; p < (TablaDatosEntradaSalida.Columns.Count - l.Sal); p++)
            {
                for (int q = 0; q < TablaDatosEntradaSalida.RowCount; q++)
                {
                    if (q == m && q == aX)
                    {
                        X = Convert.ToDecimal(TablaDatosEntradaSalida.Rows[q].Cells[p].Value.ToString());
                        //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                        k++;
                        listaX.Add(X);
                    }
                }
            }
            for (int p = 0; p < (TablaDatosEntradaSalida.Columns.Count); p++)
            {
                for (int q = 0; q < TablaDatosEntradaSalida.RowCount; q++)
                {
                    if (p == (TablaDatosEntradaSalida.Columns.Count-1) && q == m && q == aX)
                    {
                        YD = Convert.ToInt32(TablaDatosEntradaSalida.Rows[q].Cells[p].Value.ToString());
                        k++;
                    }
                }
            }

            if (cU == TablaDatosUmbrales.Columns.Count)
            {
                cU = 0;
            }

            if (bW == TablaDatosPesosIniciales.Columns.Count)
            {
                bW = 0;
            }

            if (aX == TablaDatosEntradaSalida.Columns.Count)
            {
                aX = 0;
                m = 0;
            }
        }
    }
}
