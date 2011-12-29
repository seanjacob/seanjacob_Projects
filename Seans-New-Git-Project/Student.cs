using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seans_New_Git_Project
{
    public class Student
    {
        
        
        public int Id { get; set; }
        public virtual string FirstName { get; set; }
        public string Surname {get;set;}
        public string EmailAddress { get; set; }
        public string Telephone { get; set; } 
        public string Address {get;set;}

        public bool IsMature { get; set; } 
    }



    public class MatureStudent : Student
    {

        public override string FirstName
        {
            get
            {
                var firstTmp = "SIR " +  base.FirstName;

                return firstTmp;
            }
            set
            {
                base.FirstName = value;
            }
        }



    }

    public class BabyStudent : Student
    {


    }



    public class test
    {


        public test()
        {

            var test = new MatureStudent();


             

        }

    }

}
