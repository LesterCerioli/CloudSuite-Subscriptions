using CloudSuite.Modules.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Dapper
{
    public class CustomerDapperMapping : DommelEntityMap<Customer>
    {
        public CustomerDapperMapping()
        {
            ToTable("Customer"); // Nome da tabela no banco de dados
            Map(b => b.Id).ToColumn("Id").IsKey().IsIdentity(); // Mapeia a propriedade Id para a coluna Id
            Map(b => b.Name.FirstName).ToColumn("FirstName"); // Mapeia o primeiro nome para a coluna FirstName
            Map(b => b.Name.LastName).ToColumn("LastName"); // Mapeia o sobrenome para a coluna LastName
            Map(b => b.Cnpj.CnpjNumber).ToColumn("CnpjNumber"); // Mapeia o número do CNPJ para a coluna CnpjNumber
            Map(b => b.Email.Address).ToColumn("EmailAddress"); // Mapeia o endereço de e-mail para a coluna EmailAddress
            Map(b => b.BusinessOwner).ToColumn("BusinessOwner"); // Mapeia o proprietário do negócio para a coluna BusinessOwner
            Map(b => b.CreatedOn).ToColumn("CreatedOn"); // Mapeia a data de criação para a coluna CreatedOn

        }

        
    }
}
