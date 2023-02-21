using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Entities;

public partial class Room
{
    [Key]
    public int ID { get; set; }

    public int? Size { get; set; }

    public int? Stars { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
