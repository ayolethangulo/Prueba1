using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace PulsacionesGUI
{
    public partial class FrmPersona : Form, IRecibe
    {
        PersonaService personaService = new PersonaService(); 
        public FrmPersona()
        {
            InitializeComponent();
        }

        public void Recibir(Persona persona)
        {
            if(persona != null)
            {
                TxtIdentificacion.Text = persona.Identificacion;
                TxtNombre.Text = persona.Nombre;
                TxtEdad.Text = persona.Edad.ToString();
                CmbSexo.Text = persona.Sexo;
                txtPulsaciones.Text = persona.Pulsaciones.ToString();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPersona_Load(object sender, EventArgs e)
        {

        }

        private void CmbSexo_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            Persona persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = Int32.Parse(TxtEdad.Text);
            persona.Sexo = CmbSexo.Text;
            string mensaje= personaService.Guardar(persona);
            MessageBox.Show(mensaje);
            Limpiar();
        }

        private void Limpiar()
        {
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            CmbSexo.Text = "";
            txtPulsaciones.Text = "";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            string identificacion = TxtIdentificacion.Text;
            if (identificacion != "")
            {
                persona = personaService.Buscar(identificacion);

                if (persona != null)
                {
                    TxtIdentificacion.Text = persona.Identificacion;
                    TxtNombre.Text = persona.Nombre;
                    TxtEdad.Text = persona.Edad.ToString();
                    CmbSexo.Text = persona.Sexo;
                    txtPulsaciones.Text = persona.Pulsaciones.ToString();
                    
                }
                else
                {
                    MessageBox.Show($"No se encuentra la persona");
                }
            }
            else
            {
                MessageBox.Show($"Digite una identificacion");
            }
            
            

            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            string identificacion = TxtIdentificacion.Text;

            if (identificacion != "")
            {

                persona.Identificacion = identificacion;
                persona.Nombre = TxtNombre.Text;
                persona.Edad = int.Parse(TxtEdad.Text);
                persona.Sexo = CmbSexo.Text;

                string mensaje = personaService.Modificar(identificacion, persona);
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show($"Digite una identificacion");
            }
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere eliminar el Registro?", "Eliminar Registro", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                Persona persona = new Persona();
                string identificacion = TxtIdentificacion.Text;

                if (identificacion != "")
                {
                    persona = personaService.Buscar(identificacion);
                    if (persona != null)
                    {
                        TxtIdentificacion.Text = persona.Identificacion;
                        TxtNombre.Text = persona.Nombre;
                        TxtEdad.Text = persona.Edad.ToString();
                        CmbSexo.Text = persona.Sexo;
                        txtPulsaciones.Text = persona.Pulsaciones.ToString();

                        string mensaje = personaService.Eliminar(identificacion);
                        MessageBox.Show(mensaje);
                    }

                }
                else
                {
                    MessageBox.Show($"Digite una identificacion");
                }
            }

            Limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmConsultarPersona frmConsultar = new FrmConsultarPersona(this);
            frmConsultar.Show();
        }
    }
}
