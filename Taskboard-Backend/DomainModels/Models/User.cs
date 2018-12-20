using DomainModels.Interfaces;
using System;
using System.Collections.Generic;

namespace DomainModels.Models
{
    public class User: IDatabaseItem
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<UserBoard> UserBoards { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<ContactRequest> ContactRequests { get; set; }
    }
}