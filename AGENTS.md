# AGENTS — Orientações para interagir com o assistente de código

## Objetivo

Este arquivo descreve convenções, permissões e informações úteis que aceleram e melhoram a precisão das suas solicitações quando você pede ao assistente (agente) para trabalhar neste repositório C# (.NET). Siga estas orientações ao formular pedidos para obter respostas e mudanças de código mais rápidas e corretas.

## 1) Contexto do repositório

- Projeto: `university-enrollments`
- Estrutura principal criada pelo assistente:
  - `University.Enrollments.sln`
  - `src/University.Enrollments.App` (Console app)
  - `src/University.Enrollments.Domain` (Class library)
  - `test/University.Enrollments.Tests` (xUnit)
- SDK .NET usado: definido em `global.json` (ex.: `9.0.201`)
- Regras de qualidade: `.editorconfig`, `Directory.Build.props`, `.gitignore`

## 2) Permissões e ações que o assistente pode executar (autorizadas)

Quando você solicita uma mudança, o assistente pode automaticamente executar (sem pedir confirmação extra):

- Criar/editar arquivos fonte e de teste em C# dentro do repositório.
- Rodar comandos locais do `dotnet` para criar projetos, restaurar, compilar e executar testes (`dotnet new`, `dotnet sln add`, `dotnet restore`, `dotnet build`, `dotnet test`).
- Adicionar arquivos de configuração (`.editorconfig`, `global.json`, `Directory.Build.props`, `.gitignore`).
- Executar pequenas correções incrementais e validar com builds/tests locais.

Se houver algo que você não quer que eu execute automaticamente (por exemplo, commits, pushes, ou executar scripts externos), diga explicitamente.

## 3) Convenções e expectativas de design (C# / DDD leves)

- Organização: `src/` para projetos de produção, `test/` para testes.
- Projetos usam SDK-style csproj e target .NET 9 (configurável via `global.json`).
- Domain: preferir modelos imutáveis quando fizer sentido; exponha APIs através de métodos (ex.: `Course.Enroll(studentId)`) e mantenha navegação unidirecional por padrão (ex.: Course → Enrollments) a menos que solicitado o oposto.

### Convenção de nomes para identificadores (IDs)

- Para manter consistência em todo o domínio, use o sufixo `Id` no nome da propriedade identificadora em todas as entidades e objetos de valor.
- Exemplos: `Student.StudentId`, `Course.CourseId`, `Enrollment.EnrollmentId`.
- Evite nomes genéricos como `Id` sozinho; sempre prefira o nome composto que identifica claramente a entidade.
- Tratamento de erros de domínio: use `DomainException` para violações de regra; podemos adotar um tipo `Result<T>` mais tarde se preferir.
- Testes: xUnit com testes pequenos e determinísticos. Nomeie testes em português seguindo o padrão: `Action_expectedResult_conditions` (ex.: `Enroll_sem_vagas_deve_falhar`).

## 4) Padrões de testes e validação

- Cada alteração de comportamento deve vir acompanhada de um teste que falhe antes e passe depois.
- Testes de unidade devem ser rápidos (sem I/O). Para integrações, use projetos separados com sinalização clara.
- Quando pedir para implementar uma regra, indique se deseja primeiro o teste (TDD) ou a implementação imediata.

## 5) Mensagens de exceção e validação

- Use mensagens claras e suficientes para debug rápido (ex.: `"studentId inválido. Deve ser maior que zero."`).
- Exceções de domínio: `DomainException` (classificada); para validações de input podemos usar `ArgumentException` quando apropriado.

## 6) Como formular pedidos efetivos (exemplos)

Inclua estes pontos sempre que possível:

- Objetivo claro (ex.: `"Implemente Enroll() com verificação de capacidade e janela de matrícula"`).
- Escopo mínimo aceitável (ex.: `"faça o mínimo para passar um teste específico X"`).
- Preferência por TDD ou implementação direta (ex.: `"prefiro que você escreva o teste primeiro"`).
- Restrições (ex.: `"mantenha navegação unidirecional"`, `"não adicione EF Core ainda"`).
- Arquivos de referência relevantes ou nomes de testes já existentes.

Exemplo de prompt bom:

```text
Implemente o mínimo necessário em `Course.Enroll(studentId)` para passar apenas o teste `Enroll_cria_vinculo_e_respeita_unicidade_do_par`.
Mantenha navegação unidirecional. Lance `DomainException` com mensagens claras em caso de violação.
Depois rode `dotnet test` e informe o resultado.
```

## 7) Checklist mínimo que o agente seguirá antes de fazer mudanças

- Ler arquivos relevantes (`csproj`, testes, classes do domínio).
- Atualizar o todo-list interno antes de mudanças.
- Aplicar mudanças incrementais e rodar `dotnet build` e `dotnet test`.
- Reportar resultados e próximos passos.

## 8) Convenções de commits (se autorizar commits automáticos)

Sugestão: use mensagens curtas e imperativas em português, ex:

- `feat(domain): implementar Course.Enroll com verificação de unicidade`
- `test: adicionar EnrollmentSpecs.Enroll_cria_vinculo...`

## 9) Quando envolver mudanças de design mais profundas

Se a solicitação requer arquitetura, persistência, ou bibliotecas externas (EF Core, MediatR), o agente pedirá confirmação e apresentará opções com trade-offs antes de implementar.

## 10) Contato e revisões

- Depois de qualquer grande mudança, peça uma revisão de código manual e testes adicionais.

## Convenção obrigatória: arquivos Markdown

- Todo arquivo com extensão `.md` neste repositório deve seguir marcação Markdown válida:
  - Usar `#`/`##`/... para títulos e subtítulos.
  - Usar blocos de código com três crases (```), especialmente para trechos de código e comandos do terminal.
  - Delimitar caminhos de arquivo e símbolos (por exemplo `Course.Enroll`) com acentos graves (`).
  - Manter linhas de título e listas com formatação consistente.

## Estilo de código adicional

- Sempre use chaves (`{ }`) em estruturas de controle (`if`, `else`, `for`, `while`, etc.), mesmo para blocos de uma única linha. Isso evita ambiguidades e facilita a manutenção. IDEs como Visual Studio e VS Code podem sugerir essa correção (IDE0011).

- Prefira simplificações modernas do C# quando apropriado, por exemplo `target-typed new` (substituir `new Type(...)` por `new()` quando o tipo já é conhecido no contexto) — segue a regra do analisador IDE0090.

Exemplo mínimo aceitável de um arquivo `.md`:

```markdown
# Título

Alguma descrição.

## Exemplos

```bash
dotnet build
```

```csharp
// exemplo de código
public void Foo() { }
```
```

## Observação final

Salve este arquivo como `AGENTS.md` na raiz do repositório. Ajustes futuros nas convenções podem ser solicitados a qualquer momento.

## Implementações futuras recomendadas

Estas recomendações registram decisões e "dicas" encontradas no código durante desenvolvimento e devem ser implementadas corretamente em passos futuros:

- Implementar validações de janela de matrícula e capacidade no método `Course.Enroll(studentId)`, garantindo que `MatriculationStart <= hoje <= MatriculationEnd` e que o número de vínculos ativos não ultrapasse `Capacity`.
- Manter a navegação unidirecional (Course → Enrollments) onde fizer sentido, mas encapsular o armazenamento de `Enrollment` de forma robusta (por exemplo, invariantes no agregado, métodos que lançam `DomainException` para violações de regra).
- Usar terminologia de domínio consistente nas mensagens e comentários (por exemplo: usar "vínculo" em português ao invés de "enrollment" misturado), para melhorar clareza em logs/exceções.

Registre essas melhorias como issues/tarefas quando for planejar a próxima iteração do domínio.

## ChangeLogs — estratégia de documentação de conversas e mudanças

Para manter um histórico legível das conversas e das ações executadas pelo agente, siga esta estratégia de ChangeLogs:

- Estrutura de pastas: crie uma pasta no root chamada `ChangeLogs`.
- Para cada sessão/conversa relevante, crie um subdiretório com o formato: `DD-MM-YYYY_HH-MM-SS_sufixo`, onde o horário está no padrão brasileiro (24h) e `sufixo` é um resumo curto e legível do conteúdo (ex.: `tdd-domain-init-summary`).
- Dentro do subdiretório, crie um arquivo Markdown com o nome do `sufixo`, por exemplo `tdd-domain-init-summary.md`.

Conteúdo mínimo recomendado para cada ChangeLog (no arquivo `.md`):

1. Cabeçalho com data e hora (no padrão DD-MM-YYYY HH:MM:SS) e o sufixo usado.
2. Objetivo da sessão (o que se pretendia alcançar).
3. Lista cronológica de ações realizadas (criação de soluções/projetos, arquivos adicionados/alterados, comandos `dotnet` executados e resultados relevantes).
4. Resultados das validações (build, testes e seu resumo: total/failed/passed).
5. Arquivos mais relevantes criados/alterados (lista curta com caminhos).
6. Observações, decisões de design e próximos passos recomendados.
7. (Opcional) Comando sugerido de commit se desejar persistir o ChangeLog no repositório Git.

Prática opcional de commit

- Se desejar que o agente crie um commit automático com o ChangeLog, inclua uma instrução explícita no pedido. Exemplo de mensagem sugerida: `chore(changelog): add conversation changelog DD-MM-YYYY_sufixo`.
- Por padrão o agente não fará commits sem autorização explícita.

Essa convenção torna fácil localizar resumos de sessões passadas e automatizar a geração de relatórios de progresso.

## Prompts — estratégia de arquivamento de pedidos

Para facilitar auditoria e reuso das solicitações feitas ao agente, registre os prompts recebidos em uma pasta `Prompts` no root.

- Estrutura de pastas: crie `Prompts` na raiz do repositório.
- Para cada sessão, crie um subdiretório com o formato: `DD-MM-YYYY_HH-MM-SS_sufixo` (padrão brasileiro). Use um sufixo curto e descritivo, por exemplo `prompts-summary`.
- Dentro do subdiretório, crie um arquivo Markdown `prompts-session-summary.md` contendo todos os pedidos do usuário reescritos como prompts claros (um por linha), em português.

Conteúdo mínimo do arquivo de prompts:

1. Cabeçalho com data/hora da sessão.
2. Lista dos prompts (um por linha) em português, preferencialmente reutilizáveis.
3. Referência ao ChangeLog correspondente (se aplicável).

Por padrão, o agente não commit/pushará automaticamente esses arquivos ao repositório a menos que o usuário autorize explicitamente. Quando autorizado, o agente criará um commit com mensagem clara e fará push para o branch solicitado.

