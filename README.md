## Repositório Oficial do Projeto MedicalManagement-Sys

### Este projeto é o Caso de Uso do nosso Curso de Asp.NetCore MVC - Do Zero ao Ninja

> *__Tela Inicial criada em 02-01-2020. Está no Release 0.10.1. Confira lá:__*

![Tela Inicial do Projeto MedicalManagenet-Sys](https://user-images.githubusercontent.com/1213751/71663844-87052780-2d35-11ea-95c0-623a74885ebc.png "Antes do Dashboard")


### DataCadastro:

> Todo: O campo DataCadastro deve ser incluído automaticamente, mas não deve ser alterado. Este processo será implementado no contexto da aplicação.

---

### Controle de Versão:

> __Fim do Módulo Básico e Intermediário__:  *Preimeiro pré-release com todo o Módulo Básico e Parte do Intermediário, até a Migração do Asp.Net Core 2.2 para as versões 3.0.0 e 3.1.0*

- Pré-Release v.0.9.0: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/CursoAspNetCoreUdemy)**.

> __Tela Inicial e Correção de Bug__:  *Pré-Release com a Criação da Tela Inicial do Projeto e Correção de Bug (Atualização de .CSHTML em Runtime).*

- Pré-Release v.0.10.1: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/Atualizacao_TelaInicial)**.

> __Início da Última seção antes do Módulo Bônus (Arquitetura de Software), Polular Tabelas Iniciais, Importação de .CSV e Correção de Bugs__:

- Pré-Release v.0.11.0: **[Acesse Aqui](https://github.com/carlosItDevelop/CursoAspNetCoreUdemy/releases/tag/ImportCSV)**

---

> ### TaskList - Tag Helpers

 Feature														| Complexidade	| Status	
---------------------------------------------------------------	| -------------	| --------	
 Criar uma Tag Helper para exibir um e-mail no Rodapé			| Alta			| Ok		
 Podemos usar um domínio padrão ou um parametrizado				| Alta			| Ok		
 Vamos customizar a Tag Html "a", usando, inclusive, o mailTo	| Normal		| Ok		
 Preciso de uma classe com o sufixo Tagelper					| Baixa			| Ok
 Preciso que a classe acima Herde de TagHelper					| Alta			| Ok
 Package: using Microsoft.Asp.NetCore.Razor.TagHelpers			| Baixa			| Ok
 Essa class precisa sobrescrever a Task ProcessAsync			| Média			| Ok
 Parâmetros: (TagHelperContext context, TagHelperOutput output)	| Média			| Ok
 Neste exemplo vamos deixar o context de lado					| Baixa			| Ok
 Usaremos um domínio default ou receberemos no parâmetro		| Normal		| OK
 Usaremos a notação Kebab Case: MeuEmail  => meu-email			| Baixa			| Ok

---

### Código pronto do nosso EmailTagHelper

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

### Migrando nossa aplicação do Asp.Net Core 2.2 para 3.0 / 3.1.


>> Se você for um iniciante em Asp.Net Core talvez nunca tenha ouvido falar de AddMvcCore().


Consultar a documentação para TagHelpers e ViewComponents, **[Leia aqui](https://docs.microsoft.com/pt-br/)**.
Consultar a documentação para MarkDown, **[Leia aqui](http://daringfireball.net/projects/markdown/basics)**.

---

> Quer conhecer nosso projeto? Acesse o curso na Udemy:  **[Acesse aqui](https://www.udemy.com/course/curso-de-aspnet-core-mvc-2-2-do-zero-ao-ninja/?referralCode=41B345D11D74CEDD7E57)**.

