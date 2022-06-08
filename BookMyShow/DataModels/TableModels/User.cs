﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

    }
}
