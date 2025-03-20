
using emiliano100.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emiliano100
{
    public partial class fmMain : Form
    {
        static fmMain _obj;
        public static fmMain Instance
        {
            get {if(_obj == null) { _obj = new fmMain(); } return _obj; }

        }
        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();
        }



        public void AddControl(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {          
            AddControl(new frmUserView());
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControl(new frmCategoryView());
        }
    }
}
