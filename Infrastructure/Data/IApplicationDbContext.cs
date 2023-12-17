using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Prop> Props { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DNASequence> DNASequences { get; set; }
        public DbSet<CrisprOutViewModel> CrisprOutViewModels { get; set; }
    }
}