# Graph Report - dotnet-tarea  (2026-09-14)

## Corpus Check
- 54 files · ~147,352 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 339 nodes · 393 edges · 64 communities (23 shown, 41 thin omitted)
- Extraction: 98% EXTRACTED · 2% INFERRED · 0% AMBIGUOUS · INFERRED: 7 edges (avg confidence: 0.76)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `aee094a9`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- MiBotica.SolPedido.Cliente.Web
- http
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
- grunt
- grunt-contrib-compress
- grunt-contrib-copy
- grunt-contrib-htmlmin
- grunt-contrib-less
- grunt-contrib-pug
- grunt-contrib-qunit
- grunt-csscomb
- grunt-jscs
- markdown-it
- time-grunt
- icheck.min.js
- devDependencies
- jquery-slimscroll/package.json
- FastClick
- bootstrap/package.json
- CONTRIBUTING.md
- icheck.js
- jquery.slimscroll.js
- grunt-autoprefixer
- grunt-exec
- grunt-contrib-clean
- grunt-contrib-concat
- grunt-contrib-connect
- grunt-contrib-jshint
- grunt-contrib-uglify
- grunt-contrib-watch
- grunt-html
- grunt-jekyll
- grunt-saucelabs
- load-grunt-tasks
- shelljs
- shx

## God Nodes (most connected - your core abstractions)
1. `FastClick()` - 17 edges
2. `Usuario` - 12 edges
3. `MiBotica.SolPedido.Cliente.Web` - 10 edges
4. `keywords` - 10 edges
5. `UsuarioDA` - 8 edges
6. `MiBotica.SolPedido.AccesoDatos` - 8 edges
7. `MiBotica.SolPedido.LogicaNegocio` - 8 edges
8. `keywords` - 8 edges
9. `files` - 8 edges
10. `MiBotica.SolPedido.Entidades\MiBotica.SolPedido.Entidades` - 7 edges

## Surprising Connections (you probably didn't know these)
- `F()` --indirect_call--> `w()`  [INFERRED]
  MiBotica.SolPedido.Cliente.Web/wwwroot/Content/plugins/iCheck/icheck.min.js → MiBotica.SolPedido.Cliente.Web/wwwroot/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js
- `UsuarioDA` --inherits--> `BaseDA`  [EXTRACTED]
  MiBotica.SolPedido.AccesoDatos/Core/UsuarioDA.cs → MiBotica.SolPedido.AccesoDatos/Core/BaseDA.cs
- `UsuarioLN` --inherits--> `BaseLN`  [EXTRACTED]
  MiBotica.SolPedido.LogicaNegocio/Core/UsuarioLN.cs → MiBotica.SolPedido.LogicaNegocio/Core/BaseLN.cs

## Import Cycles
- None detected.

## Communities (64 total, 41 thin omitted)

### Community 0 - "MiBotica.SolPedido.Cliente.Web"
Cohesion: 0.11
Nodes (24): MiBotica.SolPedido.AccesoDatos, net10.0, Microsoft.NET.Sdk, MiBotica.SolPedido.Cliente.Web, net10.0, log4net (3.4.0), MiBotica.SolPedido.Entidades\MiBotica.SolPedido.Entidades, net10.0 (+16 more)

### Community 1 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 3 - "Usuario"
Cohesion: 0.08
Nodes (17): MiBotica.SolPedido.Entidades.Core, MiBotica.SolPedido.AccesoDatos.Core, MiBotica.SolPedido.Utiles.Helpers, MiBotica.SolPedido.Cliente.Web.Controllers, MiBotica.SolPedido.LogicaNegocio.Core, IConfiguration, IDataReader, ILog (+9 more)

### Community 4 - "HomeController"
Cohesion: 0.24
Nodes (5): MiBotica.SolPedido.Cliente.Web.Models, IActionResult, HomeController, ErrorViewModel, ResponseCache

### Community 25 - "UsuarioController"
Cohesion: 0.23
Nodes (8): ActionName, Controller, HttpPost, IActionResult, UsuarioController, EncriptacionHelper, Rfc2898DeriveBytes, ValidateAntiForgeryToken

### Community 53 - "icheck.min.js"
Cohesion: 0.30
Nodes (11): n(), p(), v(), w(), x(), D(), F(), k() (+3 more)

### Community 100 - "devDependencies"
Cohesion: 0.22
Nodes (9): btoa, glob, grunt-contrib-csslint, grunt-contrib-cssmin, devDependencies, btoa, glob, grunt-contrib-csslint (+1 more)

### Community 115 - "jquery-slimscroll/package.json"
Cohesion: 0.07
Nodes (26): jquery, author, name, url, dependencies, jquery, description, homepage (+18 more)

### Community 176 - "bootstrap/package.json"
Cohesion: 0.05
Nodes (44): author, bugs, url, description, engines, node, files, homepage (+36 more)

### Community 192 - "CONTRIBUTING.md"
Cohesion: 0.17
Nodes (11): Before Submitting your Code, Contributing Bugfixes, Contributing Features, Contributing Locales, Development Workflow, Getting Set Up, Other Ways to Contribute, Reporting Bugs (+3 more)

### Community 286 - "icheck.js"
Cohesion: 0.64
Nodes (7): callbacks(), capitalize(), off(), on(), operate(), option(), tidy()

### Community 297 - "jquery.slimscroll.js"
Cohesion: 0.52
Nodes (6): attachWheel(), getBarHeight(), hideBar(), _onWheel(), scrollContent(), showBar()

## Knowledge Gaps
- **143 isolated node(s):** `MiBotica.SolPedido.AccesoDatos`, `Class1`, `net10.0`, `Microsoft.Data.SqlClient (7.0.2)`, `Microsoft.Extensions.Configuration.Abstractions (10.0.11)` (+138 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **41 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `devDependencies` connect `devDependencies` to `grunt`, `grunt-contrib-compress`, `grunt-contrib-copy`, `grunt-contrib-htmlmin`, `grunt-contrib-less`, `grunt-contrib-pug`, `grunt-contrib-qunit`, `grunt-csscomb`, `grunt-jscs`, `markdown-it`, `time-grunt`, `grunt-autoprefixer`, `grunt-exec`, `bootstrap/package.json`, `grunt-contrib-clean`, `grunt-contrib-concat`, `grunt-contrib-connect`, `grunt-contrib-jshint`, `grunt-contrib-uglify`, `grunt-contrib-watch`, `grunt-html`, `grunt-jekyll`, `grunt-saucelabs`, `load-grunt-tasks`, `shelljs`, `shx`?**
  _High betweenness centrality (0.074) - this node is a cross-community bridge._
- **Why does `Usuario` connect `Usuario` to `UsuarioController`?**
  _High betweenness centrality (0.014) - this node is a cross-community bridge._
- **What connects `MiBotica.SolPedido.AccesoDatos`, `Class1`, `net10.0` to the rest of the system?**
  _143 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `MiBotica.SolPedido.Cliente.Web` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Should `http` be split into smaller, more focused modules?**
  _Cohesion score 0.13333333333333333 - nodes in this community are weakly interconnected._
- **Should `Usuario` be split into smaller, more focused modules?**
  _Cohesion score 0.07827260458839407 - nodes in this community are weakly interconnected._
- **Should `jquery-slimscroll/package.json` be split into smaller, more focused modules?**
  _Cohesion score 0.07407407407407407 - nodes in this community are weakly interconnected._