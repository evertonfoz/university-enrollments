using System;

namespace University.Enrollments.Domain
{
    /// <summary>
    /// Exceção base para regras de domínio do agregado de matrículas.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
