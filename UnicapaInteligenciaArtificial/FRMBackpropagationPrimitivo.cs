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
    public partial class FRMBackpropagationPrimitivo : Form
    {
        public FRMBackpropagationPrimitivo()
        {
            InitializeComponent();
            Ocultar();
        }

        Leer l = new Leer();
        public string ARCHIVO = "";

        DatosBackpropagationPrimitivo datosBackpropagationPrimitivo = new DatosBackpropagationPrimitivo();
        DatosBackpropagationPrimitivoService datosBackpropagationPrimitivoService = new DatosBackpropagationPrimitivoService();

        IList<DatosBackpropagationPrimitivo> listaNumeroCapaFuncion = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> listas_W = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> listas_U = new List<DatosBackpropagationPrimitivo>();

        IList<decimal> Lista_W = new List<decimal>();
        IList<decimal> Lista_W_Temporal = new List<decimal>();
        IList<decimal> Lista_U = new List<decimal>();
        IList<decimal> Lista_X = new List<decimal>();
        IList<decimal> Lista_Capa = new List<decimal>();
        IList<decimal> FuncionActivacion = new List<decimal>();
        IList<decimal> DerivadaFuncionActivacion = new List<decimal>();
        IList<decimal> FuncionActivacion2 = new List<decimal>();
        IList<decimal> DerivadaFuncionActivacion2 = new List<decimal>();
        IList<decimal> lista_EP = new List<decimal>();
        IList<decimal> lista_ENi = new List<decimal>();
        IList<decimal> lista_ENl = new List<decimal>();
        IList<decimal> lista_ERMS = new List<decimal>();
        IList<decimal> lista_Pesos = new List<decimal>();
        IList<decimal> lista_Umbrales = new List<decimal>();

        IList<DatosBackpropagationPrimitivo> Lista_UmbralActualizar = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> Lista_PesosinicialesActualizar = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> Lista_FuncionActivacion = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> Lista_DerivadaFuncionActivacion = new List<DatosBackpropagationPrimitivo>();
        IList<DatosBackpropagationPrimitivo> Lista_Simulacion = new List<DatosBackpropagationPrimitivo>();


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FRMDatosUnicapa_MouseDown(object sender, MouseEventArgs e)
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BotonSali_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            FRMInicial inicial = new FRMInicial();
            inicial.Show();
            this.Hide();
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
            Num2 = 0;
            Num = 0;

            FRMBackpropagationPrimitivo fRMBackpropagationPrimitivo = new FRMBackpropagationPrimitivo();
            fRMBackpropagationPrimitivo.Refresh();

            TablaCapaSalida.Rows.Clear();
            TablaCapasNeurona.Rows.Clear();
            TablaDatosEntradaSalida.Rows.Clear();
            TablaDatosPesosIniciales.Rows.Clear();
            TablaDatosUmbrales.Rows.Clear();
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
                    l.lecturaArchivo(TablaDatosEntradaSalida, ';', ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void BotonPeso_Iniciales_Click(object sender, EventArgs e)
        {
            MapearPeso();
        }
        private void MapearPeso()
        {
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
        int Num2 = 0;

        private void BotonDatosUmbrales_Click(object sender, EventArgs e)
        {
            MapearUmbral();
        }
        int Num = 0;
        private void MapearUmbral()
        {
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

        private void BotonNumeroNeuronas_Click(object sender, EventArgs e)
        {
            int Capas = Convert.ToInt32(TextoNumeroCapasOcultasC.Text);

            if (Capas >= Num)
            {
                listaNumeroCapaFuncion.Clear();

                datosBackpropagationPrimitivo.NumeroCapas = (Num + 1).ToString();
                datosBackpropagationPrimitivo.NumeroNeuronasXCapas = TextoNumeroNeuronasXCapaC.Text;
                datosBackpropagationPrimitivo.FuncionActivacion = ComboFuncionActivacion.Text;

                listaNumeroCapaFuncion.Add(datosBackpropagationPrimitivo);

                foreach (var item in listaNumeroCapaFuncion)
                {
                    TablaCapasNeurona.Rows.Add(item.NumeroCapas, item.NumeroNeuronasXCapas, item.FuncionActivacion);
                }

                TextoNumeroNeuronasXCapaC.Text = "";
                ComboFuncionActivacion.SelectedIndex = 0;
                Num++;
            }

            if (Capas == Num)
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

            if (Capas >= Num2)
            {
                listaNumeroCapaFuncion.Clear();

                datosBackpropagationPrimitivo.NumeroCapas = (Num2 + 1).ToString();
                datosBackpropagationPrimitivo.FuncionActivacion = ComboFuncionActivacionSalida.Text;

                listaNumeroCapaFuncion.Add(datosBackpropagationPrimitivo);

                foreach (var item in listaNumeroCapaFuncion)
                {
                    TablaCapaSalida.Rows.Add(item.NumeroCapas, item.FuncionActivacion);
                }
                ComboFuncionActivacionSalida.SelectedIndex = 0;
                Num2++;
            }

            if (Capas == Num2)
            {
                MessageBox.Show("Funcion de activacion de las capas de salida guardadas correctamente");
                ComboFuncionActivacionSalida.Enabled = false;
                BotonRegistrarFunActivaSalida.Enabled = false;
                ComboFuncionActivacionSalida.SelectedIndex = 0;
                Num2 = 1;
            }

        }

        int CargarPasosUmbrales = 1;
        int patron = 0;
        int m = 0;
        int YD = 0;
        int sum2 = 0;
        int sum1 = 0;
        int CapaOculta = 0;
        int aumentar;
        int iteracion = 0;
        int iteracion2 = 1;
        Boolean EstadoCargarPasosUmbrales = false;
        Boolean patron_Siguiente = false;

        decimal W;
        decimal U;
        decimal X;
        decimal EL;
        decimal EP;
        decimal ENi;
        decimal ENl;
        decimal NumCapa;
        decimal W_Actualizado;
        decimal U_Actualizado;
        decimal ERMS;

        decimal rata = 0;
        decimal Sum = 0;
        decimal FunActivacion = 0;
        decimal DerivadaFunActivacion = 0;

        string Res;
        string Nombrefunciaon;

        private void BotonEntrenar_Click(object sender, EventArgs e)
        {

            do
            {
                sum1 = Convert.ToInt32(TextoNumeroCapasOcultasC.Text);
                sum2 = Convert.ToInt32(TextoSalidas.Text);

                Lista_W.Clear();
                Lista_U.Clear();

                for (int i = 0; i < TablaDatosPesosIniciales.Rows.Count; i++)
                {
                    W = Convert.ToDecimal((TablaDatosPesosIniciales.Rows[i].Cells[0].Value).ToString());
                    Lista_W.Add(W);
                }

                for (int i = 0; i < TablaDatosUmbrales.Rows.Count; i++)
                {
                    U = Convert.ToDecimal((TablaDatosUmbrales.Rows[i].Cells[0].Value).ToString());
                    Lista_U.Add(U);
                }

                foreach (var item in Lista_W)
                {
                    Res = datosBackpropagationPrimitivoService.GuardarPesosActualizar(item.ToString(), CargarPasosUmbrales.ToString());
                    Res = datosBackpropagationPrimitivoService.GuardarPesosIniciales(item.ToString(), CargarPasosUmbrales.ToString());
                }

                foreach (var item in Lista_U)
                {
                    Res = datosBackpropagationPrimitivoService.GuardarUmbralActualizar(item.ToString(), CargarPasosUmbrales.ToString());
                    datosBackpropagationPrimitivoService.GuardarUmbral(item.ToString(), CargarPasosUmbrales.ToString());
                }

                if (CargarPasosUmbrales == (sum1 + sum2))
                {
                    EstadoCargarPasosUmbrales = true;
                }

                else
                {
                    MapearPeso();
                    MapearUmbral();
                    EstadoCargarPasosUmbrales = false;
                    CargarPasosUmbrales++;
                }//listas_W = datosBackpropagationCascadaService.PintarPesoInicialActualizar();

            } while (EstadoCargarPasosUmbrales == false);

            do
            {
                //MessageBox.Show((patron).ToString() + " PATRON REALIZADO -_-");

                Lista_U.Clear();
                Lista_W.Clear();
                Lista_X.Clear();

                if (patron == Convert.ToInt32(TextoPatrones.Text))
                {
                    ERMS = datosBackpropagationPrimitivo.Calcular_ERMS(lista_EP, Convert.ToInt32(TextoPatronesC.Text));

                    Grafico.Series["ChartLinea"].Points.AddXY(iteracion, ERMS);

                    MessageBox.Show("ERMS [" + ERMS.ToString() + "]");

                    //System.Threading.Thread.Sleep(5000);

                    lista_ERMS.Add(ERMS);

                    TablaERMS.Rows.Clear();

                    foreach (var item in lista_ERMS)
                    {
                        TablaERMS.Rows.Add(Math.Round(item, 5).ToString());
                    }

                    if (iteracion == Convert.ToInt32(TextoNumeroMaxIteraciones.Text) || ERMS <= Convert.ToDecimal(TextoErrorPermitido.Text))
                    {
                        patron_Siguiente = true;
                        if (ERMS <= Convert.ToDecimal(TextoErrorPermitido.Text))
                        {
                            MessageBox.Show(" ENTRENAMIENTO EXITOSO FINALIZADO ....");
                        }
                        else
                        {
                            MessageBox.Show(" ENTRENAMIENTO FINALIZADO LA NEURONA NO APRENDIO!! ....");
                        }
                    }
                    else
                    {
                        patron = 0;
                        lista_ENi.Clear();
                        lista_ENl.Clear();
                        Res = datosBackpropagationPrimitivoService.EliminarENi();
                        Res = datosBackpropagationPrimitivoService.EliminarENl();
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
                                Lista_X.Add(X);
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

                    Lista_PesosinicialesActualizar.Clear();
                    Lista_UmbralActualizar.Clear();
                    Lista_Capa.Clear();
                    Lista_FuncionActivacion.Clear();
                    Lista_DerivadaFuncionActivacion.Clear();
                    FuncionActivacion.Clear();
                    FuncionActivacion2.Clear();
                    DerivadaFuncionActivacion.Clear();

                    lista_ENi.Clear();
                    lista_ENl.Clear();
                    Res = datosBackpropagationPrimitivoService.EliminarENi();
                    Res = datosBackpropagationPrimitivoService.EliminarENl();

                    for (int p = 1; p <= (sum1 + sum2); p++)
                    {
                        Lista_PesosinicialesActualizar = datosBackpropagationPrimitivoService.PintarPesoInicialActualizar(p.ToString());
                        Lista_UmbralActualizar = datosBackpropagationPrimitivoService.PintarUmbralActualizar(p.ToString());

                        Res = datosBackpropagationPrimitivoService.EliminarArchivoPesoInicialesActualizar(p.ToString());
                        Res = datosBackpropagationPrimitivoService.EliminarArchivoUmbralActualizar(p.ToString());
                        Res = datosBackpropagationPrimitivoService.EliminarArchivoFuncionActivacion(p.ToString());
                        Res = datosBackpropagationPrimitivoService.EliminarArchivoDerivadaFuncionActivacion(p.ToString());

                        int index = 0;
                        int index2 = 0;
                        int index3 = 0;
                        int Cont_index = 1;
                        decimal eni = 0;
                        decimal enl = 0;
                        decimal Funcion_ACT = 0;
                        decimal DEV_Funcion_ACT = 0;

                        if (p == 1)
                        {
                            for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                            {
                                for (int i = 0; i < Lista_PesosinicialesActualizar.Count; i++)
                                {
                                    for (int t = 0; t < Lista_X.Count; t++)
                                    {
                                        if (i == index && t == index2 && Cont_index <= Lista_X.Count)
                                        {
                                            W = Lista_PesosinicialesActualizar[i].W;
                                            U = Lista_UmbralActualizar[q].U;
                                            X = Lista_X[t];
                                            //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                            NumCapa = datosBackpropagationPrimitivo.Capa(X, W, U);
                                            //MessageBox.Show("[" + NumCapa.ToString() + "]");
                                            Lista_Capa.Add(NumCapa);
                                            index++;
                                            index2++;
                                            Cont_index++;
                                        }
                                    }
                                }
                                Sum = Lista_Capa.Sum();
                                //MessageBox.Show(Sum.ToString());
                                FuncionActivacion.Add(Sum);
                                Lista_Capa.Clear();
                                Cont_index = 1;
                                index2 = 0;
                            }
                        }
                        else
                        {
                            Lista_FuncionActivacion = datosBackpropagationPrimitivoService.PintarFuncionActivacion((p - 1).ToString());

                            for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                            {
                                for (int i = 0; i < Lista_PesosinicialesActualizar.Count; i++)
                                {
                                    for (int t = 0; t < Lista_FuncionActivacion.Count; t++)
                                    {
                                        if (i == index && t == index2 && Cont_index <= Lista_FuncionActivacion.Count)
                                        {
                                            W = Lista_PesosinicialesActualizar[i].W;
                                            U = Lista_UmbralActualizar[q].U;
                                            X = Lista_FuncionActivacion[t].NumFuncionActivacion;
                                            //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                            NumCapa = datosBackpropagationPrimitivo.Capa(X, W, U);
                                            //MessageBox.Show(NumCapa.ToString());
                                            Lista_Capa.Add(NumCapa);
                                            index++;
                                            index2++;
                                            Cont_index++;
                                        }
                                    }
                                }
                                Sum = Lista_Capa.Sum();
                                //MessageBox.Show(Sum.ToString());
                                FuncionActivacion.Add(Sum);
                                Lista_Capa.Clear();
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
                                    if ((sum1 - 1) == p)
                                    {
                                        aumentar = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[1].Value.ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int t = 0; t < TablaCapaSalida.RowCount - 1; t++)
                            {
                                int num5 = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                                if (p == (sum1 + num5))
                                {
                                    CapaOculta = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                                    Nombrefunciaon = TablaCapaSalida.Rows[t].Cells[1].Value.ToString();
                                }
                            }
                        }

                        //MessageBox.Show(Nombrefunciaon);
                        foreach (var item in FuncionActivacion)
                        {
                            if (Nombrefunciaon == "IDENTIDAD")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Identidad(item);
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Identidad(item);
                            }
                            else if (Nombrefunciaon == "ESCALON")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Escalon(item);
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Escalon(item);
                            }
                            else if (Nombrefunciaon == "LINEA A TRAMOS")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Lineal_Tramos(item);
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Lineal_Tramos(item);
                            }
                            else if (Nombrefunciaon == "SIGMOIDEA")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Sigmoidea(Convert.ToDouble(item));
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Sigmoidea(Convert.ToDouble(item));
                            }
                            else if (Nombrefunciaon == "GAUSSIANA")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Gaussiana(Convert.ToDouble(item));
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Gaussiana(Convert.ToDouble(item));
                            }
                            else if (Nombrefunciaon == "SINUSOIDAL")
                            {
                                FunActivacion = datosBackpropagationPrimitivo.Sinusoidal(Convert.ToDouble(item));
                                DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Sinusoidal(Convert.ToDouble(item));
                            }
                            //MessageBox.Show("FA - [" + FunActivacion.ToString()+ "] DFA - ["+ DerivadaFunActivacion .ToString()+ "] TT - ["+item.ToString()+"]");
                            FuncionActivacion2.Add(FunActivacion);
                            DerivadaFuncionActivacion2.Add(DerivadaFunActivacion);
                        }

                        //MessageBox.Show("-_____^____-");
                        foreach (var item in FuncionActivacion2)
                        {
                            //MessageBox.Show(item.ToString());
                            Res = datosBackpropagationPrimitivoService.GuardarFuncionActivacion(item.ToString(), p.ToString());
                        }

                        foreach (var item in DerivadaFuncionActivacion2)
                        {
                            //MessageBox.Show(item.ToString());
                            Res = datosBackpropagationPrimitivoService.GuardarDerivadaFuncionActivacion(item.ToString(), p.ToString());
                        }

                        FuncionActivacion.Clear();
                        FuncionActivacion2.Clear();
                        DerivadaFuncionActivacion2.Clear();

                        if (p == (sum1 + sum2))
                        {
                            EL = datosBackpropagationPrimitivo.CalcularEL(YD, FunActivacion);
                            EP = datosBackpropagationPrimitivo.CalcularEP(EL, Convert.ToInt32(TextoSalidaC.Text));
                            lista_EP.Add(EP);

                            //MessageBox.Show("EL --> " + EL.ToString());

                            //no se llena 
                            listas_W.Clear();
                            listas_W = datosBackpropagationPrimitivoService.ConsultarPesosInicial((sum1 + sum2).ToString());

                            foreach (var item in listas_W)
                            {
                                ENl = datosBackpropagationPrimitivo.Error_EN_l(EL, item.W);
                                //MessageBox.Show(" EN(l) --> [" + ENl.ToString() + "]");
                                lista_ENl.Add(ENl);
                            }

                            listas_W.Clear();

                            foreach (var item in lista_ENl)
                            {
                                Res = datosBackpropagationPrimitivoService.GuardarENl(item.ToString());
                            }

                            int contador = 0;
                            int posicion2 = 0;
                            int posicion = 0;
                            int k = 0;
                            decimal Num3;
                            decimal sumador = 0;
                            Boolean seguir = false;

                            listas_W = datosBackpropagationPrimitivoService.ConsultarPesosInicial(sum1.ToString());
                            Lista_W_Temporal.Clear();

                            //MessageBox.Show("Aumentar = [" + aumentar.ToString() + "]");

                            do
                            {
                                for (int j = k; j < listas_W.Count; j++)
                                {
                                    if (j == posicion)
                                    {
                                        posicion = posicion + aumentar;
                                        Num3 = listas_W[j].W;
                                        Lista_W_Temporal.Add(Num3);
                                        contador++;
                                    }
                                }

                                if (contador == lista_ENl.Count)
                                {
                                    contador = 0;
                                    //k == 20
                                    if (k == (aumentar - 1))
                                    {
                                        seguir = true;
                                    }

                                    for (int i = 0; i < Lista_W_Temporal.Count; i++)
                                    {
                                        for (int t = 0; t < lista_ENl.Count; t++)
                                        {
                                            if (t == i)
                                            {
                                                sumador = (Lista_W_Temporal[i] * lista_ENl[t]) + sumador;
                                            }
                                        }
                                    }

                                    //MessageBox.Show(" EN(ii) = [" + sumador + "] pos2 ["+posicion2.ToString()+"]");
                                    lista_ENi.Add(sumador);
                                    Lista_W_Temporal.Clear();
                                    posicion = 0;
                                    posicion2++;
                                    posicion = posicion2;
                                    sumador = 0;
                                    k++;
                                }
                            } while (seguir == false);

                            //MessageBox.Show(lista_ENi.Count.ToString() +" ERROR SALIO");

                            foreach (var item in lista_ENi)
                            {
                                Res = datosBackpropagationPrimitivoService.GuardarENi(item.ToString());
                            }

                            for (int t = 1; t <= (sum1 + sum2); t++)
                            {
                                Lista_PesosinicialesActualizar.Clear();
                                Lista_UmbralActualizar.Clear();
                                lista_Pesos.Clear();
                                lista_Umbrales.Clear();
                                listas_W.Clear();
                                Lista_FuncionActivacion.Clear();
                                Lista_DerivadaFuncionActivacion.Clear();

                                index = 0;
                                index2 = 0;
                                index3 = 0;
                                Cont_index = 1;

                                eni = 0;
                                enl = 0;
                                Funcion_ACT = 0;
                                DEV_Funcion_ACT = 0;
                                //ConsultarPesosInicialConsultarPesosInicial
                                Lista_PesosinicialesActualizar = datosBackpropagationPrimitivoService.ConsultarPesosInicial(t.ToString());
                                Lista_UmbralActualizar = datosBackpropagationPrimitivoService.ConsultarUmbral(t.ToString());
                                Lista_DerivadaFuncionActivacion = datosBackpropagationPrimitivoService.PintarDerivadaFuncionActivacion(t.ToString());
                                Lista_FuncionActivacion = datosBackpropagationPrimitivoService.PintarFuncionActivacion(t.ToString());

                                if (t == 1)
                                {
                                    for (int q = 0; q < Lista_PesosinicialesActualizar.Count; q++)
                                    {
                                        for (int y = 0; y < lista_ENi.Count; y++)
                                        {
                                            for (int z = 0; z < Lista_DerivadaFuncionActivacion.Count; z++)
                                            {
                                                for (int w = 0; w < Lista_X.Count; w++)
                                                {
                                                    if (q == index && y == index3 && z == index3 && w == index2 && Cont_index <= Lista_X.Count)
                                                    {
                                                        rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                        W = Lista_PesosinicialesActualizar[q].W;
                                                        X = Lista_X[w];
                                                        eni = lista_ENi[y];
                                                        DEV_Funcion_ACT = Lista_DerivadaFuncionActivacion[z].DerivadaFuncionActivacion;
                                                        W_Actualizado = datosBackpropagationPrimitivo.W_Actualizar(W, rata, eni, DEV_Funcion_ACT, X);
                                                        lista_Pesos.Add(W_Actualizado);
                                                        //MessageBox.Show(W_Actualizado.ToString());
                                                        //MessageBox.Show("["+ W.ToString() +"]-["+ rata.ToString() + "]-["+ eni.ToString() + "]-["+ DEV_Funcion_ACT.ToString()+ "]-[" + X.ToString() + "] " + (w+1).ToString());
                                                        index++;
                                                        index2++;
                                                        Cont_index++;
                                                    }
                                                }
                                                if ((Cont_index - 1) == Lista_X.Count)
                                                {
                                                    index2 = 0;
                                                    index3++;
                                                    Cont_index = 1;
                                                }
                                            }
                                        }
                                    }

                                    for (int y = 0; y < lista_ENi.Count; y++)
                                    {
                                        for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                                        {
                                            if (y == q)
                                            {
                                                rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                U = Lista_UmbralActualizar[q].U;
                                                eni = lista_ENi[y];
                                                U_Actualizado = datosBackpropagationPrimitivo.U_Actualizar(U, rata, eni);
                                                //MessageBox.Show(U_Actualizado.ToString());
                                                lista_Umbrales.Add(U_Actualizado);
                                            }
                                        }
                                    }

                                    Res = datosBackpropagationPrimitivoService.EliminarArchivoPesoInicialesActualizar(t.ToString());
                                    Res = datosBackpropagationPrimitivoService.EliminarArchivoUmbralActualizar(t.ToString());

                                    foreach (var item in lista_Pesos)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarPesosActualizar(item.ToString(), t.ToString());
                                    }

                                    foreach (var item in lista_Umbrales)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarUmbralActualizar(item.ToString(), t.ToString());
                                    }

                                }
                                else if (t == (sum1 + sum2))
                                {
                                    Lista_FuncionActivacion.Clear();
                                    Lista_FuncionActivacion = datosBackpropagationPrimitivoService.PintarFuncionActivacion((t - 1).ToString());

                                    for (int q = 0; q < Lista_PesosinicialesActualizar.Count; q++)
                                    {
                                        for (int w = 0; w < Lista_FuncionActivacion.Count; w++)
                                        {
                                            if (q == index && w == index2 && Cont_index <= Lista_FuncionActivacion.Count)
                                            {
                                                rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                W = Lista_PesosinicialesActualizar[q].W;
                                                Funcion_ACT = Lista_FuncionActivacion[w].NumFuncionActivacion;
                                                W_Actualizado = datosBackpropagationPrimitivo.W3_Actualizar(W, rata, EL, Funcion_ACT);
                                                lista_Pesos.Add(W_Actualizado);
                                                //MessageBox.Show(W_Actualizado.ToString());
                                                //MessageBox.Show("["+ W.ToString() +"]-["+ rata.ToString() + "]-["+ EP.ToString() + "]-["+ X.ToString()+ "] "+ (w+1).ToString());
                                                index++;
                                                index2++;
                                                Cont_index++;
                                            }
                                        }
                                        if ((Cont_index - 1) == Lista_FuncionActivacion.Count)
                                        {
                                            index2 = 0;
                                            Cont_index = 1;
                                        }
                                    }

                                    for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                                    {
                                        rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                        U = Lista_UmbralActualizar[q].U;
                                        U_Actualizado = datosBackpropagationPrimitivo.U2_Actualizar(U, rata, EL);
                                        //MessageBox.Show(U_Actualizado.ToString());
                                        lista_Umbrales.Add(U_Actualizado);
                                    }

                                    datosBackpropagationPrimitivoService.EliminarArchivoPesoInicialesActualizar(t.ToString());
                                    datosBackpropagationPrimitivoService.EliminarArchivoUmbralActualizar(t.ToString());

                                    foreach (var item in lista_Pesos)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarPesosActualizar(item.ToString(), t.ToString());
                                    }
                                    foreach (var item in lista_Umbrales)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarUmbralActualizar(item.ToString(), t.ToString());
                                    }
                                }
                                else
                                {
                                    for (int q = 0; q < Lista_PesosinicialesActualizar.Count; q++)
                                    {
                                        for (int y = 0; y < lista_ENl.Count; y++)
                                        {
                                            for (int w = 0; w < Lista_DerivadaFuncionActivacion.Count; w++)
                                            {
                                                if (q == index && w == index2 && y == index2 && Cont_index <= Lista_DerivadaFuncionActivacion.Count)
                                                {
                                                    rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                    W = Lista_PesosinicialesActualizar[q].W;
                                                    DEV_Funcion_ACT = Lista_DerivadaFuncionActivacion[w].DerivadaFuncionActivacion;
                                                    enl = lista_ENl[y];
                                                    W_Actualizado = datosBackpropagationPrimitivo.W2_Actualizar(W, rata, enl, DEV_Funcion_ACT);
                                                    lista_Pesos.Add(W_Actualizado);
                                                    //MessageBox.Show(W_Actualizado.ToString());
                                                    //MessageBox.Show("["+ W.ToString() +"]-["+ rata.ToString() + "]-["+ EP.ToString() + "]-["+ X.ToString()+ "] "+ (w+1).ToString());
                                                    index++;
                                                    index2++;
                                                    Cont_index++;
                                                }
                                            }
                                            if ((Cont_index - 1) == Lista_DerivadaFuncionActivacion.Count)
                                            {
                                                index2 = 0;
                                                Cont_index = 1;
                                            }
                                        }
                                    }

                                    for (int y = 0; y < lista_ENl.Count; y++)
                                    {
                                        for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                                        {
                                            if (y == q)
                                            {
                                                rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                                                U = Lista_UmbralActualizar[q].U;
                                                enl = lista_ENl[y];
                                                U_Actualizado = datosBackpropagationPrimitivo.U_Actualizar(U, rata, enl);
                                                //MessageBox.Show(U_Actualizado.ToString());
                                                lista_Umbrales.Add(U_Actualizado);
                                            }
                                        }
                                    }

                                    datosBackpropagationPrimitivoService.EliminarArchivoPesoInicialesActualizar(t.ToString());
                                    datosBackpropagationPrimitivoService.EliminarArchivoUmbralActualizar(t.ToString());

                                    foreach (var item in lista_Pesos)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarPesosActualizar(item.ToString(), t.ToString());
                                    }
                                    foreach (var item in lista_Umbrales)
                                    {
                                        Res = datosBackpropagationPrimitivoService.GuardarUmbralActualizar(item.ToString(), t.ToString());
                                    }
                                }
                            }
                        }
                    }
                    m++;
                }

            } while (patron_Siguiente == false);
        }

        private void BotonDatosEntradaSalidaSimulacion_Click(object sender, EventArgs e)
        {
            cargarArchivoSimulacion();
        }
        public void cargarArchivoSimulacion()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " TXT | *.txt;";
                openFileDialog.Title = " IMPORTAR DATOS SIMULACION ";

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

        private void BotonSimulacion_Click(object sender, EventArgs e)
        {
            patron++;
                patron_Siguiente = false;

                for (int p = 0; p < (Convert.ToInt32(TextoEntradas.Text)); p++)
                {
                    for (int q = 0; q < TablaSimulacion.RowCount; q++)
                    {
                        if (q == m)
                        {
                            X = Convert.ToDecimal(TablaSimulacion.Rows[q].Cells[p].Value.ToString());
                            //MessageBox.Show("[" + (q + 1) + "][" + (p+1) + "] " + X.ToString());
                            Lista_X.Add(X);
                        }
                    }
                }

                for (int p = 1; p <= (sum1 + sum2); p++)
                {
                    Lista_PesosinicialesActualizar = datosBackpropagationPrimitivoService.PintarPesoInicialActualizar(p.ToString());
                    Lista_UmbralActualizar = datosBackpropagationPrimitivoService.PintarUmbralActualizar(p.ToString());

                    int index = 0;
                    int index2 = 0;
                    int index3 = 0;
                    int Cont_index = 1;
                    decimal eni = 0;
                    decimal enl = 0;
                    decimal Funcion_ACT = 0;
                    decimal DEV_Funcion_ACT = 0;

                    if (p == 1)
                    {
                        for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                        {
                            for (int i = 0; i < Lista_PesosinicialesActualizar.Count; i++)
                            {
                                for (int t = 0; t < Lista_X.Count; t++)
                                {
                                    if (i == index && t == index2 && Cont_index <= Lista_X.Count)
                                    {
                                        W = Lista_PesosinicialesActualizar[i].W;
                                        U = Lista_UmbralActualizar[q].U;
                                        X = Lista_X[t];
                                        //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                        NumCapa = datosBackpropagationPrimitivo.Capa(X, W, U);
                                        //MessageBox.Show("[" + NumCapa.ToString() + "]");
                                        Lista_Capa.Add(NumCapa);
                                        index++;
                                        index2++;
                                        Cont_index++;
                                    }
                                }
                            }
                            Sum = Lista_Capa.Sum();
                            //MessageBox.Show(Sum.ToString());
                            FuncionActivacion.Add(Sum);
                            Lista_Capa.Clear();
                            Cont_index = 1;
                            index2 = 0;
                        }
                    }
                    else
                    {
                        Lista_FuncionActivacion = datosBackpropagationPrimitivoService.PintarFuncionActivacion((p - 1).ToString());

                        for (int q = 0; q < Lista_UmbralActualizar.Count; q++)
                        {
                            for (int i = 0; i < Lista_PesosinicialesActualizar.Count; i++)
                            {
                                for (int t = 0; t < Lista_FuncionActivacion.Count; t++)
                                {
                                    if (i == index && t == index2 && Cont_index <= Lista_FuncionActivacion.Count)
                                    {
                                        W = Lista_PesosinicialesActualizar[i].W;
                                        U = Lista_UmbralActualizar[q].U;
                                        X = Lista_FuncionActivacion[t].NumFuncionActivacion;
                                        //MessageBox.Show("["+ W.ToString() +"]-["+ U.ToString() + "]-["+ X.ToString() + "]"+ (t + 1).ToString());
                                        NumCapa = datosBackpropagationPrimitivo.Capa(X, W, U);
                                        //MessageBox.Show(NumCapa.ToString());
                                        Lista_Capa.Add(NumCapa);
                                        index++;
                                        index2++;
                                        Cont_index++;
                                    }
                                }
                            }
                            Sum = Lista_Capa.Sum();
                            //MessageBox.Show(Sum.ToString());
                            FuncionActivacion.Add(Sum);
                            Lista_Capa.Clear();
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
                                if ((sum1 - 1) == p)
                                {
                                    aumentar = Convert.ToInt32(TablaCapasNeurona.Rows[t].Cells[1].Value.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int t = 0; t < TablaCapaSalida.RowCount - 1; t++)
                        {
                            int num5 = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                            if (p == (sum1 + num5))
                            {
                                CapaOculta = Convert.ToInt32(TablaCapaSalida.Rows[t].Cells[0].Value.ToString());
                                Nombrefunciaon = TablaCapaSalida.Rows[t].Cells[1].Value.ToString();
                            }
                        }
                    }

                    //MessageBox.Show(Nombrefunciaon);
                    foreach (var item in FuncionActivacion)
                    {
                        if (Nombrefunciaon == "IDENTIDAD")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Identidad(item);
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Identidad(item);
                        }
                        else if (Nombrefunciaon == "ESCALON")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Escalon(item);
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Escalon(item);
                        }
                        else if (Nombrefunciaon == "LINEA A TRAMOS")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Lineal_Tramos(item);
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Lineal_Tramos(item);
                        }
                        else if (Nombrefunciaon == "SIGMOIDEA")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Sigmoidea(Convert.ToDouble(item));
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Sigmoidea(Convert.ToDouble(item));
                        }
                        else if (Nombrefunciaon == "GAUSSIANA")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Gaussiana(Convert.ToDouble(item));
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Gaussiana(Convert.ToDouble(item));
                        }
                        else if (Nombrefunciaon == "SINUSOIDAL")
                        {
                            FunActivacion = datosBackpropagationPrimitivo.Sinusoidal(Convert.ToDouble(item));
                            DerivadaFunActivacion = datosBackpropagationPrimitivo.Derivada_Sinusoidal(Convert.ToDouble(item));
                        }
                        //MessageBox.Show("FA - [" + FunActivacion.ToString()+ "] DFA - ["+ DerivadaFunActivacion .ToString()+ "] TT - ["+item.ToString()+"]");
                        FuncionActivacion2.Add(FunActivacion);
                        DerivadaFuncionActivacion2.Add(DerivadaFunActivacion);
                    }

                    //MessageBox.Show("-_____^____-");
                    foreach (var item in FuncionActivacion2)
                    {
                        //MessageBox.Show(item.ToString());
                        Res = datosBackpropagationPrimitivoService.GuardarFuncionActivacionSimulacion(item.ToString(), p.ToString());
                    }

                    foreach (var item in DerivadaFuncionActivacion2)
                    {
                        //MessageBox.Show(item.ToString());
                        Res = datosBackpropagationPrimitivoService.GuardarDerivadaFuncionActivacion(item.ToString(), p.ToString());
                    }

                    FuncionActivacion.Clear();
                    FuncionActivacion2.Clear();
                    DerivadaFuncionActivacion2.Clear();

                    if (p == (sum1 + sum2))
                    {
                    for (int i = 0; i < (sum1 + sum2); i++)
                    {
                        Lista_Simulacion = datosBackpropagationPrimitivoService.PintarFuncionActivacionSimulacion((i + 1).ToString());

                        for (int j = 0; j < Lista_Simulacion.Count; j++)
                        {
                            Grafica2.Series["ChartLinea"].Points.AddXY(iteracion2, Lista_Simulacion[j].NumFuncionActivacion);
                            iteracion2++;
                        }

                        MessageBox.Show("CAPA");
                        Lista_Simulacion.Clear();
                        Grafica2.ResetAutoValues();
                    }
                }
                }
                m++;
        }
    }
}
