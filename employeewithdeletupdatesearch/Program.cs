using employeewithdeletupdatesearch.DAL;
using employeewithdeletupdatesearch.MODEL;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace employeewithdeletupdatesearch
{
    internal class Program
    {
        public static IConfiguration _iconfiguration;
        public static void Main(string[] args)
        {
            getsetting();
            print();
        }
        public static void getsetting()
        {
            var setting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("abc.json",optional:false,reloadOnChange:true);
            _iconfiguration = setting.Build();
        }
        public static void print()
        {
            emplayer el = new emplayer(_iconfiguration);
            el.search(7);
            int row=el.Delete(5);
            Console.WriteLine("row affected"+row);
            row = el.update(7);
            Console.WriteLine("row affected" + row);
            emp e = new emp { Name="prajot",salary=14850};
            row=el.insert(e);
            Console.WriteLine(row + "row added");
            string s = "prajot";
            el.nsearch(s);
        }
    }
}