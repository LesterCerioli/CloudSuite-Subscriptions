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
        public Customer(Name name, Cnpj cnpj, Email email, string? businessOwner, DateTimeOffset? createdOn, Company company)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
            BusinessOwner = businessOwner;
            CreatedOn = DateTime.Now;
            Company = company;
        }

        public Name Name { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Email Email { get; private set; }

        public string? BusinessOwner { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public Company Company { get; private set; }
        
    }
}