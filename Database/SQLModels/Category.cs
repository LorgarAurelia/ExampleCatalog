using System;
using System.Collections.Generic;

namespace TestCatalogue.Database.SQLModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
