using DockerProject.Data;
using DockerProject.Models;
using DockerProject.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DockerProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext ctx;

        public CompanyController(DataContext _ctx)
        {
            ctx = _ctx;
        }


        [HttpPost]
        public Company AddCompany(CompanyDto model)
        {
            var com = new Company
            {
                Name = model.Name,
            };  

            ctx.Company.Add(com);
            ctx.SaveChanges();
            return com;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var com = ctx.Company.FirstOrDefault(x => x.Id == id);
            ctx.Remove(com);
            await ctx.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(CompanyDto model)
        {
            var com = ctx.Company.FirstOrDefault(x => x.Id == model.Id);
            if (com.Name != model.Name)
                com.Name = model.Name;

            ctx.SaveChanges();
        }

        [HttpGet]
        public List<CompanyDto> GetCompanies()
        {
            var comList = ctx.Company.ToList();
            var comListDto = new List<CompanyDto>();
            foreach (var com in comList)
            {
                comListDto.Add(new CompanyDto
                {
                    Id = com.Id,
                    Name = com.Name,
                });
            }
            return comListDto;
        }

        [HttpGet("{id}")]
        public CompanyDto GetCompanyDto(int id)
        {
            var com = ctx.Company.FirstOrDefault(x => x.Id == id);
            var _com = new CompanyDto
                {
                    Id = com.Id,
                    Name = com.Name,
                };

            return _com;
        }
        
    }
}
