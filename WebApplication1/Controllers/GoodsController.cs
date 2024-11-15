using BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models; // Створіть модель для товару, якщо вона ще не створена
using System.Collections.Generic;
using DAL.Service;
using DTO.Entity;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class GoodsController : Controller
    {
        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        // Отримання всіх товарів
        public IActionResult Index()
        {
            var goodsList = _goodsService.GetAll();
            return View(goodsList);
        }

        // Створення нового товару
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Goods goods)
        {
            if (ModelState.IsValid)
            {
                _goodsService.Create(goods);
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // Редагування товару
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var goods = _goodsService.GetById(id);
            if (goods == null)
            {
                return NotFound();
            }
            return View(goods);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Goods goods)
        {
            if (ModelState.IsValid)
            {
                _goodsService.Update(id, goods);
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // Видалення товару
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var goods = _goodsService.GetById(id);
            if (goods == null)
            {
                return NotFound();
            }

            _goodsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Детальна інформація про товар
        [Authorize(Roles = "User, Admin")]
        public IActionResult Details(int id)
        {
            var goods = _goodsService.GetById(id);
            if (goods == null)
            {
                return NotFound();
            }
            return View(goods);
        }
    }
}
