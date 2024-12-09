using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;
using PhoneStore.ViewModels;
using System.Diagnostics;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        List<Phone> phones;
        List<Company> companies;
        public HomeController()
        {
            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company samsung = new Company { Id = 2, Name = "Samsung", Country = "Республика Корея" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };
            companies = new List<Company> { apple, samsung, google };  
            
            phones = new List<Phone>
            {
                new Phone { Id=1, Manufacturer= apple, Name="iPhone X", Price=56000 },
                new Phone { Id=2, Manufacturer= apple, Name="iPhone XZ", Price=41000 },
                new Phone { Id=3, Manufacturer= samsung, Name="Galaxy 9", Price=9000 },
                new Phone { Id=4, Manufacturer= samsung, Name="Galaxy 10", Price=40000 },
                new Phone { Id=5, Manufacturer= google, Name="Pixel 2", Price=30000 },
                new Phone { Id=6, Manufacturer= google, Name="Pixel XL", Price=50000 }
            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel() {Id=c.Id, Name=c.Name })
                .ToList();
            compModels.Insert(0, new CompanyModel() { Id = 0, Name = "All" });
            IndexViewModel indexViewModel = new IndexViewModel() { Companies = compModels, Phones = phones };
            if(companyId != null && companyId > 0)
                indexViewModel.Phones = phones.Where(p => p.Manufacturer.Id == companyId);
            return View(indexViewModel);
        }
    }
}