using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationWork
{
    public class Common
    {
        static public bool isAdmin(object user)
        {
            Type utype = user.GetType();
            object[] attributes = utype.GetCustomAttributes(false);
            foreach (var item in attributes)
            {
                if (item is AccessLevelAttribute)
                    return (item as AccessLevelAttribute).level > 1;
            }
            return false;
        }
        static public bool checkCredentials(User user, string password)
        {
            return user != null && (user.Password == null ? "" : user.Password).Equals(password.Trim());
        }
    }
}
