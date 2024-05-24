﻿using System.ComponentModel.DataAnnotations;

namespace DorangApp.ViewModels.Account
{
    public class RegisterVM
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string Surname { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}