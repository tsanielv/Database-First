using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============");
            Console.WriteLine("Daftar Menu ");
            Console.WriteLine("1. Role");
            Console.WriteLine("2. User");
            Console.WriteLine("===============");
            Console.Write("Silahkan masukkan pilihan menu : ");
            int menu = Convert.ToInt16(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    RoleController r = new RoleController();
                    r.Menu();
                    break;

                case 2:
                    UserController u = new UserController();
                    u.Menu();
                    break;

                default:
                    break;
            }
        }
    }
}
