using BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DTO.Entity;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class GoodsController : Controller
    {
        private readonly IGoodsService _goodsService;
        private readonly IManagersService _managersService;

        public GoodsController(IGoodsService goodsService, IManagersService managersService)
        {
            _goodsService = goodsService;
            _managersService = managersService;
        }

        public IActionResult Index()
        {
            var goodsList = _goodsService.GetAll();
            return View(goodsList);
        }

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
            if (goods.manager_id <= 0)
            {
                ModelState.AddModelError("manager_id", "Manager ID must be a positive number.");
                ViewData["ManagerError"] = "Manager ID must be a positive number.";
                return View(goods);
            }

             if (_managersService.GetById(goods.manager_id) == null)
            {
                ModelState.AddModelError("manager_id", "Invalid Manager ID.");
                ViewData["ManagerError"] = "Invalid Manager ID.";
                return View(goods);
            }

            if (ModelState.IsValid)
            {
                _goodsService.Create(goods);
                return RedirectToAction(nameof(Index));
            }

            return View(goods);
        }


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
