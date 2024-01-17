using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Projeto_Bolg.Models
{
	public class User
	{
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid().ToString();
            Username = username; 
            PasswordHash = new PasswordHasher<User>().HashPassword(this, password);
        }
    }
}