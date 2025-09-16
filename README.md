# Validador de CPF e CNPJ em C#

Uma biblioteca .NET, simples e robusta, para validação de números de CPF (Cadastro de Pessoas Físicas) e CNPJ (Cadastro Nacional da Pessoa Jurídica) do Brasil. O projeto segue as melhores práticas de desenvolvimento, como SOLID e testes unitários, para garantir confiabilidade и manutenibilidade.

## ✨ Funcionalidades

- **Validação de CPF**: Verifica se um número de CPF é válido de acordo com as regras da Receita Federal, incluindo a validação dos dígitos verificadores.
- **Validação de CNPJ**: Verifica se um número de CNPJ é válido, seguindo os algoritmos de cálculo dos dígitos verificadores.
- **Flexibilidade de Formato**: Aceita números com ou sem máscara (pontos, traços e barras).
- **Tratamento de Casos Inválidos**: Rejeita sequências com todos os dígitos iguais (ex: `111.111.111-11`), que são inválidas apesar de passarem no cálculo do dígito verificador.

## 🛠️ Pré-requisitos

Para compilar e executar este projeto, você precisará ter o seguinte software instalado:

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) ou superior
- [Git](https://git-scm.com/)

## 🚀 Como Usar

A biblioteca é muito simples de usar. Primeiro, adicione uma referência ao projeto `CpfCnpjValidator.Domain` na sua aplicação. Em seguida, utilize as classes estáticas `CpfValidator` e `CnpjValidator`.

### Exemplo de Código

```csharp
using CpfCnpjValidator.Domain;
using System;

public class Program
{
    public static void Main()
    {
        // --- Exemplo de Validação de CPF ---
        string cpfValido = "123.456.789-00"; // Substitua por um CPF real para teste
        string cpfInvalido = "111.111.111-11";

        bool resultadoCpfValido = CpfValidator.IsValid(cpfValido);
        Console.WriteLine($"O CPF '{cpfValido}' é válido? {resultadoCpfValido}"); // Saída: True (se o CPF for válido)

        bool resultadoCpfInvalido = CpfValidator.IsValid(cpfInvalido);
        Console.WriteLine($"O CPF '{cpfInvalido}' é válido? {resultadoCpfInvalido}"); // Saída: False


        // --- Exemplo de Validação de CNPJ ---
        string cnpjValido = "11.222.333/0001-81"; // Substitua por um CNPJ real para teste
        string cnpjInvalido = "00.000.000/0000-00";

        bool resultadoCnpjValido = CnpjValidator.IsValid(cnpjValido);
        Console.WriteLine($"O CNPJ '{cnpjValido}' é válido? {resultadoCnpjValido}"); // Saída: True (se o CNPJ for válido)

        bool resultadoCnpjInvalido = CnpjValidator.IsValid(cnpjInvalido);
        Console.WriteLine($"O CNPJ '{cnpjInvalido}' é válido? {resultadoCnpjInvalido}"); // Saída: False
    }
}
````

## 🧪 Rodando os Testes

O projeto utiliza xUnit para garantir a qualidade e o correto funcionamento dos algoritmos de validação. Para executar os testes, navegue até o diretório raiz do projeto no seu terminal e execute o seguinte comando:

```bash
dotnet test
```

Você verá a saída dos testes indicando se todas as validações passaram com sucesso.

## 📁 Estrutura do Projeto

O projeto está organizado da seguinte forma para manter a separação de responsabilidades (SoC):

```
.
├── src/
│   └── CpfCnpjValidator.Domain/   # Biblioteca de classes com a lógica de negócio (validação).
├── tests/
│   └── CpfCnpjValidator.Tests/    # Projeto de testes unitários.
├── .gitignore                     # Arquivos e pastas a serem ignorados pelo Git.
├── CpfCnpjValidator.sln           # Arquivo da solução do Visual Studio.
└── README.md                      # Esta documentação.
```

## 🤝 Como Contribuir

Contribuições são o que tornam a comunidade de código aberto um lugar incrível para aprender, inspirar e criar. Qualquer contribuição que você fizer será muito apreciada.

- Faça um Fork do projeto.
- Crie uma Branch para sua feature (`git checkout -b feature/NovaFuncionalidade`).
- Faça o Commit de suas alterações (`git commit -m 'feat: Adiciona NovaFuncionalidade'`).
- Faça o Push para a Branch (`git push origin feature/NovaFuncionalidade`).
- Abra um Pull Request.
