using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    public class UserController
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
            Console.Write("Nama        : ");
            string name = Console.ReadLine();
            Console.Write("Email       : ");
            string email = Console.ReadLine();
            Console.Write("Job Title   : ");
            string job_title = Console.ReadLine();
            Console.Write("Gender      : ");
            char gender = Convert.ToChar(Console.ReadLine());
            Console.Write("Birth Date  : ");
            DateTime birth_date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Password    : ");
            string password = Console.ReadLine();
            Console.Write("Role ID     : ");
            int role_id = Convert.ToInt16(Console.ReadLine());


            User user = new User();
            {
                user.id = id;
                user.name = name;
                user.email = email;
                user.job_title = job_title;
                user.gender = gender.ToString();
                user.birth_date = birth_date;
                user.password = password;
                user.role_id = role_id;
            };

            try
            {
                _context.Users.Add(user);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        public List<User> GetAll()
        {
            Console.Clear();

            var getall = _context.Users.ToList();
            foreach (User user in getall)
            {
                Console.WriteLine("Id         : " + user.id);
                Console.WriteLine("Nama       : " + user.name);
                Console.WriteLine("Email      : " + user.email);
                Console.WriteLine("Job Title  : " + user.job_title);
                string tanggal = user.birth_date.ToString();
                string temp_tanggal = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                Console.WriteLine("Birth Date : " + temp_tanggal);
                Console.WriteLine("Password   : " + user.password);
                Console.WriteLine("Role ID    : " + user.role_id);
                Console.WriteLine("");
            }
            return getall;
        }

        public User GetById(int find)
        {

            var user = _context.Users.Find(find);
            if (user == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (user.id == find)
            {
                Console.WriteLine("Id         : " + user.id);
                Console.WriteLine("Nama       : " + user.name);
                Console.WriteLine("Email      : " + user.email);
                Console.WriteLine("Job Title  : " + user.job_title);
                Console.WriteLine("Birth Date : " + user.birth_date);
                Console.WriteLine("Password   : " + user.password);
                Console.WriteLine("Role ID    : " + user.role_id);
            }
            return user;
        }

        public User SearchById(int find)
        {

            var user = _context.Users.Find(find);
            if (user == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return user;
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
                User user = SearchById(find);
                user.name = name_new;

                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return find;
        }


        public int Delete(int find)
        {
            User user = SearchById(find);
            _context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return find;

        }

    }
}
