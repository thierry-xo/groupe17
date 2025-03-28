using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Abstract
{
    abstract class Person
    {
        protected String name, lname;
        public Person(String name,String lname)
        {
            this.name = name;
            this.lname = lname;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public String Lname
        {
            get
            {
                return this.lname;
            }
            set
            {
                this.lname = value;
            }
        }

        public abstract void show(int id,int choix);
        public abstract void Add(int choix);
    }
}
