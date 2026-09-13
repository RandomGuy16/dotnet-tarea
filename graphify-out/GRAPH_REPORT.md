# Graph Report - dotnet-tarea  (2026-09-13)

## Corpus Check
- 43 files · ~3,937 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 144 nodes · 161 edges · 29 communities (14 shown, 15 thin omitted)
- Extraction: 98% EXTRACTED · 2% INFERRED · 0% AMBIGUOUS · INFERRED: 3 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `190f49a0`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- MiBotica.SolPedido.Cliente.Web
- http
- UsuarioDA
- Usuario
- HomeController
- rules/graphify.md
- workflows/graphify.md
- MiBotica.SolPedido.AccesoDatos/Class1.cs
- MiBotica.SolPedido.Utiles/Class1.cs
- MiBotica.SolPedido.UtilesWeb/Class1.cs
- MiBotica.SolPedido.LogicaNegocio/Class1.cs
- MiBotica.SolPedido.Entidades/Class1.cs
- jQuery MIT License
- mibotica.db MSSQL Service
- MiBotica.SolPedido.Cliente.Web.Models
- IEnumerable<MiBotica.SolPedido.Entidades.Core.Usuario>
- jQuery Validation Unobtrusive MIT License
- UsuarioController
- Create.cshtml
- Delete.cshtml
- Edit.cshtml

## God Nodes (most connected - your core abstractions)
1. `Usuario` - 11 edges
2. `MiBotica.SolPedido.Cliente.Web` - 10 edges
3. `MiBotica.SolPedido.AccesoDatos` - 8 edges
4. `MiBotica.SolPedido.LogicaNegocio` - 8 edges
5. `MiBotica.SolPedido.Entidades\MiBotica.SolPedido.Entidades` - 7 edges
6. `UsuarioController` - 7 edges
7. `UsuarioLN` - 7 edges
8. `UsuarioDA` - 6 edges
9. `http` - 6 edges
10. `https` - 6 edges

## Surprising Connections (you probably didn't know these)
- `UsuarioDA` --inherits--> `BaseDA`  [EXTRACTED]
  MiBotica.SolPedido.AccesoDatos/Core/UsuarioDA.cs → MiBotica.SolPedido.AccesoDatos/Core/BaseDA.cs
- `UsuarioLN` --inherits--> `BaseLN`  [EXTRACTED]
  MiBotica.SolPedido.LogicaNegocio/Core/UsuarioLN.cs → MiBotica.SolPedido.LogicaNegocio/Core/BaseLN.cs

## Import Cycles
- None detected.

## Communities (29 total, 15 thin omitted)

### Community 0 - "MiBotica.SolPedido.Cliente.Web"
Cohesion: 0.11
Nodes (24): MiBotica.SolPedido.AccesoDatos, net10.0, Microsoft.NET.Sdk, MiBotica.SolPedido.Cliente.Web, net10.0, log4net (3.4.0), MiBotica.SolPedido.Entidades\MiBotica.SolPedido.Entidades, net10.0 (+16 more)

### Community 1 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 2 - "UsuarioDA"
Cohesion: 0.17
Nodes (7): MiBotica.SolPedido.AccesoDatos.Core, IConfiguration, IDataReader, BaseDA, List, UsuarioDA, SqlConnection

### Community 3 - "Usuario"
Cohesion: 0.15
Nodes (8): MiBotica.SolPedido.Entidades.Core, MiBotica.SolPedido.LogicaNegocio.Core, ILog, Opcion, Usuario, BaseLN, List, UsuarioLN

### Community 4 - "HomeController"
Cohesion: 0.20
Nodes (7): Controller, MiBotica.SolPedido.Cliente.Web.Controllers, MiBotica.SolPedido.Cliente.Web.Models, IActionResult, HomeController, ErrorViewModel, ResponseCache

### Community 25 - "UsuarioController"
Cohesion: 0.20
Nodes (8): ActionName, MiBotica.SolPedido.Utiles.Helpers, HttpPost, IActionResult, UsuarioController, EncriptacionHelper, Rfc2898DeriveBytes, ValidateAntiForgeryToken

## Knowledge Gaps
- **50 isolated node(s):** `MiBotica.SolPedido.AccesoDatos`, `Class1`, `net10.0`, `Microsoft.Data.SqlClient (7.0.2)`, `Microsoft.Extensions.Configuration.Abstractions (10.0.11)` (+45 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **15 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Usuario` connect `Usuario` to `UsuarioController`, `UsuarioDA`?**
  _High betweenness centrality (0.070) - this node is a cross-community bridge._
- **Why does `UsuarioController` connect `UsuarioController` to `HomeController`?**
  _High betweenness centrality (0.055) - this node is a cross-community bridge._
- **What connects `MiBotica.SolPedido.AccesoDatos`, `Class1`, `net10.0` to the rest of the system?**
  _50 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `MiBotica.SolPedido.Cliente.Web` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Should `http` be split into smaller, more focused modules?**
  _Cohesion score 0.13333333333333333 - nodes in this community are weakly interconnected._