using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    public partial class Help : Form
    {
        Form1 form;
        public Help()
        {
            InitializeComponent();
        }
        
        public Help(Form1 parent)
        {
            form = parent;
            form.Enabled = false;
            InitializeComponent();
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
