﻿using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Category1()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 1);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 1);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }
        public ViewResult Category2()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 2);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 2);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }
        public ViewResult Category3()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 3);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 3);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }
    }
}