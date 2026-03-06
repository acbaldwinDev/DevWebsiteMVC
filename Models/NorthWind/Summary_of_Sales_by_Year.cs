using System;
using System.Collections.Generic;

namespace DevWebsiteMVC.Models.NorthWind;

public partial class Summary_of_Sales_by_Year
{
    public DateTime? ShippedDate { get; set; }

    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
