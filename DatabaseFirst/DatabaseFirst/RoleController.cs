using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseFirst
{
    public class RoleController
    {
        dbEntities _context = new dbEntities();
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Daftar Menu ");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Get All");
            Console.WriteLine("3. Get By ID");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("===============");
            Console.Write("Silahkan masukkan pilihan menu : ");
            int menu = Convert.ToInt16(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Insert();
                    Console.ReadKey(true);
                    break;

                case 2:
                    GetAll();
                    Console.ReadKey(true);
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Masukkan Id yang dicari : ");
                    int send = Convert.ToInt16(Console.ReadLine());
                    GetById(send);
                    Console.ReadKey(true);
                    break;

                case 4:
                    Console.Clear();
                    Console.Write("Masukkan Id yang akan diedit : ");
                    int send2 = Convert.ToInt16(Console.ReadLine());
                    Update(send2);
                    GetById(send2);
                    Console.ReadKey(true);
                    break;

                case 5:
                    Console.Clear();
                    Console.Write("Masukkan Id yang akan dihapus : ");
                    int send3 = Convert.ToInt16(Console.ReadLine());
                    Delete(send3);
                    Console.ReadKey(true);
                    break;

                default:
                    break;
            }
        }


        public void Insert()
        {
            Console.Clear();
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nama Role : ");
            string name = Console.ReadLine();


            Role role = new Role();
            {
                role.id = id;
                role.name = name;
            };
            try
            {
                _context.Roles.Add(role);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        public List<Role> GetAll()
        {
            Console.Clear();

            var getall = _context.Roles.ToList();
            foreach (Role role in getall)
            {
                Console.WriteLine("Id : " + role.id);
                Console.WriteLine("Nama Role : " + role.name);
                Console.WriteLine("");
            }
            return getall;
        }

        public Role GetById(int find)
        {

            var role = _context.Roles.Find(find);
            if (role == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (role.id == find)
            {
                Console.WriteLine("Id     : " + role.id);
                Console.WriteLine("Nama   : " + role.name);
            }
            return role;
        }

        public Role SearchById(int find)
        {

            var role = _context.Roles.Find(find);
            if (role == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return role;
        }

        public int Update(int find)
        {

            Console.Write("Masukkan Nama Baru : ");
            string name_new = Console.ReadLine();

            var getrole = _context.Roles.Find(find);
            if (getrole == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                Role role = SearchById(find);
                role.name = name_new;

                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return find;
        }


        public int Delete(int find)
        {
            Role role = SearchById(find);
            _context.Entry(role).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return find;

        }


    }
}
