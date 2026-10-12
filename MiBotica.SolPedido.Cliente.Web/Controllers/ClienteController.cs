using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using MiBotica.SolPedido.Entidades.Core;
using ClienteEntity = MiBotica.SolPedido.Entidades.Core.Cliente;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ClienteController : Controller
    {
        private string ApiBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["apiBaseUrl"]
                    ?? "http://localhost:5044";
            }
        }

        public ActionResult Index()
        {
            return Consultar();
        }

        public ActionResult Consultar()
        {
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(
                    new Uri(ApiBaseUrl.TrimEnd('/') + "/api/cliente")).Result;
                List<ClienteEntity> clientes = JsonConvert.DeserializeObject<List<ClienteEntity>>(json)
                    ?? new List<ClienteEntity>();
                return View("Index", clientes);
            }
        }

        public ActionResult Create()
        {
            return View(new ClienteEntity());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insertar(ClienteEntity cliente)
        {
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(cliente);
                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = client.PostAsync(
                        new Uri(ApiBaseUrl.TrimEnd('/') + "/api/cliente"), content).Result;
                    response.EnsureSuccessStatusCode();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
