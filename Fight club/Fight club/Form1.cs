using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_club
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Presenter(this);
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Value = 100;
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            progressBar2.Value = 100;
        }

        public int count = 0;
        public event EventHandler HitHead = null;
        public event EventHandler HitBody = null;
        public event EventHandler HitLegs = null;
        public event EventHandler BlockHead = null;
        public event EventHandler BlockBody = null;
        public event EventHandler BlockLegs = null;
        public event EventHandler Refresh = null;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0) HitHead(sender, e);
            else BlockHead(sender, e);
            count++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0) HitBody(sender, e);
            else BlockBody(sender, e);
            count++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0) HitLegs(sender, e);
            else BlockLegs(sender, e);
            count++;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
