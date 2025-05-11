
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
        private CategoryHandler categoryHandler;
        public Action AfterSaveAction { get; set; } = () => { };
        public CategoryFromUC()
        {
            categoryHandler = new CategoryHandler();
            InitializeComponent();
        
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

            bool isSaved = await categoryHandler.CreateCategory(dto);
            if (isSaved)
            {
                MessageBox.Show("successuful added");
                this.txtname.Clear();
                ClearRichTextBox(txtdesc);
                AfterSaveAction.Invoke();
            }
            else
            {
                MessageBox.Show($"Eroorrrrrrrrr:");
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
