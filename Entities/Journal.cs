using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Entities;

[Table("Journal")]
public partial class Journal
{
    [Key]
    public int ID { get; set; }

    public int? VisitorID { get; set; }

    public int RoomID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateStart { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateEnd { get; set; }

    public int EmployeeID { get; set; }

    [ForeignKey("EmployeeID")]
    [InverseProperty("Journals")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("RoomID")]
    [InverseProperty("Journals")]
    public virtual Room Room { get; set; } = null!;

    [ForeignKey("VisitorID")]
    [InverseProperty("Journals")]
    public virtual Visitor? Visitor { get; set; }
}
