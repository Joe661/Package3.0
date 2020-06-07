using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Model;
using PackageAccountant3._0.Service;

namespace PackageAccountant3._0.Controllers
{
    [Route("api/accountitermdetails")]
    [ApiController]
    public class AccountItermDetailsController : ControllerBase
    {
        private readonly IAccountItermDetailsBll _accountItermDetails;
        private readonly IMapper _mapper;

        public AccountItermDetailsController(IAccountItermDetailsBll accountItermDetails,IMapper mapper)
        {
            _accountItermDetails = accountItermDetails ?? throw new ArgumentNullException(nameof(accountItermDetails));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name =nameof(GetAccountItermDetailsList))]
        public async Task<ActionResult<List<AccountItermDetailsDto>>> GetAccountItermDetailsList()
        {
            var list =await _accountItermDetails.GetAccountItermDetailsAsyn();
            if (list ==null)
                return NotFound();
            return Ok(_mapper.Map<List<AccountItermDetailsDto>>(list));
        }

        [HttpPost(Name =nameof(AddAccountItermDetails))]
        public async Task<ActionResult> AddAccountItermDetails([FromBody]AccountItermDetailsAddDto addDto)
        {
            if (addDto == null)
                return BadRequest();

            _accountItermDetails.AddAccountItermDetails(_mapper.Map<AccountItermDetails>(addDto));
            await _accountItermDetails.SaveAsync();

            return NoContent();
        }
    }
}
