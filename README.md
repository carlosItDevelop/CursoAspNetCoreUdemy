# Repositório Oficial do Projeto MedicalManagement-Sys

### Este projeto é o Caso de Uso do nosso Curso de Asp.NetCore MVC 2.2 - Do Zero ao Ninja


> Tela ilustrativa inicial - Dashboard


![Tela de Dashboard do MedicalManagenet-Sys](http://apimltools.com.br/itdeveloperimg/Dashboard-Evolumed-Sys.png "Dashboard - MedicalManagenet-Sys")


> __Interface de Repositório Genérico__

- Nossa Interface genérica, responsável pela assinatura do nosso __Repositório Genérico__;
- Todos os métodos assinados aqui são genéricos e servem para a implementação com qualquer __Estrutura de Dados__;
- Os parâmetros genéricos servem para que uma Entidade, que seja uma classe, seja recebida, assim como uma Chave;
- A chave recebida é própria para que a __Chave Primária__ seja do tipo genérico, escolhida pela equipe;


```CSharp
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cooperchip.ITDeveloper.Domain.Repository
{
    public interface IRepositoryGeneric<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        //Task<List<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        IEnumerable<TEntity> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        TEntity SelecionarPorId(TKey id);

        void Inserir(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void ExcluirPorId(TKey id);
    }
}
```



- Nosso repositório genérico

```CSharp

using Cooperchip.ITDeveloper.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cooperchip.ITDeveloper.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IRepositoryGeneric<TEntity, TKey>
        where TEntity : class, new()
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryGeneric(DbContext ctx)
        {
            this.Db = ctx;
            this.DbSet = Db.Set<TEntity>();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Salvar();
        }
        public void Excluir(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Salvar();
        }
        public void ExcluirPorId(TKey id)
        {
            TEntity obj = SelecionarPorId(id);
            Excluir(obj);
        }
        public void Inserir(TEntity obj)
        {
            DbSet.Add(obj);
            Salvar();
        }
        public TEntity SelecionarPorId(TKey id)
        {
            return DbSet.Find(id);
        }
        public IEnumerable<TEntity> SelecionarTodos(Expression<Func<TEntity, bool>> expressaowhere = null)
        {
            if (expressaowhere == null)
            {
                return DbSet.AsNoTracking().ToList();
            }
            return DbSet.Where(expressaowhere).AsNoTracking().ToList();
        }
        public void Salvar()
        {
            Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
```

> __Serviço de Aplicação:__ *Em nossa Application Layer implementamos o Repositório genérico através do Domínio:*

```CSharp
using Cooperchip.ITDeveloper.Application.Services.Interfaces;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Repository;
using System.Collections.Generic;
using Cooperchip.ITDeveloper.Domain.Models;

namespace Cooperchip.ITDeveloper.Application.Services
{
    public class ServiceApplicationPaciente : IServiceApplicationPaciente
    {
        private readonly IRepositoryDomainPaciente _repo;
        public ServiceApplicationPaciente(IRepositoryDomainPaciente repositoryRepoPaciente, ITDeveloperDbContext context)
        {
            this._repo = repositoryRepoPaciente;
        }
        public IEnumerable<PacienteViewModel> ListarPacientes()
        {
            var lista = _repo.SelecionarTodos();
            return RetornaPacienteViewModel(lista);
        }
        public IEnumerable<PacienteViewModel> ListarPacientesComEstado()
        {
            var lista = _repo.ListarPacientesComEstado();
            return RetornaPacienteViewModel(lista);
        }
        public List<PacienteViewModel> RetornaPacienteViewModel(IEnumerable<Paciente> lista)
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


> Tela ilustrativa de Mural de Avisos e __Solicitações de Acesso__

![Tela de Mural do MedicalManagenet-Sys](http://apimltools.com.br/itdeveloperimg/mural-evolumed-sys.png "Mural de Avisos - MedicalManagenet-Sys")


## DataCadastro:

> Todo: O campo DataCadastro deve ser incluído automaticamente, mas não deve ser alterado. Este processo será implementado no contexto da aplicação.

---

> ## TaskList - Tag Helpers

 Feature														| Complexidade	| Status	
---------------------------------------------------------------	| -------------	| --------	
 Criar uma Tag Helper para exibir um e-mail no Rodapé			| Alta			| Ok		
 Podemos usar um domínio padrão ou um parametrizado				| Alta			| Ok		
 Vamos customizar a Tag Html "a", usando, inclusive, o mailTo	| Normal		| Not Implem		
 Preciso de uma classe com o sufixo Tagelper					| Baixa			| Not Implem
 Preciso que a classe acima Herde de TagHelper					| Alta			| Not Implem
 Package: using Microsoft.Asp.NetCore.Razor.TagHelpers			| Baixa			| Not Implem
 Essa class precisa sobrescrever a Task ProcessAsync			| Média			| Not Implem
 Parâmetros: (TagHelperContext context, TagHelperOutput output)	| Média			| Not Implem
 Neste exemplo vamos deixar o context de lado					| Baixa			| Ok
 Usaremos um domínio default ou receberemos no parâmetro		| Normal		| OK
 Usaremos a notação Kebab Case: MeuEmail  => meu-email			| Baixa			| Ok

---

## Código pronto do nosso EmailTagHelper

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

## Migrando nossa aplicação do Asp.Net Core 2.2 para 3.0 / 3.1.


>> Se você for um iniciante em Asp.Net Core talvez nunca tenha ouvido falar de AddMvcCore().




Consultar a documentação para TagHelpers e ViewComponents, **[Leia aqui](https://docs.microsoft.com/pt-br/)**.
Consultar a documentação para MarkDown, **[Leia aqui](http://daringfireball.net/projects/markdown/basics)**.