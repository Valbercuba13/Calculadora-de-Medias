using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Implementação do evento label1_Click
        }

        private void button1_Click(object sender, EventArgs e) // Limpar
        {
            foreach (Control controle in GetAllControls(this))
            {
                if (controle is TextBox textBox)
                {
                    textBox.Text = "";
                }
                else if (controle.Name == "Label7" && controle is Label label)
                {
                    label.Text = "...";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Calcular
        {
            const int numTextBoxes = 4;
            float soma = 0;

            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        // Se o TextBox estiver em branco, consideramos 0
                        soma += 0;
                    }
                    else
                    {
                        if (float.TryParse(textBox.Text, out float valor))
                        {
                            soma += valor;
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira valores numéricos válidos em todas as caixas de texto.");
                            return;
                        }
                    }
                }
            }

            if (Controls["Label7"] is Label label)
            {
                float media = soma / numTextBoxes;
                label.Text = media.ToString();
            }
        }

        // Método auxiliar para obter todos os controles recursivamente
        private IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }
    }
}
