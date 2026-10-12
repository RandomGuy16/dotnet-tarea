using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.Cliente.Web.Controllers;

public class ClienteController : Controller
{
    private readonly IConfiguration _configuration;

    public ClienteController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return RedirectToAction(nameof(Consultar));
    }

    public async Task<IActionResult> Consultar()
    {
        using HttpClient client = CreateClient();
        HttpResponseMessage response = await client.GetAsync("api/cliente");
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();
        List<MiBotica.SolPedido.Entidades.Core.Cliente> clientes = JsonSerializer.Deserialize<List<MiBotica.SolPedido.Entidades.Core.Cliente>>(content)
            ?? new List<MiBotica.SolPedido.Entidades.Core.Cliente>();
        return View("Index", clientes);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new MiBotica.SolPedido.Entidades.Core.Cliente());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Insertar(MiBotica.SolPedido.Entidades.Core.Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", cliente);
        }

        using HttpClient client = CreateClient();
        string content = JsonSerializer.Serialize(cliente);
        using StringContent requestContent = new StringContent(
            content,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage response = await client.PostAsync("api/cliente", requestContent);
        response.EnsureSuccessStatusCode();
        return RedirectToAction(nameof(Consultar));
    }

    private HttpClient CreateClient()
    {
        string baseUrl = _configuration["ApiUsuario:BaseUrl"]
            ?? throw new InvalidOperationException("No se configuró ApiUsuario:BaseUrl.");

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/");
        return client;
    }
}
