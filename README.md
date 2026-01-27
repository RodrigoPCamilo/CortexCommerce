  # CortexCommerce - BackEnd
  
# Introdução:
 O CortexCommerce é um sistema desenvolvido para gerenciar usuários, preferências de consumo e interações com uma Inteligência Artificial voltada a recomendações com Links de produtos baseando-se no seu perfil com consultas personalizadas.
O projeto foi criado com o objetivo de servir como base para uma aplicação de e-commerce inteligente, integrando dados do usuário com histórico de pesquisas e respostas da IA.

## 🎯 Objetivos:
. Desenvolver uma API REST robusta e escalável

. Gerenciar cadastro, autenticação e perfil de usuários

. Integrar um chatbot com IA

. Armazenar histórico de interações do usuário

. Servir como projeto acadêmico e portfólio profissional

## 📍 Escopo: 
. API REST

. Banco de dados

. Lógica de negócio

. Integração com IA

___

# 🏗️ Arquitetura do Sistema
 O sistema foi desenvolvido utilizando uma arquitetura em camadas, promovendo separação de responsabilidades, facilidade de manutenção e escalabilidade.

## 🧩 Camadas principais:

. API (Controllers): Exposição dos endpoints

. Aplicação: Contém os casos de uso e regras de aplicação

. Domínio: Entidades e regras de negócio

. Repositório: Acesso a dados com Dapper

. Serviços: Regras específicas e integrações externas (IA)

## ⚙️ Funcionalidades:
. Cadastro de usuários

. Autenticação e login

. Definição de preferências (categoria favorita, orçamento médio, loja preferida)

. Integração com IA para perguntas e respostas

. Armazenamento do histórico de pesquisas

___

# 🔩 Configuração do Ambiente

## 💻 Requisitos de Software e Hardware:

Windows 10 ou superior

.NET SDK 8.0

SQL Server

Visual Studio 2022 ou VS Code

Git

## 📥 Instruções de Instalação:

. Clone o repositório:

git clone https://github.com/RodrigoPCamilo/CortexCommerce.git

. Acesse a pasta do projeto:

cd CortexCommerce

. Restaure as dependências:

dotnet restore

. Execute o projeto:

dotnet run

## 🛠️ Configuração do Ambiente de Desenvolvimento:

Configure o arquivo appsettings.json com a string de conexão do banco de dados e as configurações de autenticação.

## 📦 Dependências:

ASP.NET Core Web API

Dapper

SQL Server

Swagger

JWT Authentication

___

# Desenvolvimento

## 📂 Estrutura do Projeto

```text
CortexCommerce
├── CortexCommerce.API
│   ├── Controllers
│   ├── Models
│   ├── Properties
│   ├── appsettings.json
│   ├── Program.cs
│   └── CortexCommerce.API.csproj
│
├── CortexCommerce.Aplicacao
│   ├── Aplicacao
│   ├── DTOs
│   ├── Interfaces
│   └── CortexCommerce.Aplicacao.csproj
│
├── CortexCommerce.Dominio
│   ├── Entidades
│   ├── Enums
│   └── CortexCommerce.Dominio.csproj
│
├── CortexCommerce.Repositorio
│   ├── Configuracoes
│   ├── Contexto
│   ├── Database
│   ├── Interfaces
│   ├── Migrations
│   ├── BaseRepositorio.cs
│   ├── HistoricoPesquisaRepositorio.cs
│   ├── UsuarioRepositorio.cs
│   └── CortexCommerce.Repositorio.csproj
│
└── CortexCommerce.Service
    ├── Interface
    ├── Models
    ├── Services
    └── CortexCommerce.Service.csproj

```
## 🧩 Descrição das Camadas:

. CortexCommerce.API
Responsável por expor os endpoints HTTP da aplicação, receber requisições do front-end e delegar o processamento para a camada de Aplicação.

. CortexCommerce.Aplicacao
Camada responsável pelos casos de uso do sistema.
Contém regras de aplicação, validações, DTOs e coordena a comunicação entre a API, o Domínio, o Repositório e a camada de Serviços.

. CortexCommerce.Dominio
Contém as entidades do sistema, enums e as regras de negócio centrais, sendo independente das demais camadas.

. CortexCommerce.Repositorio
Responsável pela persistência e recuperação de dados, gerenciamento da conexão com o banco de dados e execução de consultas, utilizando Dapper como tecnologia de acesso a dados.

. CortexCommerce.Service
Camada destinada a integrações externas e serviços auxiliares, como o módulo de Inteligência Artificial e comunicação com APIs externas.

___

# API

## 🔗 Documentação da API

A API segue o padrão REST e utiliza métodos HTTP apropriados.

## 👤 Usuário Criar:

<img width="1286" height="907" alt="image" src="https://github.com/user-attachments/assets/6835e913-9414-42f6-9eaa-bc5d96726971" />

## 👤 Usuário Atualizar:

<img width="1308" height="884" alt="image" src="https://github.com/user-attachments/assets/165fb4c3-710d-41ac-b16d-72974076bc4f" />

## 👤 Usuário ObterPorId:

<img width="1285" height="936" alt="image" src="https://github.com/user-attachments/assets/c7aa66a7-ffb8-4f3e-9dba-6d570966f683" />

## 👤 Login Altentificado:

<img width="1300" height="857" alt="image" src="https://github.com/user-attachments/assets/dea6d75a-0e42-4448-90dc-34666f8586d2" />

## 🤖 IA Perguntar:

<img width="1281" height="1076" alt="image" src="https://github.com/user-attachments/assets/781ebad5-c6b5-492a-bd38-99a30fabfe66" />

## 🤖 IA Historico:

<img width="1293" height="949" alt="image" src="https://github.com/user-attachments/assets/510f9852-f9b9-40fa-95d8-551523ec2c68" />

## 📘 Swagger

A documentação completa da API pode ser acessada via Swagger após executar o projeto:

http://localhost:5139/swagger

___

# Interface do Usuário

## 🖥️ Descrição das Funcionalidades da Interface

A interface do usuário (front-end) consome esta API para:

. Login e cadastro de usuários

. Visualização do perfil

. Interação com o chatbot de IA

. Consulta do histórico de pesquisas

___

# Banco de Dados

## 🗄️ Diagrama de Entidade-Relacionamento (ERD)

<img width="1142" height="702" alt="image" src="https://github.com/user-attachments/assets/ec32de08-bd9b-48ce-94f8-f4822364e8b5" />

## 📋 Stored Procedures,Functions e Views:

Criadas na pasta Database para facilitar operações comuns no sistema do Banco de dados

___

# Considerações Finais

## 📘 Lições Aprendidas:

. Importância da separação de camadas

. Boas práticas no desenvolvimento de APIs REST

. Uso do Dapper para performance

. Integração de IA em aplicações reais

## ✅ Melhores Práticas:

. Código limpo e organizado

. Uso de DTOs

. Tratamento de exceções

. Versionamento com Git

## 🚀 Próximos Passos:

. Implementar testes automatizados

. Melhorar segurança da autenticação

. implementação no FronEnd o editar Usuario

___

# Anexos

## 📚 Referências e Recursos Adicionais:

Documentação oficial do .NET

Dapper ORM

Swagger OpenAPI

## 🔗 Links Úteis:

https://learn.microsoft.com/dotnet/

https://swagger.io/

## 👨‍💻 Créditos e Agradecimentos:

Projeto desenvolvido por Rodrigo Prado Camilo

Agradeço a toda equipe da Itera360, por proporcionar o aprendizado necessario para ser um otimo desenvovedor Full-Stack.





