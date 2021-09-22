using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace T2Task1
{

    class Program
    {
        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsPhoneValid(string phonenumber)
        {
            try
            {
                foreach (char chr in phonenumber)
                    Int16.Parse(chr.ToString());

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsDateValid(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsZipValid(string code)
        {
            if (code.Length == 4)
                return IsPhoneValid(code);
            else
                return false;
        }

        //public static bool IsSiteValid(string adress)
        //{
        //    UrlAttribute x = new UrlAttribute();
        //    return x.IsValid(adress);
        //}
        public static bool IsSiteValid(object value)
        {
            Regex regex = new Regex(@"(http://)?(www\.)?\w+\.(com|net|edu|org)");

            if (value == null) return false;

            if (!regex.IsMatch(value.ToString())) return false;

            return true;
        }


        static void Main(string[] args)
        {
            string Email = "Vladislav@mail.ru";
            string Phone = "0601f540";
            string BDate = "2.2.2020";
            string ZipCode = "4332";
            string Website = "lol.com";


            Console.WriteLine(IsSiteValid(Website));
           


            Console.WriteLine("\n______");
            Console.ReadKey();
        }
    }
}
