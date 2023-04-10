using System;
using System.Collections.Generic;

namespace TestCatalogue.Database.SQLModels;

public partial class Good
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public int ContentId { get; set; }
}
