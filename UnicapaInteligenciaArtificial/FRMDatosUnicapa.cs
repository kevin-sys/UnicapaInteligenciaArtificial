using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UnicapaInteligenciaArtificial
{
    public partial class FRMDatosUnicapa : Form
    {
        DatosUnicapa datosUnicapa = new DatosUnicapa();
        DatosUnicapaService datosUnicapaService = new DatosUnicapaService();
        IList<DatosUnicapa> listaEntradaSalida = new List<DatosUnicapa>();
        IList<DatosUnicapa> listaPesosIniciales = new List<DatosUnicapa>();
        IList<DatosUnicapa> listaUmbrales = new List<DatosUnicapa>();
        IList<Decimal> listaEp = new List<Decimal>();
        IList<Decimal> listaERMS = new List<Decimal>();

        public FRMDatosUnicapa()
        {
            InitializeComponent();
            Bloquear();
        }

        int limite = 0;
        string respuesta;
        Boolean estado = false;
        int AuxIteraciones = 0;

        public void Bloquear()
        {
            TextoPatrones.Enabled = false;
            TextoEntradas.Enabled = false;
            TextoSalidas.Enabled = false;
            TextoS1.Enabled = false;
            TextoYR1.Enabled = false;
            TextoEl1.Enabled = false;
            TextoEP.Enabled = false;
            TextoW11.Enabled = false;
            TextoW21.Enabled = false;
            TextoU1.Enabled = false;
            TextoERMS.Enabled = false;
            TextoNumIteraciones.Enabled = false;
            TextoRestante.Enabled = false;

            BotonSiguientePatron.Enabled = false;
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
        private void BotonSali_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void BotonDatosE_S_Click(object sender, EventArgs e)
        {
            TablaDatosEntradaSalida.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IList<DatosUnicapa> datosUnicapas = new List<DatosUnicapa>();
            openFileDialog.Filter = " TXT | *.txt;";
            openFileDialog.Title = " IMPORTAR DATOS DE ENTRADA Y SALIDA ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                datosUnicapas = datosUnicapaService.PintarTabla1(openFileDialog.FileName);
                listaEntradaSalida = datosUnicapas;
                foreach (var item in datosUnicapas)
                {
                    TablaDatosEntradaSalida.Rows.Add(item.X1, item.X2, item.YD1);
                }
            }
            TextoPatrones.Text = datosUnicapas.Count().ToString();
            TextoEntradas.Text = (TablaDatosEntradaSalida.Columns.Count - 1).ToString();
            TextoSalidas.Text = (TablaDatosEntradaSalida.Columns.Count- Convert.ToInt32(TextoEntradas.Text)).ToString();
            TextoRestante.Text = datosUnicapas.Count().ToString();
            limite = Convert.ToInt32(TextoRestante.Text);

        }
        private void BotonPeso_Iniciales_Click(object sender, EventArgs e)
        {
            TablaDatosPesosIniciales.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IList<DatosUnicapa> datosUnicapas = new List<DatosUnicapa>();
            openFileDialog.Filter = " TXT | *.txt;";
            openFileDialog.Title = " IMPORTAR DATOS PESOS INICIALES ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                datosUnicapas = datosUnicapaService.PintarTabla2(openFileDialog.FileName);
                listaPesosIniciales = datosUnicapas;
                foreach (var item in datosUnicapas)
                {
                    TablaDatosPesosIniciales.Rows.Add(item.W1, item.W2);
                }
            }
        }
        private void BotonDatosUmbrales_Click(object sender, EventArgs e)
        {
            TablaDatosUmbrales.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IList<DatosUnicapa> datosUnicapas = new List<DatosUnicapa>();
            openFileDialog.Filter = " TXT | *.txt;";
            openFileDialog.Title = " IMPORTAR DATOS DE UMBRALES ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                datosUnicapas = datosUnicapaService.PintarTabla3(openFileDialog.FileName);
                listaUmbrales = datosUnicapas;
                foreach (var item in datosUnicapas)
                {
                    TablaDatosUmbrales.Rows.Add(item.U);
                }
            }
        }
        private void BotonPatron_Click(object sender, EventArgs e)
        {
            BotonSiguientePatron.Enabled = true;
        }
        private void GuardarTXT(string W11, string W21, string U1)
        {
            MessageBox.Show(" SE GUARDAR EN UN TXT LOS PESOS Y UMBRALES ACTULES ");
            MessageBox.Show(datosUnicapaService.GuardarPesos(W11,W21));
            MessageBox.Show(datosUnicapaService.GuardarUmbrales(U1));

            BotonEntrenarSolo.Enabled = false;
            BotonPatron.Enabled = false;
            BotonSiguientePatron.Enabled = false;
        }
        private void BotonUmbraleIdeales_Click(object sender, EventArgs e)
        {
            TablaUmbralIdeal.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IList<DatosUnicapa> datosUnicapas = new List<DatosUnicapa>();
            openFileDialog.Filter = " TXT | *.txt;";
            openFileDialog.Title = " IMPORTAR UMBRAL IDEAL ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                datosUnicapas = datosUnicapaService.PintarTabla3(openFileDialog.FileName);
                listaUmbrales = datosUnicapas;
                foreach (var item in datosUnicapas)
                {
                    TablaUmbralIdeal.Rows.Add(item.U);
                }
            }
        }
        private void BotonPesosIdeales_Click(object sender, EventArgs e)
        {

            TablaPesoIdeal.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IList<DatosUnicapa> datosUnicapas = new List<DatosUnicapa>();
            openFileDialog.Filter = " TXT | *.txt;";
            openFileDialog.Title = " IMPORTAR DATOS PESOS INICIALES ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                datosUnicapas = datosUnicapaService.PintarTabla2(openFileDialog.FileName);
                listaPesosIniciales = datosUnicapas;
                foreach (var item in datosUnicapas)
                {
                    TablaPesoIdeal.Rows.Add(item.W1, item.W2);
                }
            }
        }
        private void BotonEntrenarSolo_Click_1(object sender, EventArgs e)
        {

            int i = 0, Xo = 1;
            int j = 0;
            int X1 = 0, X2 = 0;
            decimal W11 = 0, W21 = 0;
            decimal U1 = 0;
            decimal YD1 = 0;
            decimal Rata = 0;
            int aux_i = 1;

            //
            decimal Aux_W11 = 0, Aux_W21 = 0;
            decimal Aux_U1 = 0;

            decimal S1 = 0;
            decimal YR1 = 0;
            decimal El1 = 0;
            decimal Ep = 0;
            decimal ERMS = 0;

            do
            {
                for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
                {
                    if (p == i)
                    {
                        X1 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[0].Value.ToString());
                        X2 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[1].Value.ToString());
                    }
                }
                //actualizar
                if (j == 0)
                {
                    for (int p = 0; p < TablaDatosPesosIniciales.RowCount; p++)
                    {
                        if (p == i)
                        {
                            W11 = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[p].Cells[0].Value.ToString());
                            W21 = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[p].Cells[1].Value.ToString());
                        }
                    }

                    for (int p = 0; p < TablaDatosUmbrales.RowCount; p++)
                    {
                        if (p == i)
                        {
                            U1 = Convert.ToDecimal(TablaDatosUmbrales.Rows[p].Cells[0].Value.ToString());
                        }
                    }
                }
                else
                {
                    W11 = Aux_W11;
                    W21 = Aux_W21;
                    U1 = Aux_U1;
                }
                //
                S1 = datosUnicapa.CalcularSalidaFuncion(X1, X2, W11, W21, U1);
                YR1 = datosUnicapa.CalcularSalidaRed(S1);

                for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
                {
                    if (p == i)
                    {
                        YD1 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[2].Value.ToString());
                    }
                }

                El1 = datosUnicapa.CalcularErroresLinealesProducidos(YD1, YR1);
                Ep = datosUnicapa.CalcularErrorPatron(El1, Convert.ToInt32(TextoSalidas.Text));

                listaEp.Add(Ep);

                Rata = Convert.ToDecimal(TextoRataAprendizaje.Text);
                Aux_W11 = datosUnicapa.AjustarMatrizPesos(W11, Rata, El1, X1);
                Aux_W21 = datosUnicapa.AjustarMatrizPesos(W21, Rata, El1, X2);
                Aux_U1 = datosUnicapa.AjustarMatrizVectorUmbrales(U1, Rata, El1, Xo);

                if (i + 1 == Convert.ToInt32(TextoPatrones.Text))
                {
                    MessageBox.Show(" ITERACION COMPLETADA " + aux_i);
                    ERMS = datosUnicapa.CalcularErrorRMS(listaEp);
                    MessageBox.Show(ERMS.ToString());
                    estado = datosUnicapa.EstadoIA(Math.Round(ERMS, 5), Convert.ToDecimal(TextoErrorPermitido.Text));
                    respuesta = datosUnicapa.RespuestaIA(Math.Round(ERMS, 5), Convert.ToDecimal(TextoErrorPermitido.Text));

                    listaEp.Clear();
                    AuxIteraciones++;

                    TextoNumIteraciones.Text = AuxIteraciones.ToString();
                    MessageBox.Show(respuesta);
                    listaERMS.Add(ERMS);

                    TablaERMS.Rows.Clear();

                    foreach (var item in listaERMS)
                    {
                        TablaERMS.Rows.Add(Math.Round(item, 5).ToString());

                    }
                    i = 0;

                    Grafico.Series["ChartLinea"].Points.AddXY(aux_i, ERMS);

                    aux_i++;
                }
                else
                {
                    i++;
                    j++;
                    estado = false;
                }

            } while (estado == false);

            GuardarTXT(W11.ToString(), W21.ToString(), U1.ToString());
        }
        private void BotonReiniciar_Click_1(object sender, EventArgs e)
        {
            BotonEntrenarSolo.Enabled = true;
            BotonPatron.Enabled = true;
            BotonSiguientePatron.Enabled = true;
            Application.Restart();
        }

        int aux_i = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int X1 = 0, X2 = 0;
            decimal W11 = 0, W21 = 0;
            decimal U1 = 0;
            decimal S1 = 0;
            decimal YR1 = 0;

               for (int p = 0; p < TablaPesoIdeal.RowCount-1; p++)
               {
                  W11 = Convert.ToDecimal(TablaPesoIdeal.Rows[p].Cells[0].Value.ToString());
                  W21 = Convert.ToDecimal(TablaPesoIdeal.Rows[p].Cells[1].Value.ToString());
               }

               for (int p = 0; p < TablaUmbralIdeal.RowCount-1; p++)
               {
                   U1 = Convert.ToDecimal(TablaUmbralIdeal.Rows[p].Cells[0].Value.ToString());
               }

                X1 = Convert.ToInt32(TextoPatron1.Text);
                X2 = Convert.ToInt32(TextoPatron2.Text);

                S1 = datosUnicapa.CalcularSalidaFuncion(X1, X2, W11, W21, U1);
                YR1 = datosUnicapa.CalcularSalidaRed(S1);

            TextoSS.Text = S1.ToString();
            TextoYR.Text = YR1.ToString();

            Grafica2.Series["ChartLinea"].Points.AddXY(aux_i, YR1);

            aux_i++;
        }

        int A;
        int i1 = 0, Xo1 = 1;
        int j1 = 0;
        int X11 = 0, X21 = 0;
        decimal W111 = 0, W211 = 0;
        decimal U11 = 0;
        decimal YD11 = 0;
        decimal Rata1 = 0;
        decimal Aux_W111 = 0, Aux_W211 = 0;
        decimal Aux_U111 = 0;
        decimal S11 = 0;
        decimal YR11 = 0;
        int aux_ii;
        private void BotonSiguientePatron_Click(object sender, EventArgs e)
        {
            for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
            {
                if (p == i1)
                {
                    X11 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[0].Value.ToString());
                    X21 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[1].Value.ToString());
                }
            }

            if (j1 > 0)
            {
                W111 = Aux_W111;
                W211 = Aux_W211;
                U11 = Aux_U111;
            }

            //
            S11 = datosUnicapa.CalcularSalidaFuncion(X11, X21, W111, W211, U11);
            YR11 = datosUnicapa.CalcularSalidaRed(S11);

            TextoS1.Text = S11.ToString();
            TextoYR1.Text = YR11.ToString();

            for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
            {
                if (p == i1)
                {
                    YD11 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[2].Value.ToString());
                }
            }

            El11 = datosUnicapa.CalcularErroresLinealesProducidos(YD11, YR11);
            Ep1 = datosUnicapa.CalcularErrorPatron(El11, Convert.ToInt32(TextoSalidas.Text));

            TextoEl1.Text = El11.ToString();
            TextoEP.Text = Ep1.ToString();

            listaEp.Add(Ep1);

            Rata1 = Convert.ToDecimal(TextoRataAprendizaje.Text);
            Aux_W111 = datosUnicapa.AjustarMatrizPesos(W111, Rata1, El11, X11);
            Aux_W211 = datosUnicapa.AjustarMatrizPesos(W211, Rata1, El11, X21);
            Aux_U111 = datosUnicapa.AjustarMatrizVectorUmbrales(U11, Rata1, El11, Xo1);

            TextoW11.Text = Aux_W111.ToString();
            TextoW21.Text = Aux_W211.ToString();
            TextoU1.Text = Aux_U111.ToString();

            TextoRestante.Text = (Convert.ToInt32(TextoPatrones.Text) - A).ToString();

             if (i1 + 1 == Convert.ToInt32(TextoPatrones.Text))
                         {
                             MessageBox.Show(" ITERACION COMPLETADA " + aux_ii);
                             ERMS1 = datosUnicapa.CalcularErrorRMS(listaEp);
                             TextoERMS.Text = ERMS1.ToString();

                             MessageBox.Show(ERMS1.ToString());
                             estado = datosUnicapa.EstadoIA(Math.Round(ERMS1, 5), Convert.ToDecimal(TextoErrorPermitido.Text));
                             respuesta = datosUnicapa.RespuestaIA(Math.Round(ERMS1, 5), Convert.ToDecimal(TextoErrorPermitido.Text));

                             listaEp.Clear();
                             AuxIteraciones++;

                             TextoNumIteraciones.Text = AuxIteraciones.ToString();
                             MessageBox.Show(respuesta);
                             listaERMS.Add(ERMS1);

                             TablaERMS.Rows.Clear();

                             foreach (var item in listaERMS)
                             {
                                 TablaERMS.Rows.Add(Math.Round(item, 5).ToString());

                             }
                             i1 = 0;
                             TextoRestante.Text = TextoPatrones.Text;
                             Grafico.Series["ChartLinea"].Points.AddXY(aux_ii, ERMS1);

                             aux_ii++;
                         }
            
            else
            {
                i1++;
                j1++;
                estado = false;
            }

        if (estado == true)
        {
            GuardarTXT(W111.ToString(), W211.ToString(), U11.ToString());
        }
        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            FRMInicial inicial = new FRMInicial();
            inicial.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {

        }

        decimal El11 = 0;
        decimal Ep1 = 0;
        decimal ERMS1 = 0;
        private void BotonPatron_Click_1(object sender, EventArgs e)
        {
                for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
                {
                    if (p == i1)
                    {
                        X11 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[0].Value.ToString());
                        X21 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[1].Value.ToString());
                    }
                }
                //actualizar
                if (j1 == 0)
                {
                    for (int p = 0; p < TablaDatosPesosIniciales.RowCount; p++)
                    {
                        if (p == i1)
                        {
                            W111 = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[p].Cells[0].Value.ToString());
                            W211 = Convert.ToDecimal(TablaDatosPesosIniciales.Rows[p].Cells[1].Value.ToString());
                        }
                    }

                    for (int p = 0; p < TablaDatosUmbrales.RowCount; p++)
                    {
                        if (p == i1)
                        {
                            U11 = Convert.ToDecimal(TablaDatosUmbrales.Rows[p].Cells[0].Value.ToString());
                        }
                    }
                }

                
                //
                S11 = datosUnicapa.CalcularSalidaFuncion(X11, X21, W111, W211, U11);
                YR11 = datosUnicapa.CalcularSalidaRed(S11);

                TextoS1.Text = S11.ToString();
                TextoYR1.Text = YR11.ToString();

                for (int p = 0; p < TablaDatosEntradaSalida.RowCount; p++)
                {
                    if (p == i1)
                    {
                        YD11 = Convert.ToInt32(TablaDatosEntradaSalida.Rows[p].Cells[2].Value.ToString());
                    }
                }

                El11 = datosUnicapa.CalcularErroresLinealesProducidos(YD11, YR11);
                Ep1 = datosUnicapa.CalcularErrorPatron(El11, Convert.ToInt32(TextoSalidas.Text));

                TextoEl1.Text = El11.ToString();
                TextoEP.Text = Ep1.ToString();

                listaEp.Add(Ep1);

                Rata1 = Convert.ToDecimal(TextoRataAprendizaje.Text);
                Aux_W111 = datosUnicapa.AjustarMatrizPesos(W111, Rata1, El11, X11);
                Aux_W211 = datosUnicapa.AjustarMatrizPesos(W211, Rata1, El11, X21);
                Aux_U111 = datosUnicapa.AjustarMatrizVectorUmbrales(U11, Rata1, El11, Xo1);

                TextoW11.Text = Aux_W111.ToString();
                TextoW21.Text = Aux_W211.ToString();
                TextoU1.Text = Aux_U111.ToString();
                TextoRestante.Text = (Convert.ToInt32(TextoPatrones.Text) - A).ToString();

            BotonSiguientePatron.Enabled = true;
            BotonEntrenarSolo.Enabled = false;
            BotonPatron.Enabled = false;
        }
    }
}
