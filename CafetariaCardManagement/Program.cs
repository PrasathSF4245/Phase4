using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHaandling.Create();
            FileHaandling.ReadFromCSV();
             //Application.AddDefaultData();
            Application.StartApplication();
            FileHaandling.WritetoCSV();
           
        }
    }
}