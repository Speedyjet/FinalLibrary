namespace FinalLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOKS")]
    public partial class BOOK
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BOOKID { get; set; }

        [Required]
        [StringLength(30)]
        public string BOOKNAME { get; set; }

        [StringLength(30)]
        public string AUTHOR { get; set; }

        public int ISBN { get; set; }
    }
}
