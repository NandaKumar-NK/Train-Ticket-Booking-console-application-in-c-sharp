using System;
using System.Collections.Generic;

namespace JWTAuth.Models;

public partial class Seat
{
    public int? TrainId { get; set; }

    public string? CompartmentType { get; set; }

    public string? CompartmentCount { get; set; }

    public int? TotalSeatCount { get; set; }

    public int SeatId { get; set; }

    public virtual TrainDetail? Train { get; set; }
}
