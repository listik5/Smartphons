using System;
using System.Collections.Generic;

namespace Smartphons.Models;

public partial class Smartfon
{
    public string SName { get; set; } = null!;

    public double Price { get; set; }

    public string Brend { get; set; } = null!;

    public double Diam { get; set; }

    public double Ozy { get; set; }

    public double Chast { get; set; }
}
