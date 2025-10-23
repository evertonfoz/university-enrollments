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
    /// Identificador da matrícula.
    /// </summary>
    public int EnrollmentId { get; set; }

        /// <summary>
        /// Identificador do estudante.
        /// </summary>
        public Student Student { get; private set; }

        /// <summary>
        /// Identificador do curso.
        /// </summary>
        public Course Course { get; private set; }

        /// <summary>
        /// Status atual do vínculo.
        /// </summary>
        public EnrollmentStatus Status { get; private set; }

        /// <summary>
        /// Data em que ocorreu a matrícula (se aplicável).
        /// </summary>
        public DateOnly EnrolledOn { get; private set; }

        public Enrollment(Student student, Course course, EnrollmentStatus status)
        {
            Student = student ?? throw new DomainException("student inválido. Não pode ser nulo.");
            Course = course ?? throw new DomainException("course inválido. Não pode ser nulo.");
            if (Student.StudentId <= 0)
                throw new DomainException("student.StudentId inválido. Deve ser maior que zero.");
            if (Course.CourseId <= 0)
                throw new DomainException("course.CourseId inválido. Deve ser maior que zero.");

            Status = status;
            EnrolledOn = DateOnly.FromDateTime(DateTime.UtcNow);
        }
    }
}
