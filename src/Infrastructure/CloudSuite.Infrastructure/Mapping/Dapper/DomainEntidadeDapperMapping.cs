using CloudSuite.Modules.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Dapper
{
    public class DomainEntidadeDapperMapping : DommelEntityMap<DomainEntidade>
    {
        public DomainEntidadeDapperMapping()
        {
            ToTable("DomainEntidade"); // Nome da tabela no banco de dados
            Map(e => e.Id).ToColumn("Id").IsKey().IsIdentity(); // Mapeia a propriedade Id para a coluna Id
            Map(e => e.DNS).ToColumn("DNS"); // Mapeia a propriedade DNS para a coluna DNS
            Map(e => e.OwnerName).ToColumn("OwnerName"); // Mapeia a propriedade OwnerName para a coluna OwnerName
            Map(e => e.CreationDate).ToColumn("CreationDate"); // Mapeia a propriedade CreationDate para a coluna CreationDate
        }
    }
}
