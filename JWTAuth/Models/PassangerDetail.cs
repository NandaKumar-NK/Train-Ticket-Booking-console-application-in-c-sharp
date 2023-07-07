using System;
using System.Collections.Generic;

namespace JWTAuth.Models;

public partial class PassangerDetail
{
    public int PassId { get; set; }

    public string? PassangerEmailid { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<BookingDetail> BookingDeatils { get; set; } = new List<BookingDetail>();
}
