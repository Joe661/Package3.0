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
    [Route("api/accounttypedetails")]
    [ApiController]
    public class AccountTypeDetailsController : ControllerBase
    {
        private readonly IAccountTypeDetailsBll _accountTypeDetails;
        private readonly IMapper _mapper;

        public AccountTypeDetailsController(IAccountTypeDetailsBll accountTypeDetails, IMapper mapper)
        {
            _accountTypeDetails = accountTypeDetails ?? throw new ArgumentNullException(nameof(accountTypeDetails));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name =nameof(GetAccountTypeDetails))]
        public async Task<ActionResult<List<AccountTypeDetails>>> GetAccountTypeDetails()
        {
            var list =await _accountTypeDetails.AccountTypeDetailsAsync();
            if (list == null)
                return NotFound();

            var result = _mapper.Map<List<AccountTypeDetailsDto>>(list);

            return Ok(result);
        }

        [HttpPost(Name =nameof(AddAccountTypeDetails))]
        public async Task<ActionResult> AddAccountTypeDetails(AccountTypeDetailsAddDto addDto)
        {
            if (addDto == null)
                return BadRequest();

            var result = _mapper.Map<AccountTypeDetails>(addDto);
             _accountTypeDetails.AddAccountTypeDetails(result);
            await _accountTypeDetails.SaveAsync();

            return NoContent();
        }
    }
}
