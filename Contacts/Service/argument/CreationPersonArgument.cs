using Contacts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Service.util
{
    public class CreationPersonArgument
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string middleName { get; set; }

        public Sex sex { get; set; }

        public string phoneNumber { get; set; }

        public DateTime birthday { get; set; }

        [Required]
        public string email { get; set; }

        public string VKLink { get; set; }

        public string discord { get; set; }

        public string address { get; set; }

        public string placeOfStudy { get; set; }

        public string workplace { get; set; }
    }
}
