using CloudSuite.Modules.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Dapper
{
    public class SubscriptionDapperMapping : DommelEntityMap<Subscription>
    {
        public SubscriptionDapperMapping()
        {
            ToTable("Subscription"); // Nome da tabela no banco de dados
            Map(s => s.Id).ToColumn("Id").IsKey().IsIdentity(); // Mapeia a propriedade Id para a coluna Id
            Map(s => s.SubscriptionNumber).ToColumn("SubscriptionNumber"); // Mapeia a propriedade SubscriptionNumber para a coluna SubscriptionNumber
            
        }
    }
}
