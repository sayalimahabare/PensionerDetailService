using PensionerDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetail.Repository.IRepository
{
   public interface IPensionerDetails
    {
        //public string ReadCSV(string location);
        public List<PenDetails> ReadCSV(string location);
        
    }
}
