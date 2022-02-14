using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Helpers;

namespace TaskForToss.Models
{
    public  class ChiefModel: BaseModel
    {
        public ChiefModel()
        {
            if (Day != 0 && Month != 0 && Year != 0 )
            {
                EffectiveDate = new DateTime(Day, Month, Year);
            }
            else
            {
                EffectiveDate = new DateTime();
            }
        }
        public ObjectId Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public bool IsValid()
        {
            if (!ErrorFilter.EmailValidationTest(Email))
            {
                return false;
            }
            if (!ErrorFilter.PhoneValidationTest(Phone))
            {
                return false;
            }
            if (Name == null)
            {
                ErrorFilter.InValidSpace("Ad");
                return false;
            }
            if (Name.Length > 30)
            {
                ErrorFilter.InValidLength("Ad", 30);
                return false;
            }
            if (Email.Length > 30)
            {
                ErrorFilter.InValidLength("Email", 30);
                return false;
            }
            if (Day == 0 || Month == 0 || Year == 0)
            {
                ErrorFilter.EmptyEffectiveDate();
                return false;
            }
           
            return true;
        }
    }
}
