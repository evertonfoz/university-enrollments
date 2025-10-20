using System;

namespace University.Enrollments.Domain
{
    /// <summary>
    /// Representa um vínculo (matrícula) entre Student e Course.
    /// Invariantes essenciais:
    /// - StudentId e CourseId devem ser maiores que zero.
    /// - Status deve ser um valor válido de <see cref="EnrollmentStatus"/>.
    /// - EnrolledOn representa a data em que o estudante foi matriculado (se aplicável).
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Identificador do estudante.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Identificador do curso.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Status atual do vínculo.
        /// </summary>
        public EnrollmentStatus Status { get; set; }

        /// <summary>
        /// Data em que ocorreu a matrícula (se aplicável).
        /// </summary>
        public DateOnly EnrolledOn { get; set; }
    }
}
