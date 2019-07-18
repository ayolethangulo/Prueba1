using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ENTITY;
using BLL;

namespace PulsacionesGUI
{
    public partial class Grafica : Form
    {
        PersonaService personaService = new PersonaService();
        public Grafica()
        {
            InitializeComponent();
        }

        private void BtnGrafica_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear(); 
            List<Persona> personas = new List<Persona>();

            personas = personaService.Consultar();

            foreach (var item in personas)
            {
                Series series = chart1.Series.Add(item.Nombre);

                series.Label = item.Pulsaciones.ToString();

                series.Points.Add(double.Parse(item.Pulsaciones.ToString()));
            }
        }
    }
}
