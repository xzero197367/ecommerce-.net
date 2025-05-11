

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ecommerce.DTOs
{
   public class CategoryCreateDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class CategoryDto : INotifyPropertyChanged
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ProductDto> Products { get; set; }
        public int ProductCount => Products?.Count ?? 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
