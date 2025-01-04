# Tarefa API

## Descrição
Este projeto é uma API para gerenciamento de tarefas e itens de tarefas. A solução é dividida em duas camadas principais: `Tarefa.Api` e `Dados`.

## Camadas

### Tarefa.Api
Esta camada contém a API Web que expõe endpoints para manipulação de tarefas e itens de tarefas. Utiliza os seguintes pacotes:
- `AutoMapper`: Para mapeamento de objetos.
- `Microsoft.EntityFrameworkCore`: Para acesso ao banco de dados.
- `Microsoft.EntityFrameworkCore.SqlServer`: Provedor do Entity Framework Core para SQL Server.
- `Microsoft.EntityFrameworkCore.Tools`: Ferramentas do Entity Framework Core.
- `Swashbuckle.AspNetCore`: Para documentação da API com Swagger.

### Dados
Esta camada contém a lógica de acesso aos dados e as entidades do domínio. Utiliza os seguintes pacotes:
- `AutoMapper`: Para mapeamento de objetos.
- `Microsoft.EntityFrameworkCore`: Para acesso ao banco de dados.
- `Microsoft.EntityFrameworkCore.SqlServer`: Provedor do Entity Framework Core para SQL Server.
- `Microsoft.EntityFrameworkCore.Tools`: Ferramentas do Entity Framework Core.

## Banco de Dados
O banco de dados utilizado é o SQL Server. A string de conexão está configurada para se conectar a um servidor local com as seguintes credenciais:
- **Data Source**: fc-p\local
- **Initial Catalog**: Tarefas
- **User ID**: sa
- **Password**: qM1t$up|iC74

## Endpoints
A API expõe os seguintes endpoints:

### TarefaController
- `POST /Adicionar`: Adiciona uma nova tarefa.
- `PUT /AtualizarTarefa`: Atualiza uma tarefa existente.
- `DELETE /Excluir`: Exclui uma tarefa pelo ID.
- `GET /BuscarTarefaPeloId`: Busca uma tarefa pelo ID.
- `GET /ListarTarefas`: Lista todas as tarefas.

### ItenTarefaController
- `POST /AdicionarItemTarefa`: Adiciona um novo item de tarefa.
- `PUT /AtualizarItemTarefa`: Atualiza um item de tarefa existente.
- `DELETE /ExcluirItemTarefa`: Exclui um item de tarefa.
- `GET /BuscarPeloId`: Busca um item de tarefa pelo ID.
- `GET /ListarTodosOsItensDeTarefa`: Lista todos os itens de tarefa.
- `GET /ListarItenDeUmaTarefaPeloIdTarefa`: Lista os itens de uma tarefa pelo ID da tarefa.

## Configuração do AutoMapper
O AutoMapper é configurado no arquivo `Program.cs` da camada `Tarefa.Api` para mapear as entidades e os ViewModels correspondentes.

## Configuração do Entity Framework Core
O Entity Framework Core é configurado no arquivo `Program.cs` da camada `Tarefa.Api` para usar o SQL Server como provedor de banco de dados. As entidades `Tarefa` e `ItemTarefa` são mapeadas no contexto `ContextoBase`.

## Executando a Aplicação
Para executar a aplicação, utilize o Visual Studio e configure o projeto `Tarefa.Api` como projeto de inicialização. Em seguida, execute a aplicação pressionando `F5` ou `Ctrl+F5`.
