using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Linq;

namespace OryxSecurity.Services
{
    public class UserResolverService: IUserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser()
        {
            // Debug.Write(_context.HttpContext.User);
            return "eb5d17b2-e4e8-470f-8436-ae5a10dd8eba";
            // return _context.HttpContext.User?.Claims.Where(c => c.Type == "sub").FirstOrDefault().Value;
        }
    }

    public interface IUserResolverService
    {
        string GetUser();
    }
}
