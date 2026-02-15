# Silofy 💰

**Silofy** é uma plataforma de gestão financeira pessoal baseada na metodologia de "Silos" (envelopes virtuais). O objetivo é permitir que o usuário segmente seu capital em compartimentos específicos, garantindo controle total sobre o fluxo de caixa e metas de economia.

---

## 1. Tecnologias Utilizadas

* **Backend:** .NET 9 (C#) com ASP.NET Core Web API.
* **Frontend:** Angular 19+ (Standalone Components & Signals).
* **Banco de Dados:** PostgreSQL (Hospedado no Neon.tech).
* **ORM:** Entity Framework Core.
* **Hospedagem API:** Render.
* **Hospedagem Front:** Vercel.

---

## 2. Arquitetura

O projeto segue os princípios da **Clean Architecture**, garantindo a separação de preocupações e facilitando a manutenção e testabilidade.

* **Domain:** Entidades, Enums e regras de negócio puras.
* **Application:** Casos de uso e interfaces de serviços.
* **Infrastructure:** Implementação de acesso a dados (EF Core) e integrações externas.
* **API:** Pontos de extremidade (Endpoints) e configurações de entrada.

---

## 3. Como Executar o Projeto

### Pré-requisitos
* SDK do .NET 9
* Node.js (LTS)
* Angular CLI

### Configuração do Backend
1. Navegue até `src/Silofy.Api`.
2. Configure sua Connection String no `appsettings.json` ou User Secrets.
3. Execute as migrations:
    ```bash
    dotnet ef database update
    ```
### Configuração do Frontend
1. Navegue até a pasta do front.
2. Instale as dependências:
    ```bash
    npm install.
    ```
3. Inicie o servidor de desenvolvimento:
    ```bash
    ng s --o.
    ```