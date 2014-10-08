using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBlogApplication.Models
{
    public class Registration
    {  
        [Required]
        public string Username {get;set;}
        [Required, DataType(DataType.Password)]
        public string Password {get;set;}
        [Required, DataType(DataType.Password), Display(Name="Confirm Password"), Compare("Password")]
        public string PasswordConfirm{get;set;}
        [Required]
        public string Name {get;set;}
        [Required, Display(Name="Avatar")]
        public string ImageURL {get;set;}
    }
}