using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades_TP;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(textBox1.Text);
            Numero num2 = new Numero(textBox2.Text);
            string operador = comboBox1.Text;
            label2.Text = Calculadora.Operar(num1, num2, operador).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Realiza la limpieza de datos en la calculadora
        /// </summary>
        /// <param name="form">Objeto Form sobre el cual va a limpiar la pantalla</param>
        static void Limpiar(Form1 form)
        {
            form.textBox1.Clear();
            form.textBox2.Clear();
            form.label2.Text = "";
            form.comboBox1.Text = "";
        }
    }
}
