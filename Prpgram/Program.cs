using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace rainbow

{
    class Program
    {
        const string filename = "example.txt";
static void Main(string[] args)
        {
            write("1 ", " ahmed", " A", " computer science", "example.txt");
            //edit("11",1,"example.txt","12","ali","c","medicin");
           Console.WriteLine(string.Join("", read("124","example.txt",1)));
        }
        static string[] read(string searchterm, string filepath, int positionofsearchterm)
        {
            positionofsearchterm--;
            string[] recordnotfound = { "record not found" };
            try
            {
                string[] lines = File.ReadAllLines(@filepath);
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(",");
                        if (recordmatches(searchterm, fields, positionofsearchterm))
                            Console.WriteLine("record not found");
                        return fields;
                    }
                }
                return recordnotfound;
            }
            catch (Exception e)
            {
                Console.WriteLine("this program add an oppise : ");
                return recordnotfound;
                throw new ApplicationException("this program add an oppise : ", e);
            }
        }
        static void write(string ID, string name, string Class, string section,string path)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filename, true))
                {
                    file.WriteLine(ID + "," +name + "," +","+Class+","+section);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("non correct" , e);
            }
        }
        public static bool recordmatches(string searchterm, string[] record, int positionofsearchterm)
        {
            if (record[positionofsearchterm].Equals(searchterm))
            {
                return true;
            }
            return false;
        }
        public static void edit(string searchterm, int positionofsearchterm,
string path, string fileone, string filetow, string filethree, string filefour)
        {
            positionofsearchterm--;
            string temrfile = "tmp.txt" ;
            bool edited = false;
            string[] lines = File.ReadAllLines(@path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(",");
                    if (!recordmatches(searchterm, fields, positionofsearchterm))
                    {
                        write(fields[0], fields[1], fields[2], fields[3],
                        @temrfile);
                    }
                    else
                    {
                        if (!edited)
                        {
                            write(fileone, filetow, filethree, filefour,
                            @temrfile);
                            Console.WriteLine("edited");
                            edited = true;
                        }
                    }
                }
                        File.Delete(@path);
                        File.Move(temrfile, path);
                        Console.WriteLine("record edited: ");
            }
                
catch (Exception e)
            {
                Console.WriteLine("this program add an oppise :");
                throw new ApplicationException("this program add an oppise :", e);
            }
            {
            }
        }
}
}
