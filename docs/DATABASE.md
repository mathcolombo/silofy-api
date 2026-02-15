# 📑 Estrutura de Tabelas (Database Schema) - Silofy

Este documento detalha o esquema físico do banco de dados, tipos de dados e as regras de integridade (constraints) que garantem a consistência do sistema.

---

## 1. Visão Geral (MER)

O esquema foi desenhado para suportar Multi-tenancy (isolamento de usuários) e uma regra rigorosa de Silos: uma categoria não pode se repetir dentro da mesma conta.

---

## 2. Dicionário de Tabelas

### 2.1. Tabela Users

Armazena as credenciais e informações básicas do proprietário dos dados.

| Coluna       | Tipo          | Restrição         | Descrição                        |
|:-------------|:--------------|:------------------|:---------------------------------|
| Id           | UUID          | PK                | Identificador único (EntityBase) |
| Name         | TVARCHAR(100) | TNOT NULL         | TNome completo do usuário        |
| Email        | TVARCHAR(150) | TNOT NULL, UNIQUE | TE-mail para login               |
| PasswordHash | TTEXT         | TNOT NULL         | TSenha criptografada             |
| CreatedAt    | TTIMESTAMP    | TNOT NULL         | TData de criação                 |

### 2.2. Tabela Accounts

Representa as contas físicas ou instituições financeiras.

| Coluna  | Tipo         | Restrição       | Descrição                             |
|:--------|:-------------|:----------------|:--------------------------------------|
| Id      | UUID         | PK              | Identificador único                   |
| Name    | VARCHAR(100) | NOT NULL        | Ex: "Nubank", "Itaú", "Dinheiro Vivo" |
| UserId  | UUID         | FK -> Users(Id) | Dono da conta                         |

### 2.3. Tabela Silos

Representa os compartimentos/envelopes dentro de uma conta.

| Coluna        | Tipo          | Restrição          | Descrição                        |
|:--------------|:--------------|:-------------------|:---------------------------------|
| Id            | UUID          | PK                 | Identificador único              |
| Name          | VARCHAR(100)  | NOT NULL           | Ex: "Reserva", "Viagem", "Livre" |
| CurrentBalance| DECIMAL(18,2) | DEFAULT 0.00       | Saldo planejado neste silo       |
| IsDefault     | BOOLEAN       | DEFAULT FALSE      | Silo para entradas automáticas   |
| AccountId     | UUID          | FK -> Accounts(Id) | Conta física de origem           |

### 2.4. Tabela Categories

Catálogo de rótulos para transações (Padrão vs. Customizadas).

| Coluna     | Tipo            | Restrição    | Descrição                            |
|:-----------|:----------------|:-------------|:-------------------------------------|
| Id         | UUID            | PK           | Identificador único                  |
| Name       | VARCHAR(100)    | NOT NULL     | Ex: "Aluguel", "Mercado"             |
| IsDefault  | BOOLEAN         | DEFAULT TRUE | Se é uma categoria pré-definida      |
| UserId	UUID| FK -> Users(Id) | NULL         | para padrões, Preenchido para custom |

### 2.5. Tabela SiloCategories (Junction Table)

Vincula categorias aos silos com trava de duplicidade por conta.

| Coluna    | Tipo | Restrição              | Descrição                      |
|:----------|:-----|:-----------------------|:-------------------------------|
| Id        | UUID | PK	Identificador único |
| SiloId    | UUID | FK -> Silos(Id)        | O silo que contém a categoria  |
| CategoryId| UUID | FK -> Categories(Id)   | A categoria vinculada          |
| AccountId | UUID | FK -> Accounts(Id)     | Usada para a Unique Constraint |

- Constraint Especial: UNIQUE (AccountId, CategoryId)
- Garante que o usuário não coloque "Mercado" em dois silos da mesma conta.

### 2.6. Tabela Transactions

Registro histórico de toda movimentação financeira.

| Coluna     | Tipo          | Restrição            | Descrição                              |
|:-----------|:--------------|:---------------------|:---------------------------------------|
| Id         | UUID          | PK                   | Identificador único                    |
| Description| TEXT          | NOT NULL             | Motivo da transação                    |
| Amount     | DECIMAL(18,2) | NOT NULL             | Valor monetário                        |
| Type       | INT           | NOT NULL             | Enum: 1-Receita, 2-Despesa, 3-Alocação |
| Date       | TIMESTAMP     | NOT NULL             | Data do registro                       |
| AccountId  | UUID          | FK -> Accounts(Id)   | Conta afetada                          |
| CategoryId | UUID          | FK -> Categories(Id) | Classificação do gasto                 |
| UserId     | UUID          | FK -> Users(Id)      | Filtro de segurança por usuário        |

---

## 3. Índices de Performance Sugeridos

Para garantir que o Silofy responda rápido no Neon, criaremos os seguintes índices:

- IX_Transactions_UserId_Date: Para acelerar a listagem do histórico e gráficos mensais.
- IX_Silos_AccountId: Para somar rapidamente o saldo total da conta (TotalBalance$).
- IX_Categories_UserId_IsDefault: Para carregar a lista de categorias disponível para cada usuário.