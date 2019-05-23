using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using AutoMapper;
using CensusDataDigitalization.BAL;
using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.Presentation.Models;
using CensusDataDigitalization.BAL.Interfaces;

namespace CensusDataDigitalization.Presentation
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceProvider : OAuthAuthorizationServerProvider
    {

        private readonly IMapper mapper;
        private IUserBAL userBAL;

        public ServiceProvider(IUserBAL _userBAL)
        {
            this.userBAL = _userBAL;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDTO>();
            });
            mapper = config.CreateMapper();
        }

        /// <summary>
        /// Validates The User Upon login Request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Checks the User Details and generates Token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UserDTO authUser = userBAL.ValidateUserLoginBAL(context.UserName, context.Password);
            if (authUser != null)
            {
                UserViewModel currentUser = mapper.Map<UserViewModel>(authUser);

                identity.AddClaim(new Claim("Role", Convert.ToString(currentUser.IsApprover)));
                identity.AddClaim(new Claim("Status", Convert.ToString(currentUser.IsApproved)));
                identity.AddClaim(new Claim("Id", Convert.ToString(currentUser.UserID)));
                identity.AddClaim(new Claim("Email", Convert.ToString(currentUser.EmailID)));
                identity.AddClaim(new Claim("Password", Convert.ToString(currentUser.Password)));
                identity.AddClaim(new Claim("Fname", Convert.ToString(currentUser.FirstName)));
                identity.AddClaim(new Claim(ClaimTypes.Role, Convert.ToString(currentUser.IsApproved)));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {"val1", Convert.ToString(currentUser.UserID)},
                    {"val2", Convert.ToString(currentUser.IsApprover)},
                    {"val3", Convert.ToString(currentUser.IsApproved)}
                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is not matching, Please retry!");
            }
            return;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}

