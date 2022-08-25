using CsvHelper;
using PensionerDetail.Models;
using PensionerDetail.Repository.IRepository;
using PensionerDetails.Mappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionerDetail.Repository
{
    public class PensionerDet : IPensionerDetails
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerDet));

        public List<PenDetails> ReadCSV(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<PensionerMap>();
                    var records = csv.GetRecords<PenDetails>().ToList();

                    _log4net.Info("data return successfully from authentication method of: " + nameof(PensionerDet));
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

      
    }
}
