﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using static IdentityServer4.IdentityServerConstants;

namespace OryxBudgetWeb
{
  using IdentityServer4;
  using Microsoft.AspNetCore.Identity;
  using Models;

  public class AspIdProfileService : IProfileService
  {
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
    private readonly UserManager<ApplicationUser> _userManager;

    public AspIdProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
    {
      _userManager = userManager;
      _claimsFactory = claimsFactory;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
      var sub = context.Subject.FindFirst("sub")?.Value;
      if (sub != null)
      {
        var user = await _userManager.FindByIdAsync(sub);
        var cp = await _claimsFactory.CreateAsync(user);

        var claims = cp.Claims.ToList();

        claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

        //claims.Add(new Claim(JwtClaimTypes., $"{ user.LastName}, {user.FirstName}"));
        claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
        claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));


        //claims.Add(new System.Security.Claims.Claim(StandardScopes.Email, user.Email));
        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Name, $"{ user.LastName}, {user.FirstName}"));
        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Role, user.MemberRole));
        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Role, user.Role));
        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Id, user.OperatorId));


        context.IssuedClaims = claims;
      }
    }


    public async Task IsActiveAsync(IsActiveContext context)
    {
      var sub = context.Subject.GetSubjectId();
      var user = await _userManager.FindByIdAsync(sub);
      context.IsActive = user != null;
    }
  }
}
