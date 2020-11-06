using AutoMapper;
using AccountLibrary.API.Models;
using AccountLibrary.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountLibrary.API.Controllers
{
    [ApiController]
  
    public class AccountController : ControllerBase
    {
        private readonly IAccountLibraryRepository _AccountLibraryRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountLibraryRepository AccountLibraryRepository,
            IMapper mapper)
        {
            _AccountLibraryRepository = AccountLibraryRepository ??
                throw new ArgumentNullException(nameof(AccountLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [Route("api/v1/accounts")]
        [HttpGet]
        public ActionResult<AccountDto> GetAccounts()
        {
            string customerid = string.Empty;
            //(HttpContext.Request.Headers["x-api-customerId"].)
            if (Request.Headers.ContainsKey("x-api-customerId"))
                customerid = Request.Headers["x-api-customerId"].ToString();
            else
                return BadRequest();

            var accpuntsFromRepo = _AccountLibraryRepository.GetAccounts(customerid);

            if (accpuntsFromRepo == null || accpuntsFromRepo.Count()==0)
            {
                return NotFound();
            }

            return Ok((_mapper.Map<IEnumerable<Entities.Account>, IEnumerable<AccountDto>>(accpuntsFromRepo)));
        }

        [Route("accountService/api/v1/accounts")]
        [HttpGet]
        public ActionResult<AccountDto> GetAccounts1()
        {
            string customerid = string.Empty;
            //(HttpContext.Request.Headers["x-api-customerId"].)
            if (Request.Headers.ContainsKey("x-api-customerId"))
                customerid = Request.Headers["x-api-customerId"].ToString();
            else
                return BadRequest();

            var accpuntsFromRepo = _AccountLibraryRepository.GetAccounts(customerid);

            if (accpuntsFromRepo == null || accpuntsFromRepo.Count() == 0)
            {
                return NotFound();
            }

            return Ok((_mapper.Map<IEnumerable<Entities.Account>, IEnumerable<AccountDto>>(accpuntsFromRepo)));
        }

        [Route("health")]
        [HttpGet]
        public ActionResult Test()
        {
            return Ok();
        }




        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}