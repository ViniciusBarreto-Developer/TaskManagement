<h1 align="center">Projeto .NET 6 com MongoDB</h1>

<p align="center">  
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-projeto">Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-layout">Implementações</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-Equipe">Como Executar o Projeto</a>
</p>

## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- .NET Core
- Entity Framework
- MongoDB


## 💻 Projeto

Este projeto demonstra uma arquitetura robusta e escalável para aplicações .NET 6 que utilizam o MongoDB como banco de dados. Ele incorpora os padrões de projeto MediatR, CQRS e Repository para promover a organização, a testabilidade e a manutenção do código. Além disso, utiliza o FluentValidation para garantir a validação eficiente e consistente dos dados de entrada.


## 🔖 Implementações

- <strong>.NET 6:</strong> Framework de desenvolvimento de alta performance da Microsoft.

- <strong>MongoDB:</strong> Banco de dados NoSQL orientado a documentos, ideal para flexibilidade e escalabilidade.

- <strong>MediatR:</strong> Biblioteca para implementar o padrão Mediator, facilitando a comunicação entre componentes da aplicação, promovendo o baixo acoplamento e a testabilidade.

- <strong>CQRS (Command Query Responsibility Segregation):</strong> Padrão arquitetural que separa as operações de leitura (queries) das operações de escrita (commands), permitindo otimizar cada tipo de operação de forma independente e melhorar a escalabilidade da aplicação.

- <strong>Repository Pattern:</strong> Padrão de projeto que abstrai o acesso a dados, além de facilitar a troca do banco de dados, se necessário.

- <strong>FluentValidation:</strong> Utilizado para criar validações de dados de entrada de forma mais simples, legível e fácil de manter, centralizando as regras de validação em um único lugar.


## 🥇 Como Executar o Projeto

<strong>Pré-requisitos:</strong>
- [.NET 6 SDK instalado](https://dotnet.microsoft.com/pt-br/download)
- [MongoDB instalado e em execução](https://www.mongodb.com/try/download/community)

<strong>Configurar a Connection String:</strong>
- Atualize a ConnectionString no arquivo appsettings.json com as informações de conexão do seu banco de dados MongoDB.

<strong>Documentação da API:</strong>
- A documentação da API pode ser acessada em localhost:{porta}/swagger/index.html
