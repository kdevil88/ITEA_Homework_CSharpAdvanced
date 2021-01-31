using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class AccessLevelAttribute : Attribute
    {
        public int level;
        public AccessLevelAttribute(int level)
        {
            this.level = level;
        }
    }
    class User
    {

    }
    [AccessLevel(1)]
    class Manager : User
    {

    }
    [AccessLevel(2)]
    class Programmer : User
    {

    }
    [AccessLevel(3)]
    class Director : User
    {

    }
    class SecuredBase
    {
        public bool Access(User user)
        {
            bool result = false;
            Type utype = user.GetType();
            object[] attributes = utype.GetCustomAttributes(false);
            foreach (var item in attributes)
            {
                if (item is AccessLevelAttribute)
                    result = (item as AccessLevelAttribute).level > 2;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SecuredBase @base = new SecuredBase();
            Console.WriteLine("Manager has access to secured base: {0}", @base.Access(new Manager()));
            Console.WriteLine("Programmer has access to secured base: {0}", @base.Access(new Programmer()));
            Console.WriteLine("Director has access to secured base: {0}", @base.Access(new Director()));
            Console.ReadKey();
        }
    }
}
