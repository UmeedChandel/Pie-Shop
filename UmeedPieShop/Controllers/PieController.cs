﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        string baseAddress;
        public PieController(IPieRepository pieRepository, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
        }

        private IEnumerable<Pie> GetAllPies()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Pie/AllPiesList");
            return pies.Result;
        }

        public IActionResult List(int id)
        {
            IEnumerable<Pie> pies;
            CustomeClass customeClass = new CustomeClass();
            if (id > 0)
            {
                pies = GetAllPies().Where(pie => pie.CategoryId == id);
                customeClass.CurrentCategory = "Category";
                customeClass.CategoryDescription = "";
            }
            else
            {
                pies = GetAllPies();
                customeClass.CurrentCategory = "List Of Pies";
                customeClass.CategoryDescription = "";
            }

            customeClass.Pies = pies;
            return View(customeClass);
        }

        [Authorize]
        public IActionResult ListMini()
        {
            var pies = GetAllPies();
            var piesmini = _mapper.Map<IEnumerable<PieMini>>(pies);
            return View(piesmini);
        }

        public IActionResult PieOfWeek()
        {
            var piesOfWeek = StaticApiData.GetApiPieData(baseAddress + "Pie/PieOfWeek");
            return View(piesOfWeek.Result);
        }

        
        public IActionResult Details(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }


        // CRUD Operations

        [Authorize]
        public ViewResult EditPie(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        public async Task<IActionResult> Update(Pie pie) //PutAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(baseAddress + "Crud/Update", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult CreatePie()
        {
            return View();
        }

        public async Task<IActionResult> Insert(Pie pie) //PostAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(baseAddress + "Crud/Insert", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult DeletePie(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        public async Task<IActionResult> Delete(int PieId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(baseAddress + "Crud/Delete?PieId=" + PieId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("List");
        }
    }
}
