using Contacts.Model;
using System;

namespace Contacts.Service.util
{
    public class UpdatingPersonArgument
    {
        public int? id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string middleName { get; set; }

        public Sex sex { get; set; }

        public string phoneNumber { get; set; }

        public DateTime birthday { get; set; }

        public string Email { get; set; }

        public string VKLink { get; set; }

        public string discord { get; set; }

        public string address { get; set; }

        public string placeOfStudy { get; set; }

        public string workplace { get; set; }
    }
}
