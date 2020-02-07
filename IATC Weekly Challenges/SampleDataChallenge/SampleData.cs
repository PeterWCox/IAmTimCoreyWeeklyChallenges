using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleDataChallenge
{
    public class SampleData
    {
        public SampleData()
        {
            rnd = new Random();
        }

        Random rnd;

        public bool GenerateRandom()
        {
            return (rnd.NextDouble() >= 0.5);            
        }        

        public int GenerateRandom(int floor=0, int ceiling=100)
        {          
            return rnd.Next(floor, ceiling+1);
        }

        public double GenerateRandomDouble(double floor=0, double ceiling=100)
        {
            double x = rnd.NextDouble();

            return floor + x*(ceiling-floor);
        }



        public string GenerateRandomFullname(string path, char separator)
        {
            //Check that the file can be successfully opened
            bool filePathValue = File.Exists(path);
            if (!filePathValue)
            {
                throw new Exception("File does not exist - please check input and try again.");
            }

            //Open the file and convert the rows into a list of strings. 
            List<string> peopleRows = File.ReadAllLines(path).ToList();

            //Verify that each string can be broken down into only 2 substrings;
            foreach(string s in peopleRows)
            {
                string[] commaSeparatedString = s.Split(separator);
                if (commaSeparatedString.Length != 2)
                {
                    throw new Exception("Text file contains invalid data. Please ensure that each row contains only a firstname and a last name with one separator e.g. single white space or comma.");
                }
            }

            //Pick a random row. 
            var random = new Random();
            int rowNumber = random.Next(0, peopleRows.Count - 1);

            //Generate a person model based off the given random integer. 
            string row = peopleRows[rowNumber];
            string[] splitRow = row.Split(separator);

            //Create the new person model.
            string firstName = splitRow[0];
            string lastName = splitRow[1];

            return firstName + " " + lastName;
        }  



        // public static double GenerateRandom(double minValue, double maxValue)
        // {
        //     var random = new Random();
        //     double x = random.NextDouble();     //Returns value between 0.0 and 1.0
        // }

        public static string GenerateRandomPhoneNumber(string phoneNumberFormat)
        {
            //e.g. XXX-XXXXX, XXXXX XXXXXX

            string phoneNumber = "";

            for (int i=0; i<phoneNumberFormat.Length; i++)
            {
                string digit = phoneNumberFormat[i].ToString();

                if (digit == "X")
                {
                    var random = new Random();
                    phoneNumber += random.Next(0, 10).ToString();
                }
                else
                {
                    phoneNumber += digit;
                }                
            }

            return phoneNumber;
        }
       
    }
}