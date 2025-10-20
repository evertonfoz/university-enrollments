namespace University.Enrollments.Domain
{
    /// <summary>
    /// Representa um estudante.
    /// Invariantes essenciais:
    /// - StudentId deve ser maior que zero.
    /// - Name não deve ser nulo ou vazio.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Identificador do estudante (único).
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Nome completo do estudante.
        /// </summary>
        public string? Name { get; set; }
    }
}
