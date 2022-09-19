﻿using Constants;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Birthday { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public DateTime CreationDate { get; set; }
        public string Role { get; set; } = ConstantsRepository.SimpleUser;

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
