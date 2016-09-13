using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp1_Lab_II
{
    public partial class Calculadora : Form
    {
        private string _numero1 = "";
        private string _numero2 = "";
        private double _resultado;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            _numero1 = txtNumero1.Text;
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            _numero2 = txtNumero2.Text;
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "00";
            cmbOperacion.Text = "";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numeroA = new Numero(_numero1);
            Numero numeroB = new Numero(_numero2);
            string aux = "0";
            string operador = cmbOperacion.Text;
            operador = Calculadora2.ValidarOperador(operador);
            _resultado = Calculadora2.Operar(numeroA, numeroB, operador);

            if (_resultado == 0)
            {
                _resultado.ToString();
                lblResultado.Text = aux + _resultado;
            }

            else
                lblResultado.Text = _resultado.ToString();
        }
    }
}
