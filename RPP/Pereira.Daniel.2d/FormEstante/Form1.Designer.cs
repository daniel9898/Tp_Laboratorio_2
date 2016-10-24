using Entidades;
namespace FormEstante
{
    partial class FormEstante
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnOrdenar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.rtxtSalida = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnOrdenar
            // 
            this.BtnOrdenar.BackColor = System.Drawing.Color.Transparent;
            this.BtnOrdenar.Location = new System.Drawing.Point(12, 24);
            this.BtnOrdenar.Name = "BtnOrdenar";
            this.BtnOrdenar.Size = new System.Drawing.Size(97, 43);
            this.BtnOrdenar.TabIndex = 0;
            this.BtnOrdenar.Text = "Ordenar";
            this.BtnOrdenar.UseVisualStyleBackColor = false;
            this.BtnOrdenar.Click += new System.EventHandler(this.BtnOrdenar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(175, 24);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(97, 43);
            this.btnEjecutar.TabIndex = 1;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // rtxtSalida
            // 
            this.rtxtSalida.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtSalida.DetectUrls = false;
            this.rtxtSalida.HideSelection = false;
            this.rtxtSalida.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rtxtSalida.Location = new System.Drawing.Point(30, 82);
            this.rtxtSalida.Name = "rtxtSalida";
            this.rtxtSalida.ReadOnly = true;
            this.rtxtSalida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtxtSalida.ShortcutsEnabled = false;
            this.rtxtSalida.Size = new System.Drawing.Size(227, 213);
            this.rtxtSalida.TabIndex = 2;
            this.rtxtSalida.TabStop = false;
            this.rtxtSalida.Text = "";
            this.rtxtSalida.WordWrap = false;
            // 
            // FormEstante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.rtxtSalida);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.BtnOrdenar);
            this.Name = "FormEstante";
            this.Text = "Estantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEstante_FormClosing);
            //this.Load += new System.EventHandler(this.FormEstante_Load);
            this.ResumeLayout(false);

        }

        private void BtnOrdenar_Click(object sender, System.EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;
            this.CargarEstante(out est1, out est2);
            rtxtSalida.Text += "Estante 1 ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);

            rtxtSalida.Text += "Estante 2 ordenado por Marca....\n";
            est2.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est2);
        }

        #endregion

        private System.Windows.Forms.Button BtnOrdenar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.RichTextBox rtxtSalida;
    }
}

