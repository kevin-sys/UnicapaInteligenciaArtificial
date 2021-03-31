namespace UnicapaInteligenciaArtificial
{
    partial class FRMInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMInicial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BotonSali = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BotonBackPropagationPrimitivo = new System.Windows.Forms.Button();
            this.BotonBackPropagationCascada = new System.Windows.Forms.Button();
            this.BotonMulticapa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BotonUnicapa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BotonSali);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 60);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // BotonSali
            // 
            this.BotonSali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonSali.FlatAppearance.BorderSize = 0;
            this.BotonSali.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonSali.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BotonSali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonSali.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonSali.Image = ((System.Drawing.Image)(resources.GetObject("BotonSali.Image")));
            this.BotonSali.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonSali.Location = new System.Drawing.Point(242, 12);
            this.BotonSali.Name = "BotonSali";
            this.BotonSali.Size = new System.Drawing.Size(76, 30);
            this.BotonSali.TabIndex = 37;
            this.BotonSali.Text = "EXIT";
            this.BotonSali.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonSali.UseVisualStyleBackColor = true;
            this.BotonSali.Click += new System.EventHandler(this.BotonSali_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BotonBackPropagationPrimitivo);
            this.panel2.Controls.Add(this.BotonBackPropagationCascada);
            this.panel2.Controls.Add(this.BotonMulticapa);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BotonUnicapa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 494);
            this.panel2.TabIndex = 1;
            // 
            // BotonBackPropagationPrimitivo
            // 
            this.BotonBackPropagationPrimitivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonBackPropagationPrimitivo.FlatAppearance.BorderSize = 0;
            this.BotonBackPropagationPrimitivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonBackPropagationPrimitivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BotonBackPropagationPrimitivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonBackPropagationPrimitivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonBackPropagationPrimitivo.Image = ((System.Drawing.Image)(resources.GetObject("BotonBackPropagationPrimitivo.Image")));
            this.BotonBackPropagationPrimitivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonBackPropagationPrimitivo.Location = new System.Drawing.Point(55, 338);
            this.BotonBackPropagationPrimitivo.Name = "BotonBackPropagationPrimitivo";
            this.BotonBackPropagationPrimitivo.Size = new System.Drawing.Size(235, 70);
            this.BotonBackPropagationPrimitivo.TabIndex = 43;
            this.BotonBackPropagationPrimitivo.Text = "BACKPROPAGATION PRIMITIVO BASICO";
            this.BotonBackPropagationPrimitivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonBackPropagationPrimitivo.UseVisualStyleBackColor = true;
            this.BotonBackPropagationPrimitivo.Click += new System.EventHandler(this.BotonBackPropagationPrimitivo_Click);
            // 
            // BotonBackPropagationCascada
            // 
            this.BotonBackPropagationCascada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonBackPropagationCascada.FlatAppearance.BorderSize = 0;
            this.BotonBackPropagationCascada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonBackPropagationCascada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BotonBackPropagationCascada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonBackPropagationCascada.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonBackPropagationCascada.Image = ((System.Drawing.Image)(resources.GetObject("BotonBackPropagationCascada.Image")));
            this.BotonBackPropagationCascada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonBackPropagationCascada.Location = new System.Drawing.Point(55, 262);
            this.BotonBackPropagationCascada.Name = "BotonBackPropagationCascada";
            this.BotonBackPropagationCascada.Size = new System.Drawing.Size(235, 70);
            this.BotonBackPropagationCascada.TabIndex = 42;
            this.BotonBackPropagationCascada.Text = "BACKPROPAGATION CASCADA";
            this.BotonBackPropagationCascada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonBackPropagationCascada.UseVisualStyleBackColor = true;
            this.BotonBackPropagationCascada.Click += new System.EventHandler(this.BotonBackPropagationCascada_Click);
            // 
            // BotonMulticapa
            // 
            this.BotonMulticapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonMulticapa.FlatAppearance.BorderSize = 0;
            this.BotonMulticapa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonMulticapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BotonMulticapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonMulticapa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonMulticapa.Image = ((System.Drawing.Image)(resources.GetObject("BotonMulticapa.Image")));
            this.BotonMulticapa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonMulticapa.Location = new System.Drawing.Point(55, 186);
            this.BotonMulticapa.Name = "BotonMulticapa";
            this.BotonMulticapa.Size = new System.Drawing.Size(235, 70);
            this.BotonMulticapa.TabIndex = 41;
            this.BotonMulticapa.Text = "PERCEPTRON MULTICAPA";
            this.BotonMulticapa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonMulticapa.UseVisualStyleBackColor = true;
            this.BotonMulticapa.Click += new System.EventHandler(this.BotonMulticapa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 32);
            this.label1.TabIndex = 40;
            this.label1.Text = "RED NEURONAL";
            // 
            // BotonUnicapa
            // 
            this.BotonUnicapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonUnicapa.FlatAppearance.BorderSize = 0;
            this.BotonUnicapa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonUnicapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BotonUnicapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonUnicapa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonUnicapa.Image = ((System.Drawing.Image)(resources.GetObject("BotonUnicapa.Image")));
            this.BotonUnicapa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonUnicapa.Location = new System.Drawing.Point(55, 110);
            this.BotonUnicapa.Name = "BotonUnicapa";
            this.BotonUnicapa.Size = new System.Drawing.Size(235, 70);
            this.BotonUnicapa.TabIndex = 38;
            this.BotonUnicapa.Text = "PERCEPTRON UNICAPA";
            this.BotonUnicapa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BotonUnicapa.UseVisualStyleBackColor = true;
            this.BotonUnicapa.Click += new System.EventHandler(this.BotonUnicapa_Click);
            // 
            // FRMInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMInicial";
            this.Text = "FRMInicial";
            this.Load += new System.EventHandler(this.FRMInicial_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BotonSali;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotonUnicapa;
        private System.Windows.Forms.Button BotonBackPropagationCascada;
        private System.Windows.Forms.Button BotonMulticapa;
        private System.Windows.Forms.Button BotonBackPropagationPrimitivo;
    }
}