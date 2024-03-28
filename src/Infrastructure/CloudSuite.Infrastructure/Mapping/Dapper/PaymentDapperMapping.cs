using CloudSuite.Modules.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Dapper
{
    public class PaymentDapperMapping : DommelEntityMap<Payment>
    {
        public PaymentDapperMapping()
        {
            ToTable("Payment"); // Nome da tabela no banco de dados
            Map(h => h.Id).ToColumn("Id").IsKey().IsIdentity(); // Mapeia a propriedade Id para a coluna Id

            // Configurações para outros mapeamentos de propriedades...

            // Configuração de Objetos de Valor
            Map(p => p.Cnpj.CnpjNumber).ToColumn("CnpjNumber"); // Mapeia a propriedade CnpjNumber do objeto de valor Cnpj para a coluna CnpjNumber
            Map(p => p.Email.Address).ToColumn("EmailAddress"); // Mapeia a propriedade Address do objeto de valor Email para a coluna EmailAddress
        }
    }
}
