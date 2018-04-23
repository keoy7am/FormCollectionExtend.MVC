using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class TestData
    {
        /*  TestData
            模擬前端網頁傳回的值
             */
        public static string Name { get => "Elliot"; }
        public static int age { get => 26; }
        public static long PhoneNumber { get => 12345678; }
        public static bool Married { get => false; }
        public static DateTime CreatedDateTime { get => DateTime.Now.Date; }
        /// <summary>
        /// 資料模型內未定義之欄位
        /// </summary>
        public static DateTime ModifyDateTime { get => DateTime.Now; }
    }
}
