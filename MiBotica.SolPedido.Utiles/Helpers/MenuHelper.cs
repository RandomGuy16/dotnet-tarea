using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.Utiles.Helpers;

public static class MenuHelper
{
    public static IHtmlContent HelperMenu(this IHtmlHelper helper, List<Opcion> listaOpciones, string titulo)
    {
        var principal = new TagBuilder("ul");
        principal.AddCssClass("sidebar-menu");
        principal.Attributes.Add("data-widget", "tree");

        var liHeader = new TagBuilder("li");
        liHeader.AddCssClass("header");
        liHeader.InnerHtml.Append(titulo);
        principal.InnerHtml.AppendHtml(liHeader);

        if (listaOpciones == null || !listaOpciones.Any())
        {
            return RenderTag(principal);
        }

        var urlHelperFactory = (IUrlHelperFactory)helper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory))!;
        var urlHelper = urlHelperFactory.GetUrlHelper(helper.ViewContext);

        bool tieneHijo = false;
        foreach (Opcion item in listaOpciones.Where(t => t.IdOpcionRef == 0).OrderBy(r => r.NroOrden).ToList())
        {
            tieneHijo = listaOpciones.Any(t => t.IdOpcionRef == item.IdOpcion);
            var itemLista = new TagBuilder("li");
            if (tieneHijo)
            {
                itemLista.AddCssClass("treeview");
            }

            var linkLista = new TagBuilder("a");
            linkLista.Attributes["href"] = GeneraHRef(urlHelper, item);

            var iLista = new TagBuilder("i");
            if (!string.IsNullOrEmpty(item.RutaImagen))
            {
                iLista.AddCssClass(item.RutaImagen);
            }
            linkLista.InnerHtml.AppendHtml(iLista);

            var spanLista = new TagBuilder("span");
            spanLista.InnerHtml.Append(item.NombreOpcion ?? string.Empty);
            linkLista.InnerHtml.AppendHtml(spanLista);

            if (tieneHijo)
            {
                var spanHijo = new TagBuilder("span");
                spanHijo.AddCssClass("pull-right-container");
                var iHijo = new TagBuilder("i");
                iHijo.AddCssClass("fa fa-angle-left pull-right");
                spanHijo.InnerHtml.AppendHtml(iHijo);
                linkLista.InnerHtml.AppendHtml(spanHijo);
            }

            itemLista.InnerHtml.AppendHtml(linkLista);

            if (tieneHijo)
            {
                LlenarOpcionMenu(itemLista, item, listaOpciones, urlHelper);
            }

            principal.InnerHtml.AppendHtml(itemLista);
        }

        return RenderTag(principal);
    }

    private static void LlenarOpcionMenu(TagBuilder itemLista, Opcion item, List<Opcion> listaOpciones, IUrlHelper urlHelper)
    {
        var ulHijo = new TagBuilder("ul");
        ulHijo.AddCssClass("treeview-menu");

        foreach (Opcion itemOpcion in listaOpciones.Where(x => x.IdOpcionRef == item.IdOpcion).OrderBy(r => r.NroOrden).ToList())
        {
            bool tieneHijo = listaOpciones.Any(x => x.IdOpcionRef == itemOpcion.IdOpcion);
            var liHijo = new TagBuilder("li");
            if (tieneHijo)
            {
                liHijo.AddCssClass("treeview");
            }

            var aHijo = new TagBuilder("a");
            aHijo.Attributes["href"] = GeneraHRef(urlHelper, itemOpcion);

            var iHijo = new TagBuilder("i");
            if (!string.IsNullOrEmpty(itemOpcion.RutaImagen))
            {
                iHijo.AddCssClass(itemOpcion.RutaImagen);
            }
            aHijo.InnerHtml.AppendHtml(iHijo);

            var spanTexto = new TagBuilder("span");
            spanTexto.InnerHtml.Append(itemOpcion.NombreOpcion ?? string.Empty);
            aHijo.InnerHtml.AppendHtml(spanTexto);

            if (tieneHijo)
            {
                var spanHijo = new TagBuilder("span");
                spanHijo.AddCssClass("pull-right-container");
                var iHijo2 = new TagBuilder("i");
                iHijo2.AddCssClass("fa fa-angle-left pull-right");
                spanHijo.InnerHtml.AppendHtml(iHijo2);
                aHijo.InnerHtml.AppendHtml(spanHijo);
            }

            liHijo.InnerHtml.AppendHtml(aHijo);

            if (tieneHijo)
            {
                LlenarOpcionMenu(liHijo, itemOpcion, listaOpciones, urlHelper);
            }

            ulHijo.InnerHtml.AppendHtml(liHijo);
        }

        itemLista.InnerHtml.AppendHtml(ulHijo);
    }

    private static string GeneraHRef(IUrlHelper urlHelper, Opcion item)
    {
        string rutaUrl = string.Empty;

        if (!string.IsNullOrEmpty(item.UrlOpcion) && item.UrlOpcion != "#")
        {
            string[] ruta = item.UrlOpcion.Split('/');
            switch (ruta.Length)
            {
                case 1:
                    rutaUrl = urlHelper.Action("Index", ruta[0]);
                    break;
                case 2:
                    if (ruta[1].Split('?').Length > 1)
                    {
                        rutaUrl = urlHelper.Action(ruta[1].Split('?')[0], ruta[0], RetornaObjetoParametros(ruta[1].Split('?')[1]));
                    }
                    else
                    {
                        rutaUrl = urlHelper.Action(ruta[1], ruta[0]);
                    }
                    break;
                case 3:
                    if (ruta[2].Split('?').Length > 1)
                    {
                        rutaUrl = urlHelper.Action(ruta[2].Split('?')[0], ruta[0] + "/" + ruta[1], RetornaObjetoParametros(ruta[2].Split('?')[1]));
                    }
                    else
                    {
                        rutaUrl = urlHelper.Action(ruta[2], ruta[0] + "/" + ruta[1]);
                    }
                    break;
                default:
                    rutaUrl = item.UrlOpcion;
                    break;
            }
        }
        else
        {
            rutaUrl = "#";
        }

        return rutaUrl;
    }

    private static RouteValueDictionary RetornaObjetoParametros(string parametro)
    {
        var rvd = new RouteValueDictionary();
        string[] parametros = parametro.Split('&');
        foreach (string item in parametros)
        {
            var partes = item.Split('=');
            if (partes.Length == 2)
            {
                rvd.Add(partes[0], partes[1]);
            }
        }
        return rvd;
    }

    private static IHtmlContent RenderTag(TagBuilder tag)
    {
        using var writer = new StringWriter();
        tag.WriteTo(writer, HtmlEncoder.Default);
        return new HtmlString(writer.ToString());
    }
}
