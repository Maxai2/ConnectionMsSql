using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionMsSql
{
    public partial class Form1 : Form
    {
        private IntelDB _db = new IntelDB();
        //----------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------
        private void bConnect_Click(object sender, EventArgs e)
        {
            if (_db.OpenConnection())
            {
                EnableButton(true);
            }
            else
            {
                MessageBox.Show("Some error!");
                EnableButton(false);
            }
        }
        //----------------------------------------------------------------------
        private void bDisconnect_Click(object sender, EventArgs e)
        {
            _db.CloseConnection();
            EnableButton(false);
        }
        //----------------------------------------------------------------------
        private void EnableButton(bool isConnect)
        {
            bDisconnect.Enabled = isConnect;
            bSelectAll.Enabled = isConnect;
            bSelectById.Enabled = isConnect;
            bAvgPrice.Enabled = isConnect;
            bConnect.Enabled = !isConnect;
        }
        //----------------------------------------------------------------------
        private void bSelectAll_Click(object sender, EventArgs e)
        {
            List<Processor> procs = _db.GetAllProcessors();

            if (procs != null)
            {
                lbData.DataSource = procs;
                lbData.DisplayMember = "Info";
                lbData.ValueMember = "Id";
            }
        }
        //----------------------------------------------------------------------
        private void bSelectById_Click(object sender, EventArgs e)
        {
            if (lbData.SelectedIndex != -1)
            {
                int id = Convert.ToInt32(lbData.SelectedValue);
                Processor processor = _db.GetProcessorById(id);
                tbIdSelect.Text = processor?.FullInfo();
            }
        }
        //----------------------------------------------------------------------
        private void bAvgPrice_Click(object sender, EventArgs e)
        {
            int avg = _db.GetAvgPrice();

            tbAvgPrice.Text = avg.ToString();
        }
    }
}
