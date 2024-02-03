using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mapping.EFCore
{
    public class DomainEFCoreMapping : IEntityTypeConfiguration<DomainEntidade>
    {
        public void Configure(EntityTypeBuilder<DomainEntidade> builder)
        {
            throw new NotImplementedException();
        }
    }
}
