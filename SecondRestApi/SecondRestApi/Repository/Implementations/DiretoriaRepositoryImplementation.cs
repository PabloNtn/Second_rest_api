using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondRestApi.Repository.Implementations
{
    public class DiretoriaRepositoryImplementation
    {
        public static DirectorShip Get(string username, string password)
        {
            var users = new List<DirectorShip>();
            users.Add(new DirectorShip { Dir_id = 1, Dir_userName = "batman", Dir_pwd = "batman", Dir_role = "manager" });
            users.Add(new DirectorShip { Dir_id = 2, Dir_userName = "robin", Dir_pwd = "robin", Dir_role = "employee" });
            return users.Where(x => x.Dir_userName.ToLower() == username.ToLower() && x.Dir_pwd == x.Dir_pwd).FirstOrDefault();
        }

    }
}
