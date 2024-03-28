using CloudSuite.Modules.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Dapper
{
    public class CompanyDapperMapping :  DommelEntityMap<Company>
    {
        public CompanyDapperMapping()
        {
            ToTable("Company"); // Table name in the database
            Map(a => a.Id).ToColumn("Id").IsKey().IsIdentity(); // Maps the Id property to the Id column
            Map(a => a.SocialName).ToColumn("SocialName"); // Maps the SocialName property to the SocialName column
            Map(a => a.FantasyName).ToColumn("FantasyName"); // Maps the FantasyName property to the FantasyName column
            Map(a => a.FundationDate).ToColumn("FundationDate"); // Maps the FundationDate property to the FundationDate column
        }
    }
}
