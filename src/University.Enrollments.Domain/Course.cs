using System;

namespace University.Enrollments.Domain
{
    /// <summary>
    /// Representa um curso.
    /// Invariantes essenciais:
    /// - CourseId deve ser maior que zero.
    /// - Title não deve ser nulo ou vazio.
    /// - Capacity deve ser maior ou igual a zero.
    /// - MatriculationStart <= MatriculationEnd.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Operações esperadas (esboço documentado — sem implementação neste momento):
        /// </summary>
        /// <remarks>
        /// Enroll(int studentId):
        /// - Deve verificar que <c>studentId &gt; 0</c>.
        /// - Deve validar se a data atual está dentro da janela de matrícula
        ///   definida por <see cref="MatriculationStart"/> e <see cref="MatriculationEnd"/> (inclusiva).
        /// - Deve verificar se ainda existem vagas disponíveis (contadores internos ou consulta a enrollments < Capacity).
        /// - Caso válido, criar/registrar um vínculo (Enrollment) com Status = Enrolled e ajustar contadores.
        /// - Em caso de violação (fora da janela, sem vagas, studentId inválido ou duplicidade), deve falhar (lançar exceção ou retornar resultado de erro).
        ///
        /// Unenroll(int studentId):
        /// - Deve verificar que <c>studentId &gt; 0</c>.
        /// - Deve localizar o vínculo existente entre o estudante e este curso.
        /// - Deve remover o vínculo e atualizar contadores (liberar vaga).
        /// - Se não existir vínculo, comportamento esperado: falhar ou retornar indicação de que nada foi feito.
        ///
        /// Regras de janela e capacidade:
        /// - A matrícula só é permitida enquanto <c>MatriculationStart <= hoje <= MatriculationEnd</c>.
        /// - A matrícula só é permitida enquanto o número de vínculos ativos for menor que <see cref="Capacity"/>.
        /// - Capacidade é um inteiro não-negativo; valores inválidos devem ser prevenidos na camada de criação/validação do agregado.
        ///
        /// Observação: a assinatura das operações (ex.: lançar exceções vs. retornar Result) será definida quando implementarmos a lógica.
        /// </remarks>

        /// <summary>
        /// Identificador do curso (único).
        /// </summary>
    public int CourseId { get; set; }

        /// <summary>
        /// Título do curso.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Capacidade total de vagas do curso.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Data de início da janela de matrícula (inclusiva).
        /// </summary>
        public DateOnly MatriculationStart { get; set; }

        /// <summary>
        /// Data de fim da janela de matrícula (inclusiva).
        /// </summary>
        public DateOnly MatriculationEnd { get; set; }

        // Armazenamento interno unidirecional de enrollments.
        // Mantemos apenas o necessário para garantir unicidade do par (StudentId, CourseId) neste primeiro passo.
        private readonly System.Collections.Generic.List<Enrollment> _enrollments = new();

        /// <summary>
        /// Tenta matricular um estudante neste curso.
        /// Lança <see cref="DomainException"/> quando regras de domínio são violadas.
        /// Regras aplicadas aqui (mínimo necessário):
        /// - studentId > 0
        /// - não permitir duplicidade do par (studentId, CourseId)
        /// - (nota) validações de janela e capacidade serão adicionadas posteriormente
        /// </summary>
        /// <param name="student">Instância do estudante a ser matriculado.</param>
        public void Enroll(Student student)
        {
            if (student == null)
            {
                throw new DomainException("student inválido. Não pode ser nulo.");
            }

            if (student.StudentId <= 0)
            {
                throw new DomainException("student.StudentId inválido. Deve ser maior que zero.");
            }

            // Verifica duplicidade pelo par (StudentId, CourseId)
            bool already = _enrollments.Exists(e => e.Student != null && e.Student.StudentId == student.StudentId && e.Course != null && e.Course.CourseId == this.CourseId && e.Status == EnrollmentStatus.Enrolled);
            if (already)
            {
                throw new DomainException($"Já existe um vínculo ativo para studentId={student.StudentId} no courseId={CourseId}.");
            }

            var enrollment = new Enrollment(student, this, EnrollmentStatus.Enrolled);
            _enrollments.Add(enrollment);
        }

        /// <summary>
        /// Retorna true se existir um vínculo ativo (Status = Enrolled) para o studentId neste curso.
        /// Método público mínimo para permitir verificações em testes sem expor a coleção interna.
        /// </summary>
        /// <param name="studentId">Identificador do estudante.</param>
        public bool HasEnrollment(int studentId)
        {
            return _enrollments.Exists(e => e.Student != null && e.Student.StudentId == studentId && e.Course != null && e.Course.CourseId == this.CourseId && e.Status == EnrollmentStatus.Enrolled);
        }
    }
}
