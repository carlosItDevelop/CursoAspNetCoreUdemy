# Repositório Oficial do Projeto MedicalManagement-Sys

## Este projeto é o Caso de Uso do nosso Curso de Asp.NetCore MVC - Do Zero ao Ninja

### DataCadastro:

> Todo: O campo DataCadastro deve ser incluído automaticamente, mas não deve ser alterado. Este processo será implementado no contexto da aplicação.

---

> ### TaskList - Tag Helpers

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