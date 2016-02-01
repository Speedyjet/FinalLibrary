namespace FinalLibrary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookModel : DbContext
    {

        public BookModel()
            : base("name=BookModel")
        {
        }

        public virtual DbSet<BOOK> BOOKS { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
