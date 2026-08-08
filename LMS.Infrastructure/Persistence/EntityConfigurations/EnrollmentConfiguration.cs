using LMS.Domain.Entities.Courses;
using LMS.Domain.Entities.Enrollments;
using LMS.Domain.Entities.Identity.Users;
using LMS.Domain.Entities.Sections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.EntityConfigurations
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentId)
                .IsRequired()
                .HasColumnName("student_id");

            builder.Property(x => x.CourseId)
                .IsRequired()
                .HasColumnName("course_id");

            builder.Property(x => x.SectionId)
                .IsRequired()
                .HasColumnName("section_id");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(x => x.EnrolledAt)
                .IsRequired()
                .HasColumnName("enrolled_at");

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Course>()
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Section>()
                .WithMany()
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}