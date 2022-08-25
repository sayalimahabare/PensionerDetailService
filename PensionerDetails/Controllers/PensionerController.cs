using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PensionerDetail.Models;
using PensionerDetail.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetails.Controllers
{

    [Route("api/pensioner")]
    [ApiController]
    [Authorize]
    public class pensionerController : ControllerBase
    {
        private readonly IPensionerDetails _penDet;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(pensionerController));

        public pensionerController(IPensionerDetails penDet)
        {
            _penDet = penDet;
        }


        [HttpGet("GetDetails")]
        public  IActionResult GetDetailsAsync()
        {
            try
            {
                _log4net.Info(" Http GET Request From GetDetails method of: " + nameof(pensionerController));
                var path = @"pension.csv";

                //  var resultData = _penDet.ReadCSV(path);
                List<PenDetails> detaillist = _penDet.ReadCSV(path);
                _log4net.Info("List of pensioners return From GetDetails method of: " + nameof(pensionerController));
                return Ok(detaillist);


            }
            catch (Exception ex)
            {
                _log4net.Error(" bad Request returned From GetDetails method of: " + nameof(pensionerController));
                return StatusCode(400, "Bad Request");
            }
        }

        [HttpGet("[action]/{adharNumber}")]
        public IActionResult GetDetailsByAdhar(string adharNumber)
        {
            try
            {
                _log4net.Info(" Http GET Request From GetDetailsByAdhar method of: " + nameof(pensionerController));
                var path = @"pension.csv";

                //  var resultData = _penDet.ReadCSV(path); 
              var detaillist = _penDet.ReadCSV(path);
                var pensionData = detaillist.Where(item => item.AdharNumber == adharNumber).Select(item => item);

                if (pensionData.Any() && detaillist.Any())
                {
                    _log4net.Info("details of pensioners based on Aadhar number return From GetDetailsByAdhar method of: " + nameof(pensionerController));
                    return Ok(pensionData);
                }

                _log4net.Error(" bad Request returned From GetDetailsByAdhar method of: " + nameof(pensionerController));
                return BadRequest(new { message = "Aadhar number is invalid" });


            }
            catch (Exception ex)
            {
                return StatusCode(400, "Bad Request");
            }
        }

    }
    }
