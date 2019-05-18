using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMagazine.Class
{
    static class GlobalClass
    {
        public static string UserName;
        public static Int32 ProgressValue;
        public static string ShortName;
        public static string StateCode;
        public static string StateName;
        public static string CompName;
        public static string Address1;
        public static string Address2;
        public static string Address3;
        public static string User
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public static Int32 Prg_Value
        {
            get { return ProgressValue; }
            set { ProgressValue = value; }
        }
        public static string ShrtName
        {
            get { return ShortName; }
            set { ShortName = value; }
        }

        public static string State_Code
        {
            get { return StateCode;}
            set { StateCode = value; }
        }

        public static string State_name
        {
            get { return StateName; }
            set { StateName = value; }
        }
        public static string Comp_Name
        {
            get { return CompName; }
            set { CompName = value; }
        }

        public static string Address_1
        {
            get { return Address1; }
            set { Address1 = value; }
        }
        public static string Address_2
        {
            get { return Address2; }
            set { Address2 = value; }
        }
        public static string Address_3
        {
            get { return Address3; }
            set { Address3 = value; }
        }
    }
}
