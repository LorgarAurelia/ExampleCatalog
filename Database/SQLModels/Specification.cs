using System;
using System.Collections.Generic;

namespace TestCatalogue.Database.SQLModels;

public partial class Specification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int ContentId { get; set; }
}
