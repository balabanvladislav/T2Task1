﻿using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace T2Task1
{

    class Program
    {
        public static void IsEmailValid(string emailaddress)
        {
            if (emailaddress is null)
            {
                throw new ArgumentNullException("Email adress");
            }
            try
            {
                MailAddress m = new MailAddress(emailaddress);
            }
            catch (FormatException ex)
            {
                throw new ValidationException("Wrong email format!", ex);
            }
        }
        public static void IsPhoneValid(string phonenumber)
        {
            if(phonenumber is null)
            {
                throw new ArgumentNullException("Phone number");
            }
            try
            {
                foreach (char chr in phonenumber)
                    Int16.Parse(chr.ToString());
            }
            catch (FormatException ex)
            {
                throw new ValidationException("Wrong phone format!", ex);
            }
        }
        public static void IsDateValid(string date)
        {
            if (date is null)
            {
                throw new ArgumentNullException("Date");
            }
            try
            {
                DateTime.Parse(date);
            }
            catch (FormatException ex)
            {
                throw new ValidationException("Wrong date format!", ex);
            }
        }
        public static void IsZipValid(string code)
        {
            if (code is null)
            {
                throw new ArgumentNullException("Zip code");
            }
            if (code.Length == 4)
            {
                try
                {
                    foreach (char digit in code)
                        Int16.Parse(digit.ToString());
                }
                catch (FormatException ex)
                {
                    throw new ValidationException("Wrong zip format! Zip should contains only digits.", ex);
                }
            }
            else
                throw new ValidationException("Wrong zip format! Zip should contain 4 digits");

        }
        public static void IsSiteValid(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException("Website");
            }
            Regex regex = new Regex(@"^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$");

            if (!regex.IsMatch(value.ToString()))
                throw new ValidationException("Wrong site format!");
        }

        public static void Validation(Person person)
        {
            try
            {
                IsEmailValid(person.Email);
                Console.WriteLine("Email is valid.");

                IsPhoneValid(person.Phone);
                Console.WriteLine("Phone is valid.");

                IsDateValid(person.BDate);
                Console.WriteLine("Bdate is valid.");

                IsZipValid(person.ZipCode);
                Console.WriteLine("ZipCode is valid.");

                IsSiteValid(person.Website);
                Console.WriteLine("Website is valid.");

                Console.WriteLine("\nEverything is ok!");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\n__Finally__");
            }
        }
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Email = "somerandom@mail.ru",
                Phone = "060154551",
                BDate = "2.2.2020",
                ZipCode = "2345",
                Website = "https://www.lol.com"
            };

            Validation(person);

            Console.ReadKey();
        }
    }
}
