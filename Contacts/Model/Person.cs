using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Model
{
    public class Person
    {
        public int? id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string middleName { get; set; }

        public Sex sex { get; set; }

        public string phoneNumber { get; set; }

        public DateTime birthday { get; set; }

        public string Email { get; set; }

        public string vkLink { get; set; }

        public string discord { get; set; }

        public string address { get; set; }

        public string placeOfStudy { get; set; }

        public string workplace { get; set; }
    }
}
