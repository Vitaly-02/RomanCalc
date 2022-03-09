using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanNumbers;

namespace RomanCalc.Models
{
    class RomanNumberExtend : RomanNumber
    {
        
        public RomanNumberExtend(string value)
            : base(ToUshort(value))
        {
           
        }
        
        private static ushort ToUshort(string value)
        {
        ushort[] numeric = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbolic = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        string temp = value;
            ushort arabicForm = 0;
            for (int i = 1; i < 13; i += 2)
            {
                while (temp.Contains(symbolic[i]))
                {
                    arabicForm += numeric[i];
                    int startIndex = temp.IndexOf(symbolic[i][0]);
                    temp = temp.Remove(startIndex, symbolic[i].Length);
                }
            }
            for (int i = 0; i < 13; i += 2)
            {
                while (temp.Contains(symbolic[i]))
                {
                    arabicForm += numeric[i];
                    int startIndex = temp.IndexOf(symbolic[i][0]);
                    temp = temp.Remove(startIndex, symbolic[i].Length);
                }
            }

            return arabicForm;
        }
    } 
    /*
    public ushort ToUshort(string value)
        {
            string temp = value;
            ushort arabicForm = 0;
            for (int i = 1; i < 13; i += 2)
            {
                while (temp.Contains(_symbolic[i]))
                {
                    arabicForm += _numeric[i];
                    int startIndex = temp.IndexOf(_symbolic[i][0]);
                    temp = temp.Remove(startIndex, _symbolic[i].Length);
                }
            }
            for (int i = 0; i < 13; i += 2)
            {
                while (temp.Contains(_symbolic[i]))
                {
                    arabicForm += _numeric[i];
                    int startIndex = temp.IndexOf(_symbolic[i][0]);
                    temp = temp.Remove(startIndex, _symbolic[i].Length);
                }
            }

            return arabicForm;
        } 
    */
   // }
}
