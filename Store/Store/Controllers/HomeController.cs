﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Store.Controllers
{
    using Managers;
    using Filters;

    /// <summary>
    /// Home Controller
    /// </summary>
    [Authorize]
    [Culture]
    public class HomeController : Controller
    {
        ProductManager productManager = new ProductManager();

        /// <summary>
        /// the method views index page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// the method view about page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult About()
        {
            return View("About");
        }

        [AllowAnonymous]
        public ActionResult _LoginPartial()
        {

            return PartialView("~/Views/Shared/_LoginPartial.cshtml");
        }

        [AllowAnonymous]
        public ActionResult OurEvents()
        {
            return View("OurEvents");
        }

        /// <summary>
        /// the method views contact page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View("Contact");
        }

        /// <summary>
        /// the method view detail product 
        /// </summary>
        /// <param name="data">product data</param>
        /// <returns>partial page</returns>
        public PartialViewResult DetailProduct(Models.Product data)
        {
            return PartialView("~/Views/Shared/Partials/DetailProduct.cshtml", data);
        }

        /// <summary>
        /// the method view productview page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ProductView()
        {
            return View();
        }

        /// <summary>
        /// the method returns support page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Support()
        {
            return View();
        }

        /// <summary>
        /// the method creates a new product for sale
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UserSale()
        {
            Models.BaseEntity entities = await productManager.GetProductProperty();
            ViewBag.Manufacturer = new SelectList(entities.ManufacturerList, "Id", "Name");
            ViewBag.Camera = new SelectList(entities.CameraList, "Id", "ResolutionMatrix", "MaxResolution");
            ViewBag.HardDisk = new SelectList(entities.HardDiskList, "Id", "HDD");
            ViewBag.Processor = new SelectList(entities.ProcessorList, "Id", "Type");
            ViewBag.OperSystem = new SelectList(entities.OperSystemList, "Id", "Name");
            ViewBag.VideoCard = new SelectList(entities.VideoCardList, "Id", "Memory");
            ViewBag.Power = new SelectList(entities.PowerList, "Id", "BatteryWork");
            ViewBag.Display = new SelectList(entities.DisplayList, "Id", "ScreenResolution");
            return View();
        }

        /// <summary>
        /// the method returns all products in admin products page
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AdminProducts()
        {
            IEnumerable<Models.Product> result = await productManager.GetAllProducts();
            return View(result);
        }

        /// <summary>
        /// the method removes product from database
        /// </summary>
        /// <param name="product">product removal</param>
        /// <returns>true or false</returns>
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<bool> DeleteProduct(Models.Product product)
        {
            bool result = await productManager.DeleteProduct(product);
            return result;
        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["MyFile"];
            bool isUploaded = false;
            string message = "File upload failed";

            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/Content/img");
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(pathForSaving, myFile.FileName));
                        isUploaded = true;
                        message = "File uploaded successfully!";
                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message);
                    }
                }
            }
            return Json(new { isUploaded = isUploaded, message = message }, "text/html");
        }

        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }

        [AllowAnonymous]
        public bool ChangeCulture(string lang)
        {
            try
            {
                // Список культур
                List<string> cultures = new List<string>() { "ru", "en", "kk-KZ" };
                if (!cultures.Contains(lang))
                {
                    lang = "ru";
                }
                // Сохраняем выбранную культуру в куки
                HttpCookie cookie = Request.Cookies["lang"];
                if (cookie != null)
                    cookie.Value = lang;   // если куки уже установлено, то обновляем значение
                else
                {
                    cookie = new HttpCookie("lang");
                    cookie.HttpOnly = false;
                    cookie.Value = lang;
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
                Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}