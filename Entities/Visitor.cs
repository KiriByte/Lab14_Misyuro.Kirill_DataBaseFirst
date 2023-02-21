using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Entities;

[Table("Visitor")]
public partial class Visitor
{
    [Key]
    public int ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Passport { get; set; }

    [InverseProperty("Visitor")]
    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
