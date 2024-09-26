using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.GetStudentNo().ToString();
            lblName.Text = StudentInformationClass.GetFullName();
            lblProgram.Text = StudentInformationClass.GetProgram();
            lblBirthday.Text = StudentInformationClass.GetBirthDay();
            lblGender.Text = StudentInformationClass.GetGender();
            lblContactNo.Text = "+"+StudentInformationClass.GetContactNo().ToString();
            lblAge.Text = StudentInformationClass.GetAge().ToString();

        }
    }
}
