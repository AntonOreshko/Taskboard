using System;
using Common.DomainModels.Interfaces;

namespace Auth.DomainModels.Models
{
    public class User: IPersistentEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
