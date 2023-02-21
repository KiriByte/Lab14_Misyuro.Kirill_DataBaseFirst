using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Entities;

[Table("Position")]
public partial class Position
{
    [Key]
    public int ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PositionName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Salary { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Rate { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
