using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using UI.Models;
using DAL.Repositories;
using DAL.Entities;
using DAL;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = unitOfWork.UserRepository.GetUserByUsername(model.Username);
                if(user.AdminRole)
                {
                    return View("AdminPage");
                }

                return View("UserPage");
            }

            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Product exsits = unitOfWork.ProductRepository.GetElementByName(product.Name);

            if(exsits == null)
            {
                unitOfWork.ProductRepository.Add(product);
            }
            else
            {
                exsits.Count += product.Count;
                unitOfWork.ProductRepository.Update(exsits);
            }
            return View("AdminPage");
        }

        
        public IActionResult AdminWarehouse()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItems();
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };

            return View(productsModel);
        }

        public ActionResult SearchProducts(string search = "")
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemsStartedWith(search);
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };


            ViewBag.Search = search;

            return PartialView("_Products", productsModel);
        }

        public IActionResult UserPage()
        {
            return View();
        }

        public IActionResult UserWarehouse()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItems();
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };
            return View(productsModel);
        }

        [HttpPost]
        public IActionResult UserWarehouse(ProductsViewModel ProdModel,string name)
        {
            string sqlCommand = "Update Products " +
                        $"Set Count = Count + {ProdModel.Count} " +
                        $"Where Name = '{name}'";

            unitOfWork.ProductRepository.Update(sqlCommand);

            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItems();
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };

            return View(productsModel);
        }

        public IActionResult Store()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItems();
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };
            return View(productsModel);
        }

        [HttpPost]
        public IActionResult Store(ProductsViewModel ProdModel, string name)
        {
            string sqlCommand = "Update Products " +
                        $"Set Count = Count - {ProdModel.Count} " +
                        $"Where Name = '{name}'";

            unitOfWork.ProductRepository.Update(sqlCommand);

            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItems();
            ProductsViewModel productsModel = new ProductsViewModel { Products = products };

            return View(productsModel);
        }

    }
}