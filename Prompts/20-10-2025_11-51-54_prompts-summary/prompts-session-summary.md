# Prompts — sessão 20-10-2025 11:51:54 (prompts-summary)

Abaixo estão todos os pedidos feitos pelo usuário durante a sessão, reescritos como prompts claros e reutilizáveis (um por linha), em português.

1. Vamos trabalhar com projetos C#. Então use sempre o MCP context7 para buscar documentação C# quando necessário.
2. Crie a solution `University.Enrollments.sln` na raiz do repositório.
3. Crie os projetos:
   - `University.Enrollments.App` (console)
   - `University.Enrollments.Domain` (class library)
   - `University.Enrollments.Tests` (xUnit)
   Adicione-os à solution e valide com `dotnet build`.
4. Adicione referências: `University.Enrollments.App` → `University.Enrollments.Domain`; `University.Enrollments.Tests` → `University.Enrollments.Domain`.
5. Crie `.editorconfig`, `Directory.Build.props`, `global.json` (fixar SDK) e `.gitignore` no root; explique os efeitos dessas configurações.
6. Crie a classe de testes `EnrollmentSpecs` com métodos de teste vazios e comentários TODO (Arrange/Act/Assert).
7. Adicione o enum público `EnrollmentStatus` em `University.Enrollments.Domain` com os valores solicitados.
8. Adicione esboços das entidades `Student`, `Course` e `Enrollment` com comentários XML em português descrevendo invariantes essenciais.
9. Documente em `Course` as operações `Enroll(studentId)` e `Unenroll(studentId)` com suas regras (janela de matrícula, capacidade) sem implementar a lógica ainda.
10. Implemente o mínimo necessário em `Course.Enroll(studentId)` para satisfazer o teste `Enroll_cria_vinculo_e_respeita_unicidade_do_par` seguindo TDD: validar `studentId > 0`, garantir unicidade do vínculo, criar `Enrollment` internamente e lançar `DomainException` para violações.
11. Mantenha navegação unidirecional (Course → Enrollments) e adicione um helper `HasEnrollment(int)` para asserções nos testes sem expor coleções internas.
12. Aplique correções de estilo conforme os analisadores: sempre usar chaves em estruturas de controle (IDE0011), substituir `var` por tipos explícitos quando o analisador recomendar (IDE0008) e usar `target-typed new` quando aplicável (IDE0090).
13. Atualize `AGENTS.md` com convenções, permissões do agente, padrão TDD obrigatório e as regras de estilo mencionadas.
14. Escreva o teste xUnit `Enroll_cria_vinculo_e_respeita_unicidade_do_par` antes da implementação (TDD) e rode `dotnet test` até passar.
15. Quando eu pedir, corrija ocorrências de `var` por tipos explícitos em arquivos do domínio e testes onde IDE0008 recomenda.
16. Crie um arquivo `ChangeLogs/<data_hora>_<sufixo>/<sufixo>.md` com um resumo completo da sessão atual (data/hora, objetivo, ações, comandos executados, resultados de build/test, arquivos alterados, observações, próximos passos e comando sugerido de commit opcional).
17. Atualize `AGENTS.md` para incluir a estratégia de ChangeLogs (pasta `ChangeLogs`, formato `DD-MM-YYYY_HH-MM-SS_sufixo`, conteúdo mínimo e prática opcional de commit).
18. Crie o ChangeLog para esta sessão em `ChangeLogs/20-10-2025_11-44-59_tdd-domain-init-summary/tdd-domain-init-summary.md` com o conteúdo detalhado da conversa.
19. Faça um commit bem documentado contendo as alterações (AGENTS.md, ChangeLog, arquivos de projeto e de domínio) com mensagem sugerida: `chore(changelog): add ChangeLog 20-10-2025_11-44-59_tdd-domain-init-summary; update AGENTS.md`.
20. Faça push do commit para o remoto (`origin/main`).
21. Crie uma pasta `Prompts/<data_hora>_<sufixo>/prompts-session-summary.md` contendo a lista de prompts desta sessão (o que você está fazendo agora).
22. Anime-me para escolher o próximo passo: escrever testes TDD para janela de matrícula (`Enroll_fora_da_janela_deve_falhar`) ou para capacidade (`Enroll_sem_vagas_deve_falhar`).

---

_Fim do arquivo de prompts gerado automaticamente pelo agente._
