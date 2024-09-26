using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private bool isValid = true;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private String _FullName;  
        private int _Age;         
        private long _ContactNo;   
        private long _StudentNo;

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                isValid = true;
                StudentInformationClass.SetFullName = $"{txtLastName.Text}, {txtFirstName.Text}, {txtMiddleInitial.Text}";
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text); 
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text); 
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                if (isValid) 
                {

                    frmConfirmation frm = new frmConfirmation();
                    frm.ShowDialog();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                switch (ex.Message)
                {
                    case "Invalid student number format.":
                        txtStudentNo.Focus();
                        break;
                    case "Invalid contact number format. It should start with '+' followed by 9 to 13 digits.":
                        txtContactNo.Focus();
                        break;
                    case "Names can only contain letters.":
                        if (!Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z]+$"))
                        {
                            txtLastName.Focus();
                        }
                        else if (!Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z]+$"))
                        {
                            txtFirstName.Focus();
                        }
                        else
                        {
                            txtMiddleInitial.Focus();
                        }
                        break;
                    case "Invalid age format.":
                        txtAge.Focus();
                        break;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Registration process completed.");
            }
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

            string[] ListOfProgram = new string[]
             {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
             };

            try
            {
                cbPrograms.Items.AddRange(ListOfProgram);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("An error occurred while loading the programs: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program loading process completed.");
            }
        }

        /////return methods 
        public long StudentNumber(string studNum)
        {
            try
            {
                if (Regex.IsMatch(studNum, @"^[0-9]{10,11}$"))
                {
                    _StudentNo = long.Parse(studNum);
                    return _StudentNo;
                }
                else
                {
                    isValid = false;
                    throw new FormatException("Invalid student number format.");
                }
            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }

        public long ContactNo(string contact)
        {
            try
            {
                if (Regex.IsMatch(contact, @"^\+?[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(contact);
                    return _ContactNo;
                }
                else

                {
                    isValid = false;
                    throw new FormatException("Invalid contact number format.");
                }
            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName
         + ", " + FirstName + ", " + MiddleInitial;
                    return _FullName;
                }
                else

                {
                    isValid = false;
                    throw new FormatException("Invalid name format.");
                }
            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Error: " + ex.Message);
                return string.Empty;
            }
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                    return _Age;
                }
                else
                {
                    isValid = false;
                    throw new FormatException("Invalid age format.");
                }
            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }
    }
}
