using IronXL;
using System;
using System.Collections.Generic;
using System.IO;

namespace Coolshop.SearchScript
{
    class Program
    {
        static void Main(string[] args)
        {

            string searchKey,filePath,ColNumber;

            Console.Write("Enter File Path: ");
            filePath = Console.ReadLine();

            Console.Write("Enter search Key: ");
            searchKey = Console.ReadLine();
           
            Console.Write("Enter Column Number: ");
            ColNumber = Console.ReadLine();
            int ColNum = Convert.ToInt32(ColNumber);

            filePath = string.Join("@", filePath);

            Console.WriteLine(string.Join(",",readRecord(filePath, searchKey, ColNum)));           
            Console.ReadLine();
        }

       public static string[] readRecord(string filePath, string searchKey, int ColNum)
        {
            ColNum--;
            string[] recordNotFound = { "Record Not Found"};

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fileds = lines[i].Split(',');
                    if (recordMatches(searchKey,fileds, ColNum))
                    {
                        Console.WriteLine("Record Found!");
                        return fileds;
                    }
                }

                return recordNotFound;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Programm not Executed Correct:", ex);
            }
        }

        public static bool recordMatches(string searchKey, string[] record, int position)
        {
            if (record[position].Equals(searchKey))
            {
                return true;
            }
            return false;
        }
    }
}
