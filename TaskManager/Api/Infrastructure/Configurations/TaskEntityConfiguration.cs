using Api.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations
{
	public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
	{
		public void Configure(EntityTypeBuilder<TaskEntity> builder)
		{
			builder.ToTable("Tasks");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Description)
				.HasMaxLength(1000);

			builder.Property(x => x.Status)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.IsRequired();
		}
	}
}
