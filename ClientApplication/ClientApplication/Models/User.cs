using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApplication
{
    public class User
    {
        /*Принимает объект с полями ИИН, Фамилия, Имя, Отчество, дата рождения*/
        public int Id { get; set; }
        public string IIN { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
