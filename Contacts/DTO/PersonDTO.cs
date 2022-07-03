﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.DTO
{
    public class PersonDTO
    {
        public int? id { get; set; }
        
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string middleName { get; set; }

        public string sex { get; set; }

        public string phoneNumber { get; set; }

        public DateTime birthday { get; set; }

        public string email { get; set; }

        public string VKLink { get; set; }

        public string discord { get; set; }

        public string address { get; set; }

        public string placeOfStudy { get; set; }

        public string workplace { get; set; }

        public static bool isValid(PersonDTO dto)
        {
            if (string.IsNullOrEmpty(dto.firstName))
                return false;
            if (string.IsNullOrEmpty(dto.lastName))
                return false;
            if (string.IsNullOrEmpty(dto.middleName))
                return false;
            if (string.IsNullOrEmpty(dto.sex))
                return false;
            if (string.IsNullOrEmpty(dto.phoneNumber))
                return false;
            if (string.IsNullOrEmpty(dto.email))
                return false;
            if (string.IsNullOrEmpty(dto.VKLink))
                return false;
            if (string.IsNullOrEmpty(dto.discord))
                return false;
            if (string.IsNullOrEmpty(dto.address))
                return false;
            if (string.IsNullOrEmpty(dto.placeOfStudy))
                return false;
            if (string.IsNullOrEmpty(dto.workplace))
                return false;
            return true;
        }
    }
}
