using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_service.Date
{
    public class Person
    {
        /*Принимает объект с полями ИИН, Фамилия, Имя, Отчество, дата рождения*/
        public virtual int Id { get; set; }
        public virtual string IIN { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Name { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
    }

    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x=>x.IIN);
            Map(x=>x.Surname);
            Map(x=>x.Name);
            Map(x=>x.MiddleName);
            Map(x=>x.DateOfBirth);
            Table("Person");

        }
    }


}
