using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
using BLL;

namespace PulsacionesGUI
{
    public partial class FrmConsultarPersona : Form
    {
        public IRecibe FrmRecibe;

        PersonaService personaService = new PersonaService();
        DocumentoPDF documentoPDF = new DocumentoPDF();
        public FrmConsultarPersona()
        {
            InitializeComponent();
        }
        public FrmConsultarPersona(IRecibe frmRecibe)
        {
            InitializeComponent();
            FrmRecibe = frmRecibe;
        }


        private void TablaPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnConsultarTodo_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            List<Persona> personas = new List<Persona>();
            personas = personaService.Consultar();
            tablaPersona.DataSource = null;
            tablaPersona.DataSource = personas;
            tablaPersona.Refresh();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            documentoPDF.GuardarPDF();
            MessageBox.Show("Reporte Generado");
        }

        private void TablaPersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Persona persona = new Persona();
            persona = (Persona)tablaPersona.CurrentRow.DataBoundItem;

            FrmRecibe.Recibir(persona);
            this.Close();
        }
    }
}
