using APLICACION.Models;
using APLICACION.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APLICACION.Controllers
{
    public class TendenciasController : Controller
    {
        private readonly IServicioTMDB _servicioTmdb;

        public TendenciasController(IServicioTMDB servicioTmdb)
        {
            _servicioTmdb=servicioTmdb;
        }
        // GET: TendenciasController
        public async Task<ActionResult> Index()
        {
            EnTendencia resultado = new EnTendencia();
            try
            {
                resultado = await _servicioTmdb.todasTendencia(IServicioTMDB.VentanaTiempo.day);

                ViewBag.resultado = resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
            return View(resultado);
        }

        //// GET: TendenciasController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TendenciasController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TendenciasController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TendenciasController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TendenciasController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TendenciasController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TendenciasController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
