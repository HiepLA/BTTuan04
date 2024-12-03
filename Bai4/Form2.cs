using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Bai4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

       


        private void btnThem_Click(object sender, EventArgs e)
        {
            Parent.dataSV.Rows.Add(txtMssv.Text, txtTen.Text, cmb_Khoa.Text, txtDTB.Text);
            this.Close();
        }
      

       
       
    }



}
   

