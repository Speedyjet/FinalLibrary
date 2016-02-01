namespace FinalLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CATEGORYID { get; set; }

        public string CATEGORYNAME { get; set; }
    }
}
