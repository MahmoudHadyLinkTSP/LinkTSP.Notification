using LinkTSP.Notification.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LinkTSP.Notification.Web.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ApplicationDbContext _context;

        private UnitOfWork _unitOfWork=null;
        protected UnitOfWork UnitOfWork => _unitOfWork ?? new UnitOfWork(_context);



        private readonly IConfiguration _configuration;
        protected IConfiguration Configuration => _configuration;


        public BaseController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _context = dbContext;
        }

        public BaseController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }
    }
}
