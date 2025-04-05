Guia Rápido da Arquitetura: Receiver + Command

Este guia explica a arquitetura usada no projeto, baseada exclusivamente em Receivers e Commands, com inspiração em padrões conhecidos do mercado como CQRS e DDD, mas com uma abordagem direta, padronizada e controlada.

Visão Geral

A aplicação é organizada em torno de duas abstrações principais:

Command: representa uma intenção (comando) que contém os dados necessários para executar uma ação.

Receiver: executa a lógica associada ao Command. Pode ser:

Receiver pequeno: executa uma ação específica (ex: inserir usuário).

Receiver orquestrador: coordena várias operações, chamando outros receivers.

Tudo na aplicação é executado por um Receiver que recebe um Command.

Benefícios da Abordagem

Reutilização de lógica através de Receivers pequenos

Controle total sobre fluxo e transações

Facilita testes e medição de desempenho

Evita abstrações desnecessárias

Organiza bem a lógica da aplicação

Comparativo com o Padrão Command Tradicional

Conceito

Padrão Tradicional

Nossa Abordagem

Onde estão os dados?

No próprio Command

No próprio Command

Quem executa?

CommandHandler

Receiver

Pode chamar outros?

Normalmente não

Sim, Receivers orquestradores

Como organizar domínio?

Livre ou com DDD

Usamos entidades com validações

Padrão de Implementação

// Exemplo de Command
public class Y_UserCrudCommand {
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}

// Exemplo de Receiver pequeno
public class InsertY_UserReceiver {
    private readonly IRepositoryUser _repo;

    public InsertY_UserReceiver(IRepositoryUser repo) {
        _repo = repo;
    }

    public State Execute(Y_UserCrudCommand command) {
        // Validações, conversão, chamada ao repo
        // Retorna State com resultado
    }
}

// Exemplo de Receiver orquestrador
public class CreateUserWithCompanyReceiver {
    public State Execute(CompositeCommand comand) {
        _unitOfWork.BeginTran();

        var userState = new InsertY_UserReceiver(_repoUser).Execute(new Y_UserCrudCommand { ... });
        var usuario = (Y_UserEntity)userState.Data;

        var companyCommand = new Y_CompanyCrudCommand { UserIDAdmin = usuario.Id };
        var companyState = new InsertY_CompanyReceiver(_repoCompany).Execute(companyCommand);

        _unitOfWork.Commit();

        return new State(201, "Usuário e empresa criados", comand);
    }
}

Integração com Conceitos de Mercado

CQRS: já está sendo seguido. Commands (escrita), e Queries (vão seguir mesma estrutura com Receivers de leitura).

DDD: as entidades já possuem suas próprias regras, separadas da camada de aplicação.

Plugabilidade com MediatR (opcional):

Commands podem implementar IRequest<State>

Receivers viram IRequestHandler<Command, State>

Conclusão

Esta arquitetura é simples, padronizada e altamente reutilizável. Ao adotar Receivers como a unidade de execução, você tem controle total sobre a aplicação sem abrir mão de boas práticas como separação de responsabilidades, testes e composição de funcionalidades.

Tudo é um Receiver. Receivers pequenos fazem coisas. Receivers grandes orquestram coisas.

