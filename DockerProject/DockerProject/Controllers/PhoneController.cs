using DockerProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace DockerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly DataContext ctx;

        public PhoneController(DataContext ctx)
        {
            this.ctx = ctx;
        }

    }
}
