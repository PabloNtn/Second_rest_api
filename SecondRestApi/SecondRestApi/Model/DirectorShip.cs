using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondRestApi.Model
{
    public class DirectorShip
    {
        private int dir_id;
        private string dir_name;

        public DirectorShip(int dir_id, string dir_name)
        {
            this.Dir_id = dir_id;
            this.Dir_name = dir_name;
        }

        public int Dir_id { get => dir_id; set => dir_id = value; }
        public string Dir_name { get => dir_name; set => dir_name = value; }
    }
}
