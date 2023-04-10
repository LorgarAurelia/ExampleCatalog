using System;
using System.Collections.Generic;

namespace TestCatalogue.Database.SQLModels;

public partial class CategorySpecificationsField
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
}
