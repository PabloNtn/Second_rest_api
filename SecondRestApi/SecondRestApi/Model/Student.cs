using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondRestApi.Model
{
    public class Student
    {
        private string alu_nm;
        private string alu_nr_tel;
        private string alu_dt_nascimento;        
        public Student(string Alu_nm, string Alu_nr_tele, string Alu_dt_nascimento)
        {
            this.FirstName = Alu_nm;
            this.LastName = Alu_nr_tele;
            this.Adress = Alu_dt_nascimento;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
    }
}
