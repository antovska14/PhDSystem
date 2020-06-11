﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PhDSystem.Core.Models
{
    public class UserInfo
    {
        [Key]
        public Guid UserInfoId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}