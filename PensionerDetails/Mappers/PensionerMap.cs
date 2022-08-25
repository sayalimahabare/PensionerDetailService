using CsvHelper.Configuration;
using PensionerDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetails.Mappers
{
    public sealed class PensionerMap : ClassMap<PenDetails>
    {
        public PensionerMap()
        {
            Map(x => x.Name).Name("Name");
            Map(x => x.DOB).Name("DOB");
            Map(x => x.PAN).Name("PAN");
            Map(x => x.SalaryEarned).Name("SalaryEarned");
            Map(x => x.Allowances).Name("Allowances");
            Map(x => x.SelfOrFamilyPension).Name("SelfOrFamilyPension");
            Map(x => x.BankName).Name("BankName");
            Map(x => x.AccountNumber).Name("AccountNumber");
            Map(x => x.PublicOrPrivate).Name("PublicOrPrivate");
            Map(x => x.AdharNumber).Name("AdharNumber");
        }
    }
}
