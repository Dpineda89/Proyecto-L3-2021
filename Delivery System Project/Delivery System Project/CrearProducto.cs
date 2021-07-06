using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_System_Project
{
    public partial class CrearProducto : Form
    {
        private ProductoLibreria productoLibreria;

        public CrearProducto()
        {
            InitializeComponent();
            this.productoLibreria = new ProductoLibreria();
            this.textBox1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((int)this.numericUpDown1.Value <= 0 || string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox4.Text) || string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                MessageBox.Show("Los campos son requeridos");
            }
            else
            {
                try
                {
                    var cliente = new DeliverySystem.Security.Producto
                    {
                        Nombre = this.textBox1.Text,
                        Descripcion = this.richTextBox1.Text,
                        Codigo = this.textBox4.Text,
                        Cantidad = (int)this.numericUpDown1.Value,
                        PrecioUnitario = System.Convert.ToInt32(this.textBox2.Text),
                    };

                    var result = this.productoLibreria.AgregarProducto(cliente);

                    if (result == false)
                    {
                        MessageBox.Show("No se pudo crear el producto.");
                    }
                    else
                    {
                        MessageBox.Show("Se registro el producto correctamente.");
                        this.LimpiarTodo();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingrese correctamente el valor de los campos.");
                }
            }
        }

        void LimpiarTodo()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.richTextBox1.Text = string.Empty;
            this.numericUpDown1.Value = 0;
            this.textBox1.Focus();
        }

        private void CrearProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
