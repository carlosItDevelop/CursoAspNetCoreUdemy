### Reposit�rio Oficial do Projeto MedicalManagement-Sys

### Curso de Asp.Net Core 5.0 (In�cio em 2.2) - Do Zero ao Ninja

---

__Quer conhecer nosso projeto? Acesse o curso na Udemy:  **[Acesse aqui](https://www.udemy.com/course/curso-de-aspnet-core-mvc-2-2-do-zero-ao-ninja/?referralCode=41B345D11D74CEDD7E57)**.__

![Tela Inicial do Projeto MedicalManagenet-Sys](https://user-images.githubusercontent.com/1213751/71663844-87052780-2d35-11ea-95c0-623a74885ebc.png "Antes do Dashboard")


> __Valida��o global contra Ataque CSRF, prevenindo-se da aus�ncias nas Actions;__

---

```CSHARP
using Cooperchip.ITDeveloper.Mvc.Extentions.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cooperchip.ITDeveloper.Mvc.Configurations
{
    public static class MvcAndRazorConfig
    {
        public static IServiceCollection AddMvcAndRazor(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuditoriaIloggerFilter));
                
                // Todo: Passar na aula esta Valida��o global contra CSRF;
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            }); //.SetCompatibilityVersion(CompatibilityVersion.Version_3_1);  (OUT in the version)

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            return services;
        }
    }
}
```

---


### Controle de Vers�o:


> __In�cio da �ltima se��o antes do M�dulo B�nus (Arquitetura de Software), Polular Tabelas Iniciais, Importa��o de .CSV e Corre��o de Bugs__:

- Pr�-Release v.0.11.1: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/ImportCSV)**

> __Tela Inicial e Corre��o de Bug__:  *Pr�-Release com a Cria��o da Tela Inicial do Projeto e Corre��o de Bug (Atualiza��o de .CSHTML em Runtime).*

- Pr�-Release v.0.10.1: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/Atualizacao_TelaInicial)**.

> __Fim do M�dulo B�sico e Intermedi�rio__:  *Preimeiro pr�-release com todo o M�dulo B�sico e Parte do Intermedi�rio, at� a Migra��o do Asp.Net Core 2.2 para as vers�es 3.0.0 e 3.1.0*

- Pr�-Release v.0.9.0: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/CursoAspNetCoreUdemy)**.

---

#### Caso de Uso, onde agruparemos algumas fun��es gen�ricas e a documenta��o b�sica.


> __Interface de Reposit�rio Gen�rico__

- Nossa Interface gen�rica, respons�vel pela assinatura do nosso __Reposit�rio Gen�rico__;
- Todos os m�todos assinados aqui s�o gen�ricos e servem para a implementa��o com qualquer __Estrutura de Dados__;
- Os par�metros gen�ricos servem para que uma Entidade, que seja uma classe, seja recebida, assim como uma Chave;
- A chave recebida � pr�pria para que a __Chave Prim�ria__ seja do tipo gen�rico, escolhida pela equipe;


```CSharp
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cooperchip.ITDeveloper.Domain.Repository
{
    public interface IRepositoryGeneric<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        Task<TEntity> SelecionarPorId(TKey id);

        Task Inserir(TEntity obj);
        Task Atualizar(TEntity obj);
        Task Excluir(TEntity obj);
        Task ExcluirPorId(TKey id);
    }
}
```



- Nosso reposit�rio gen�rico

```CSharp
using Cooperchip.ITDeveloper.DomainCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IDomainGenericRepository<TEntity, TKey>
        where TEntity : class, new()
    {
        protected DbContext _context;
        //protected DbSet<TEntity> DbSet;

        protected RepositoryGeneric(DbContext ctx)
        {
            this._context = ctx;
            //this.DbSet = _context.Set<TEntity>();
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await Salvar();
        }
        public virtual async Task Excluir(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            await Salvar();
        }
        public virtual async Task ExcluirPorId(TKey id)
        {
            //TEntity obj = await SelecionarPorId(id);
            //await Excluir(obj);
            _context.Set<TEntity>().Remove(new TEntity{ Id = id });
            await Salvar();
        }
        public virtual async Task Inserir(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await Salvar();
        }
        public virtual async Task<TEntity> SelecionarPorId(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> expressaowhere = null)
        {
            if (expressaowhere == null)
            {
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await _context.Set<TEntity>().AsNoTracking().Where(expressaowhere).ToListAsync();
        }
        public virtual async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
```

> __Servi�o de Aplica��o:__ *Em nossa Application Layer implementamos o Reposit�rio gen�rico atrav�s do Dom�nio:*

```CSharp
using Cooperchip.ITDeveloper.Application.Services.Interfaces;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Domain.Models;
using Cooperchip.ITDeveloper.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Application.Services
{
    public class ServiceApplicationPaciente : IServiceApplicationPaciente
    {
        private readonly IRepositoryDomainPaciente _repo;
        public ServiceApplicationPaciente(IRepositoryDomainPaciente repositoryRepoPaciente)
        {
            this._repo = repositoryRepoPaciente;
        }
        public async Task<IEnumerable<PacienteViewModel>> ListarPacientes()
        {
            var lista = await _repo.SelecionarTodos();
            return await RetornaPacienteViewModel(lista);
        }
        public async Task<IEnumerable<PacienteViewModel>> ListarPacientesComEstado()
        {
            var lista = await _repo.ListarPacientesComEstado();
            return await RetornaPacienteViewModel(lista);
        }
        public async Task<List<PacienteViewModel>> RetornaPacienteViewModel(IEnumerable<Paciente> lista)
        {
            List<PacienteViewModel> listaPaciente = new List<PacienteViewModel>();
            foreach (var item in lista)
            {
                PacienteViewModel paciente = new PacienteViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataNascimento = item.DataNascimento,
                    DataInternacao = item.DataInternacao,
                    Email = item.Email,
                    Ativo = item.Ativo,
                    Rg = item.Rg,
                    RgDataEmissao = item.DataInternacao,
                    RgOrgao = item.RgOrgao,
                    Sexo = item.Sexo,
                    TipoPaciente = item.TipoPaciente,
                    EstadoPaciente = item.EstadoPaciente,
                    EstadoPacienteId = item.EstadoPacienteId
                };
                listaPaciente.Add(paciente);
            }
            return listaPaciente;

        }
    }
}

```


> Tela ilustrativa de Mural de Avisos e __Solicita��es de Acesso__

![Tela de Mural do MedicalManagenet-Sys](http://apimltools.com.br/itdeveloperimg/mural-evolumed-sys.png "Mural de Avisos - MedicalManagenet-Sys")


## DataCadastro:

> Todo: O campo DataCadastro deve ser inclu�do automaticamente, mas n�o deve ser alterado. Este processo ser� implementado no contexto da aplica��o.

---

> ## TaskList - Tag Helpers

 Feature														| Complexidade	| Status	
---------------------------------------------------------------	| -------------	| --------	
 Validar as Views - Modal sem fech�-las              			| M�dia			| Pendente		
 Validar o tamanho / resol��o da Imagem de Profile              | Baixa         | Pendente
 Validar tipo de arquivo para o Perfil do Usu�rio (jpg/png)     | Baixa         | Pendente

  


---

## C�digo pronto do nosso EmailTagHelper

```CSharp
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Domain { get; set; } = "eaditdeveloper.com.br";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + Domain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
```

> __Features__

- [x] Criar interface gen�rica para todos os CRUDs
- [x] Criar reposit�rio gen�rico
- [ ] Implementar metodos faltantes em Repository
- [ ] Criar os relacionamentos em EntityMap
- [ ] Atualizar a documenta��o para Tag Helpers com Reflection
- [x] Criar novo proejeto DomainCore, onde estar� a EntityBase e a Interface IAggegateRoot
- [ ] Criar Exception de Dominio
- [x] Criar os primeiros ValueObjects
- [ ] Configurar Setters privates
- [ ] Criar m�todos Ad-Hocs para os setters
- [ ] Criar Exception de Dominio
- [x] Criar VO RG
- [x] Criar VO Dimensao
- [x] Criar Interface IDomainGenericRepository in DomainCore

---

# Aten��o na Implementa��o do Identity: __ScaffoldingReadMe__

### O suporte para o __Identity__ do ASP.NET foi adicionado ao seu projeto
> O c�digo para adicionar o Identity ao seu projeto foi gerado em Areas/Identity.

- A configura��o dos servi�os relacionados ao Identity pode ser encontrada no arquivo Areas/Identity/IdentityHostingStartup.cs.
- Se seu aplicativo foi configurado anteriormente para usar o Identity, remova a chamada para o m�todo AddIdentity do seu m�todo ConfigureServices.
- A interface do usu�rio gerada requer suporte para arquivos est�ticos. Para adicionar arquivos est�ticos ao seu aplicativo:
	1. Chame app.UseStaticFiles() do seu m�todo Configure

- Para usar a identidade principal do ASP.NET, voc� tamb�m precisa habilitar a autentica��o. Para autentica��o no seu aplicativo:
	1. Chame app.UseAuthentication() do seu m�todo Configure (depois dos arquivos est�ticos)

- A interface do usu�rio gerada requer MVC. Para adicionar o MVC ao seu aplicativo:
	1. Chame services.AddMvc() do seu m�todo ConfigureServices
	2. Chame app.UseMvc() do seu m�todo Configure (ap�s autentica��o)

- O c�digo do banco de dados gerado requer migra��es principais do Entity Framework. Execute os seguintes comandos:
	1. dotnet ef migrations add CreateIdentitySchema
	2. dotnet ef database update
	
- Ou no Package Manager Console do Visual Studio:
	1. Add-Migration CreateIdentitySchema
	2. Update-Database


---
- Os aplicativos que usam o ASP.NET Core Identity tamb�m devem usar HTTPS. 
	1. Para ativar o HTTPS **[Leia aqui](https://go.microsoft.com/fwlink/?linkid=848054)**.
- Consultar a documenta��o para TagHelpers e ViewComponents, **[Leia aqui](https://docs.microsoft.com/pt-br/)**.
- Consultar a documenta��o para MarkDown, **[Leia aqui](http://daringfireball.net/projects/markdown/basics)**.

---

> __Exercitando Reflection:__ Refletindo Namespace e outros.

```CSharp

using System;
using System.IO;
using System.Reflection;
using Cooperchip.ITDeveloper.Domain.Models;

namespace ConsoleSamples
{
    // This program lists all the members of the
    // System.IO.BufferedStream class. 
    
    class ListMembers
    {
        public static void Main()
        {
            {

                // Specifies the class.
                //Type t = typeof(System.IO.BufferedStream);


                // -------------------------/ Por Carlos ------//
                Type t = typeof(Paciente);
                var nameSpace = t.FullName;

                // Verificando Namespace;
                Console.WriteLine($"// Imprimindo Namespace de: {t}");
                Console.WriteLine("{0}{1}", "     ", nameSpace);
                // -------------------------/ Por Carlos ------//


                Console.WriteLine("Listing all the members (public and non public) of the {0} type", t);
                // Lists static fields first.
                FieldInfo[] fi = t.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Static Fields");
                PrintMembers(fi);
                // Static properties.        
                PropertyInfo[] pi = t.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Static Properties");
                PrintMembers(pi);
                // Static events.        
                EventInfo[] ei = t.GetEvents(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Static Events");
                PrintMembers(ei);
                // Static methods.        
                MethodInfo[] mi = t.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Static Methods");
                PrintMembers(mi);
                // Constructors.        
                ConstructorInfo[] ci =
                    t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Constructors");
                PrintMembers(ci);
                // Instance fields.        
                fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Instance Fields");
                PrintMembers(fi);
                // Instance properites.        
                pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Instance Properties");
                PrintMembers(pi);
                // Instance events.        
                ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Instance Events");
                PrintMembers(ei);
                // Instance methods.        
                mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Console.WriteLine("// Instance Methods");
                PrintMembers(mi);


                Console.WriteLine("\r\nPress ENTER to exit.");
                Console.ReadKey();
            }


        }
        private static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
```


Consultar a documenta��o para TagHelpers e ViewComponents, **[Leia aqui](https://docs.microsoft.com/pt-br/)**.
Consultar a documenta��o para MarkDown, **[Leia aqui](http://daringfireball.net/projects/markdown/basics)**.

---

> Quer conhecer nosso projeto? Acesse o curso na Udemy:  **[Acesse aqui](https://www.udemy.com/course/curso-de-aspnet-core-mvc-2-2-do-zero-ao-ninja/?referralCode=41B345D11D74CEDD7E57)**.

