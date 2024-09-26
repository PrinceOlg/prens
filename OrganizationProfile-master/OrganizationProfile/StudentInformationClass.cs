 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    internal class StudentInformationClass
    {

        public static long SetStudentNo { get; set; } = 0;
        public static long SetContactNo { get; set; } = 0;
        public static string SetProgram { get; set; } = "";
        public static string SetGender { get; set; } = "";
        public static string SetBirthday { get; set; } = "";
        public static string SetFullName { get; set; } = "";
        public static int SetAge { get; set; } = 0;


        public static long GetStudentNo() => SetStudentNo;
        public static string GetFullName() => SetFullName;
        public static string GetProgram() => SetProgram;
        public static string GetBirthDay() => SetBirthday;
        public static string GetGender() => SetGender;
        public static long GetContactNo() => SetContactNo;
        public static int GetAge() => SetAge;
    }
}
