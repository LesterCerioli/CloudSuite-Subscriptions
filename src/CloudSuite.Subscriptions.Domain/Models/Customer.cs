using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CloudSuite.Commons.ValueObjects;

namespace CloudSuite.Subscriptions.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Contact(Name name, Email email, string? bodyMessage, Telephone telephone)
        {
            Name = name;
            Email = email;
            BodyMessage = bodyMessage;
            Telephone = telephone;
        }

        public Contact()
        {
        }

        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public string? BodyMessage { get; private set; }

        public Telephone Telephone { get; private set; }
        
    }
}