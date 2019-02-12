using System;

namespace DoctorWeb.Utility
{
    public class RandomNumber {

        public static String smallNumber() {
            Random rnd = new Random();
            int value = rnd.Next(1, 9999);
            return value.ToString();
        }

        public static String taxNumber()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 99);
            return value.ToString();
        }
    }
}