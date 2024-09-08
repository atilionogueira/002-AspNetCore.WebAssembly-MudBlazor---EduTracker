using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ucode.Core.Models;

namespace Ucode.Api.Data.Mappings
{
    public class ControleAlunoMappings : IEntityTypeConfiguration<ControleAluno>
    {
        public void Configure(EntityTypeBuilder<ControleAluno> builder)
        {
            builder.ToTable("ControleAluno");

            builder.HasKey(x => x.Id);

            builder.Property(ca => ca.Data)
               .IsRequired(true);

            builder.Property(ca => ca.Resumo)
                .IsRequired(true)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            builder.Property(ca => ca.UserId)
                .IsRequired(true)
                .HasMaxLength(160)
                .HasColumnType("varchar(160)");          
           
        }
    }
}
