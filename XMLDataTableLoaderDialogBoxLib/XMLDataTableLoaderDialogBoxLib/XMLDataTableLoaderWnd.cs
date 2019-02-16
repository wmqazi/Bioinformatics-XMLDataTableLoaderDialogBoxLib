using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Qazi.Common.GUI.CommonDialogBoxes
{
    public delegate void XMLDataLoadedHandler();
    internal partial class XMLDataTableLoaderWnd : Form
    {
        private DataSet ds;
        public event XMLDataLoadedHandler XMLDataLoaded;
        internal string FileName;
        
        public XMLDataTableLoaderWnd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileName = openFileDialog1.FileName;
            ds = new DataSet();
            ds.ReadXml(openFileDialog1.FileName);
            label2.Text = openFileDialog1.FileName;
            foreach (DataTable dt in ds.Tables)
                comboBox1.Items.Add(dt.TableName);
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[comboBox1.Text];
            lblRecordCount.Text = "RecordCount: " + ds.Tables[comboBox1.Text].Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ds == null)
            {
                MessageBox.Show("Please Select and Load Valid XML DataTable");
                return;
            }
            XMLDataLoaded();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public DataTable DataTableSelected
        {
            get {
                return ds.Tables[comboBox1.Text];
            }
        }
    }
}