using System;
using System.Collections.Generic;

namespace TestCatalogue.Database.SQLModels;

public partial class GoodsContent
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

}
