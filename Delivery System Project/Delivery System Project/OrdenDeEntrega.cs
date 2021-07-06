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
    public partial class OrdenDeEntrega : Form
    {
        OrdenDeEntregaLibreria ordenDeEntregaLibreria;
        public OrdenDeEntrega()
        {
            this.ordenDeEntregaLibreria = new OrdenDeEntregaLibreria();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrdenDeEntrega_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ordenDeEntregaLibreria.GetAll();
            this.dataGridView1.Columns[2].Width = 200;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }
            try
            {
                var selectedRow = (DeliverySystem.Security.OrdenDeEntrega)dataGridView1.SelectedRows[0].DataBoundItem;
                var form = new OrdenDeEntregaDetalle(selectedRow.Codigo);
                form.Show();
                this.Close();
            }
            catch (Exception esc)
            {
                return;
            }
        }
    }
}
