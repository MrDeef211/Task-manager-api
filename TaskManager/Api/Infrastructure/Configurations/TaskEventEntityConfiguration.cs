using Api.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations
{
	public class TaskEventEntityConfiguration : IEntityTypeConfiguration<TaskEventEntity>
	{
		public void Configure(EntityTypeBuilder<TaskEventEntity> builder)
		{
			builder.ToTable("TaskEvents");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.EventType)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.EventData)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.IsRequired();

			builder.HasIndex(x => x.TaskId);
		}
	}
}
