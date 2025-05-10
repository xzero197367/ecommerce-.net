
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using Mapster;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    /// <summary>
    /// Interaction logic for CategoryFromUC.xaml
    /// </summary>
    public partial class CategoryFromUC : UserControl
    {
        private readonly ICategoryServices _categoryService;
        public CategoryFromUC()
        {
            InitializeComponent();
            var container = AutoFac.Inject();
            _categoryService = container.Resolve<ICategoryServices>();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(GetRichTextBoxText(txtdesc)))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            var dto = new CategoryCreateDto
            {
                Name = txtname.Text.Trim(),
                Description = GetRichTextBoxText(txtdesc),
            };

            try
            {
                await _categoryService.CreateCategoryAsync(dto);
                MessageBox.Show("successuful added");
                this.txtname.Clear();
                ClearRichTextBox(txtdesc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroorrrrrrrrr: {ex.Message}");
            }
        }

        private string GetRichTextBoxText(RichTextBox richTextBox)
        {
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text.Trim();
        }

        private void ClearRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.Document.Blocks.Clear();
        }
    }
}
