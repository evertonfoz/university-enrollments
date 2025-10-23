using System;
using Xunit;

namespace University.Enrollments.Tests
{
    public class EnrollmentSpecs
    {
        [Fact]
        public void Enroll_cria_vinculo_e_respeita_unicidade_do_par()
        {
            // Arrange
            University.Enrollments.Domain.Course course = new University.Enrollments.Domain.Course
            {
                CourseId = 100,
                Capacity = 10,
                MatriculationStart = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                MatriculationEnd = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(10))
            };
            var student = new University.Enrollments.Domain.Student
            {
                StudentId = 42,
                Name = "Test Student"
            };

            // Act - primeiro enroll
            course.Enroll(student);

            // Assert - vínculo criado
            Assert.True(course.HasEnrollment(student.StudentId));

            // Act/Assert - segundo enroll com mesmo student deve falhar por unicidade
            University.Enrollments.Domain.DomainException ex = Assert.Throws<University.Enrollments.Domain.DomainException>(() => course.Enroll(student));
            Assert.Contains("vínculo ativo", ex.Message);
        }

        [Fact]
        public void Enroll_fora_da_janela_deve_falhar()
        {
            // Arrange: TODO - preparar curso com janela fora do período
            // Act: TODO - tentar enroll
            // Assert: TODO - verificar que ocorreu falha/exception
        }

        [Fact]
        public void Enroll_sem_vagas_deve_falhar()
        {
            // Arrange: TODO - preparar curso com vagas esgotadas
            // Act: TODO - tentar enroll
            // Assert: TODO - verificar que ocorreu falha/exception
        }

        [Fact]
        public void Unenroll_remove_vinculo_e_atualiza_contadores()
        {
            // Arrange: TODO - preparar enrollment existente
            // Act: TODO - executar unenroll
            // Assert: TODO - verificar remoção e atualização de contadores (vagas disponíveis)
        }

        [Fact]
        public void Conclusao_transiciona_para_Completed_quando_criterios_ok()
        {
            // Arrange: TODO - preparar enrollment que cumpre critérios de conclusão
            // Act: TODO - marcar como concluído
            // Assert: TODO - verificar transição de estado para Completed
        }

        [Fact]
        public void Transicoes_invalidas_devem_ser_barradas()
        {
            // Arrange: TODO - preparar enrollment em estado onde transição é inválida
            // Act: TODO - tentar realizar transição inválida
            // Assert: TODO - verificar que transição foi rejeitada (exception ou resultado)
        }

        [Fact]
        public void Equality_baseada_em_studentId_courseId()
        {
            // Arrange: TODO - criar duas instâncias com mesmo studentId e courseId e outra com ids diferentes
            // Act: TODO - comparar igualdade
            // Assert: TODO - verificar que igualdade usa studentId+courseId
        }

        [Fact]
        public void Navegabilidade_unidirecional_cobre_casos_basicos()
        {
            // Arrange: TODO - preparar objetos relacionados (Student -> Enrollment)
            // Act: TODO - navegar pelas relações onde aplicável
            // Assert: TODO - garantir que apenas navegação unidirecional é possível e consistente
        }
    }
}
