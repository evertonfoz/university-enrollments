# 23-10-2025 12:00:00 - prompts-session-summary

Resumo dos prompts e pedidos feitos durante a sessão atual.

1. "Verifiquei que em Enrollment, você criou propriedades do tipo int para registrar a associação.\n\nNão estamos pensando ainda em banco de dados, então precisamos focar na OO e termos as propriedades devidamente tipificadas.\n\nPor favor, ajuste isso e valide essa mudança em todo o código da solução."

2. "Em matrículas o estudante e curso são obrigatórios, não podem ser nulos. Corrija as declarações e os códigos que dependem dela.\n\nDe acordo às nossas regras, um estudante poderá ter apenas uma matrícula ativa, porém, ele pode ter outras, que não foram concluídas, como define EnrollmentStatus. Então, precisamos de um id também para a classe de matrícula."

3. "Você criou na classe de matrículas a propriedade Id. Isso fere nossa convenção de nomes de propriedades de id. Veja o padrão que temos em curso e estudante e siga sempre. Registre essa orientação em AGENTS.md para não errarmos nisso novamente."

4. "Seguindo o padrão que temos em Prompts, crie uma nova pasta e documento para nosso chat de agora"


> Observação: Este arquivo foi gerado automaticamente pelo agente para registrar os prompts principais desta sessão. Se quiser que eu inclua mais detalhes (por exemplo, respostas completas, diffs aplicados, ou logs de `dotnet build`/`dotnet test`), diga qual nível de detalhe deseja e eu atualizo o arquivo.
