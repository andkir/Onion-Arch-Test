namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SportType")]
    public partial class SportType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SportComplexId { get; set; }

        public virtual SportComplex SportComplex { get; set; }
    }
}
