using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LastName { get; set; }

    public int? PositionID { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();

    [ForeignKey("PositionID")]
    [InverseProperty("Employees")]
    public virtual Position? Position { get; set; }
}
