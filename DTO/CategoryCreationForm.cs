using TestCatalogue.Database.SQLModels;

namespace TestCatalogue.DTO
{
    public class CategoryCreationForm
    {
        private List<CategorySpecificationsField> _models;
        public string CategoryName { get; set; } 
        public string[] CategoryFields { get; set; }


        public List<CategorySpecificationsField> ConvertToModels()
        {
            _models = new();
            foreach (var item in CategoryFields)
            {
                _models.Add(new CategorySpecificationsField() { Name = item });
            }

            return _models;
        }
    }
}
