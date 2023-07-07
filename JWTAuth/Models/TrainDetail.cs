using System;
using System.Collections.Generic;

namespace JWTAuth.Models;

public partial class TrainDetail
{
    public int TrainId { get; set; }

    public string? TrainName { get; set; }

    public string? Sources { get; set; }

    public string? Distination { get; set; }

    public virtual ICollection<BookingDetail> BookingDeatils { get; set; } = new List<BookingDetail>();

    public virtual ICollection<SeatAllocation> SeatAllocations { get; set; } = new List<SeatAllocation>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
