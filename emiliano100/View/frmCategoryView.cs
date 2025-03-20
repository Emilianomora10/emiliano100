using emiliano100.model;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emiliano100.View
{
    public partial class frmCategoryView : Form2
    {
        private object guna2MessageDialog1;
        private object dgvid;

        public frmCategoryView()
        {
            InitializeComponent();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
            LaodData();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            LaodData();
        }

        private void LaodData()
        {
            ListBox ib = new ListBox();
            ib.Items.Add(dgvid);
            ib.Items.Add(dgvname);
            

            string qry = @"Select userID , uName , uUsername from user 
                        Where uName like ' % " + txtSearch.Text + " % ' order by userID desc ";
            MainClass.LoadData(qry, guna2DataGridView1, ib);

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmUserAdd frm = new frmUserAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvname"].Value);
                MainClass.BlurBackground(frm);
                LaodData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                guna2MessageDialog2.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                guna2MessageDialog2.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            
                if (guna2MessageDialog2.Show("Estas seguro de que quieres eliminar?")==DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete From users where userID = " + id + "";
                    Hashtable ht = new Hashtable();
                    if (MainClass.SQL(qry, ht) > 0)
                    {
                        guna2MessageDialog2.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog2.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog2.Show("Delete successfully..");
                        LaodData();
                    }
                }


            }
        }


    }
}
