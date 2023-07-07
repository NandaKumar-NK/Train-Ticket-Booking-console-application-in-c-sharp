using System;
using System.Collections.Generic;

namespace JWTAuth.Models;

public partial class SeatAllocation
{
    public int? TrainId { get; set; }

    public string? CompartmentType { get; set; }

    public string SeatStatus { get; set; } = null!;

    public DateTime? TDate { get; set; }

    public int Fare { get; set; }

    public int? SeatNo { get; set; }

    public int CompartmentId { get; set; }

    public virtual TrainDetail? Train { get; set; }
}
