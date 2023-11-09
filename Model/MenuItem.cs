using System;
using System.Collections.Generic;

namespace McDonaldsAPI.Model;

public partial class MenuItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; }

    public virtual Store Store { get; set; }
}
