using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Template.Domain;

namespace API.Template.Infrastructure.Concrete.Mapping
{
	public class TemplateMapping : IEntityTypeConfiguration<ExampleEntity>
	{
		public void Configure(EntityTypeBuilder<ExampleEntity> builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			builder.HasKey(x => x.SampleId);
			builder.Property(e => e.SampleId).ValueGeneratedNever();

			builder.Property(e => e.FirstName)
					.HasMaxLength(250)
					.IsUnicode(false);

			builder.Ignore("SampleCollection");

			builder.OwnsOne(
				x => x.ValueObject,
				a =>
				{
					a.Property(p => p.PrimaryEmail)
						.HasColumnName("PrimaryEmail")
						.HasMaxLength(320)
						.IsUnicode(false);

					a.Property(p => p.AlternateEmail)
						.HasColumnName("AlternateEmail")
						.HasMaxLength(320)
						.IsUnicode(false);

					a.Property(p => p.HomePhone)
						.HasColumnName("HomePhone")
						.HasMaxLength(50)
						.IsUnicode(false);

					a.Property(p => p.WorkPhone)
						.HasColumnName("WorkPhone")
						.HasMaxLength(50)
						.IsUnicode(false);

					a.Property(p => p.CellPhone)
						.HasColumnName("CellPhone")
						.HasMaxLength(50)
						.IsUnicode(false);

				}
			);
		}
	}
}
