using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopCine.Application.Features.Authenticates;
using TopCine.Application.Features.Authenticates.Commands;
using TopCine.WebApi.ModelViews;

namespace TopCine.WebApi.Controllers.Authenticates
{
    [Route("api/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IValidator<AuthenticateCommand> _validator;
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        public AuthenticateController(IAuthenticateService authenticateService, 
                                      IMapper mapper, 
                                      IValidator<AuthenticateCommand> validator)
        {
            _validator = validator;
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AuthenticateCommand commandParam)
        {
            ValidationResult results = _validator.Validate(commandParam);

            if (!results.IsValid)
                return BadRequest(results.Errors);

            var user = _authenticateService.Authenticate(commandParam.Email, commandParam.Password);

            if (user == null)
                return BadRequest(new { message = "O email do usuário ou a senha esta incorreta!" });

            var model = _mapper.Map<UserAuthenticateModelView>(user);

            return Ok(model);
        }
    }
}