namespace PulsacionesGUI
{
    partial class FrmConsultarPersona
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
            this.tablaPersona = new System.Windows.Forms.DataGridView();
            this.btnConsultarTodo = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaPersona
            // 
            this.tablaPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPersona.Location = new System.Drawing.Point(20, 69);
            this.tablaPersona.Name = "tablaPersona";
            this.tablaPersona.Size = new System.Drawing.Size(768, 369);
            this.tablaPersona.TabIndex = 0;
            this.tablaPersona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaPersona_CellContentClick);
            this.tablaPersona.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaPersona_CellDoubleClick);
            // 
            // btnConsultarTodo
            // 
            this.btnConsultarTodo.Location = new System.Drawing.Point(689, 25);
            this.btnConsultarTodo.Name = "btnConsultarTodo";
            this.btnConsultarTodo.Size = new System.Drawing.Size(99, 38);
            this.btnConsultarTodo.TabIndex = 1;
            this.btnConsultarTodo.Text = "Consultar";
            this.btnConsultarTodo.UseVisualStyleBackColor = true;
            this.btnConsultarTodo.Click += new System.EventHandler(this.BtnConsultarTodo_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(584, 25);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(99, 38);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "Generar Reporte PDF";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // FrmConsultarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnConsultarTodo);
            this.Controls.Add(this.tablaPersona);
            this.Name = "FrmConsultarPersona";
            this.Text = "Consultar Persona";
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersona)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaPersona;
        private System.Windows.Forms.Button btnConsultarTodo;
        private System.Windows.Forms.Button btnReporte;
    }
}