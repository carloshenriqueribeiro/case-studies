using Business;
using Model;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteBusiness _business;

        public ClientesController()
        {
            _business = new ClienteBusiness();
        }


        public ActionResult Index()
        {
            return View(_business.GetAll());
        }

        public ActionResult Create()
        {
           

            return View();
        }


        [HttpPost]
        public ActionResult Create(ClienteModel model)
        {
            ModelState.Remove(" ClienteId");

            //if (!ModelState.IsValid)
            //{

            //    return View(model);
            //}

            _business.Save(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var Clientes = _business.GetById(id);

            return View(Clientes);
        }

        [HttpPost]
        public ActionResult Edit(ClienteModel Clientes)
        {
            _business.Save(Clientes);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _business.Delete(id);

            return RedirectToAction("Index");
        }
    }
}