using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seans_New_Git_Project
{
    public class Student
    {
        
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname {get;set;}
        public string EmailAddress { get; set; }

                
    }




    public class test
    {

        public test()
        {
            var mystudent = new Student();

            mystudent.Id = 1;

        }


    }
}
