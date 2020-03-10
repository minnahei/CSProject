using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
namespace CSProject

{
    public class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream == false)
                    {
                        //Read a line from the file, storing the name in the first array element,
                        //and the position in the second element.
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        //Check the position, and add the appropriate Staff object to the list.
                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                            myStaff.Add(new Admin(result[0]));
                        else
                            WriteLine("Invalid position: {0}", result[1]);
                    }

                    sr.Close();
                }
            }
            else
                WriteLine("File not found: {0}", path);

            return myStaff;
        }
    }
}
