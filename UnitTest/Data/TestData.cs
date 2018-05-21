using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    /// <summary>
    /// Simulate form values.
    /// </summary>
    public static class TestData
    {
        public static string Name { get => "Elliot"; }
        public static int age { get => 26; }
        public static long PhoneNumber { get => 12345678; }
        public static bool Married { get => false; }
        public static DateTime CreatedDateTime { get => DateTime.Now.Date; }
        /// <summary>
        /// This field does not exist in the model.
        /// </summary>
        public static DateTime ModifyDateTime { get => DateTime.Now; }
    }
}
