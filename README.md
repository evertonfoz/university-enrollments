# university-enrollments

Repositório de exemplo para domínio leve de matrículas universitárias.

## Visão geral

Projeto didático para modelar domínio de matrícula (Enrollments) em C# (.NET 9). Contém um projeto de domínio, um app console de exemplo e testes unitários com xUnit.

Estrutura principal:

- `University.Enrollments.sln` — solução .NET
- `src/University.Enrollments.Domain` — projeto de domínio (classes do modelo)
- `src/University.Enrollments.App` — aplicação de demonstração/runner
- `test/University.Enrollments.Tests` — testes xUnit
- `AGENTS.md` — orientações para o assistente/colaborador automático
- `Prompts/` — histórico de prompts de sessões com o agente
- `ChangeLogs/` — resumos de sessões e mudanças aplicadas pelo agente

## Requisitos

- .NET 9 SDK (versão definida em `global.json`).

## Como construir

```bash
dotnet restore
dotnet build
```

## Como rodar testes

```bash
dotnet test
```

## Conveções e boas práticas (resumo)

- Organização: `src/` para código de produção e `test/` para testes.
- Naming de identificadores: use o sufixo `Id` composto (ex.: `Student.StudentId`, `Course.CourseId`, `Enrollment.EnrollmentId`). Evite `Id` genérico.
- Dominío / DDD leves:
  - Preferir imutabilidade quando fizer sentido.
  - Manter navegação unidirecional por padrão (ex.: `Course` contém `Enrollment`s, não o contrário).
  - Use `DomainException` para violações de regras de negócio.
- Testes: xUnit, nomes em português usando padrão `Action_expectedResult_conditions`.
- Estilo de código: sempre use chaves `{ }` em estruturas de controle. Prefira `target-typed new` quando apropriado.

## AGENTS e automações

Veja `AGENTS.md` para orientações detalhadas sobre o que o agente (assistente) pode e deve fazer. Use a pasta `Prompts/` para arquivar as sessões com o agente e `ChangeLogs/` para resumos de mudanças.

## Contribuindo

1. Abra uma issue descrevendo a mudança pretendida.
2. Crie um branch com nome descritivo (`feat/...`, `fix/...`).
3. Faça mudanças e adicione testes se aplicável.
4. Rode `dotnet build` e `dotnet test` antes de abrir PR.

## Próximos passos sugeridos

- Implementar regras de janela de matrícula e capacidade no `Course.Enroll`.
- Tornar `Enrollment.EnrollmentId` somente leitura e adicionar factory para criação (se integrar persistência futuramente).
- Adicionar mais testes de comportamento (validações do construtor, transições de estado de `EnrollmentStatus`).

---

Se quiser que eu inclua instruções específicas de IDE (VS Code / Visual Studio) ou um badge de CI, eu adiciono na sequência.
