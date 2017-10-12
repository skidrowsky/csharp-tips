using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//확장 메소드 구현방법
//-static class 로 구현되어야 함
//-static funciton 로 구현
//-첫번째 인자가, 확장할 클래스나 인자가 와야한다.
namespace SHIClassLibrary.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string s)
        {
            long result;
            return long.TryParse(s,out result);
        }

        public static bool IsDateTime(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            else
            {
                DateTime result;
                return DateTime.TryParse(s,out result);
            }
        }
    }
}
