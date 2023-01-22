using DockerProject.Data;
using DockerProject.Models;
using DockerProject.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DockerProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly DataContext ctx;

        public PhoneController(DataContext _ctx)
        {
            ctx = _ctx;
        }

        [HttpGet("{company}")]
        public Company GetCompany(string com)
        {
            return ctx.Company.FirstOrDefault(x => x.Name == com);
        }

        [HttpPost]
        public Phone AddPhone(PhoneDto model)
        {
            var phone = new Phone
            {
                Price = model.Price,
                Title = model.Title,
                CompanyId = (GetCompany(model.Company)).Id,
            };  

            ctx.Phones.Add(phone);
            ctx.SaveChanges();
            return phone;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var phone = ctx.Phones.FirstOrDefault(x => x.Id == id);
            ctx.Remove(phone);
            await ctx.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(PhoneDto model)
        {
            var phone = ctx.Phones.FirstOrDefault(x => x.Id == model.Id);
            if (phone.Title != model.Title)
                phone.Title = model.Title;
            if (phone.Price != model.Price)
                phone.Price = model.Price;

            if (phone.Company.Name != model.Company)
                phone.Company = GetCompany(model.Company);
            ctx.SaveChanges();
        }

        [HttpGet]
        public List<PhoneDto> GetPhones()
        {
            var phoneList = ctx.Phones.ToList();
            var phoneListDto = new List<PhoneDto>();
            foreach (var phone in phoneList)
            {
                phoneListDto.Add(new PhoneDto
                {
                    Id = phone.Id,
                    Title = phone.Title,
                    Price = phone.Price,
                    Company = (ctx.Company.FirstOrDefault(x => x.Id == phone.CompanyId)).Name,
                });
            }
            return phoneListDto;
        }

        [HttpGet("{id}")]
        public PhoneDto GetPhone(int id)
        {
            var phone = ctx.Phones.FirstOrDefault(x => x.Id == id);
            var _phone = new PhoneDto
                {
                    Id = phone.Id,
                    Title = phone.Title,
                    Price = phone.Price,
                    Company = (ctx.Company.FirstOrDefault(x => x.Id == phone.CompanyId)).Name,
                };

            return _phone;
        }
        
    }
}
