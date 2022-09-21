using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Insertar_Click(object sender, EventArgs e)
        {
          int registrosAfectados = 0;
            registrosAfectados = Conexion.EjecutarConsulta(textBox1.Text);
            Mensajes.Mensaje("Registros Afectados: "+registrosAfectados);
            LlenarCombo(textBox1.Text, comboBox1, "id","Nombre");
        }
        public static void LlenarCombo(string consulta, ComboBox combo, string id, string campo)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = id;
            combo.DisplayMember = campo;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text= comboBox1.SelectedValue.ToString();
        }
    }
}
