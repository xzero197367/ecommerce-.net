
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    /// <summary>
    /// Interaction logic for CategoryFromUC.xaml
    /// </summary>
    public partial class CategoryFromUC : UserControl
    {
        //private CategoryHandler categoryHandler;
        public Func<Task> AfterSaveAction { get; set; } = () => Task.CompletedTask;
        public Func<CategoryCreateDto, Task<(bool status, string message)>> onSaveAction { get; set; } = (dto) => Task.FromResult((false, "Error occurred while saving the category from form. Please try again later."));

        public CategoryCreateDto categoryCreateDto { get; set; } = null;

        public CategoryFromUC()
        {
            //categoryHandler = new CategoryHandler();
            InitializeComponent();
        
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(categoryCreateDto != null)
            {
                txtname.Text = categoryCreateDto.Name;
                SetRichTextBoxText(txtdesc, categoryCreateDto.Description);
            }
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

            //bool isSaved = await categoryHandler.CreateCategory(dto);

            var res = await onSaveAction.Invoke(dto);
            if (res.status)
            {
                
                this.txtname.Clear();
                ClearRichTextBox(txtdesc);
                await AfterSaveAction.Invoke();
            }
            //MessageBox.Show(res.message);

        }

        private string SetRichTextBoxText(RichTextBox richTextBox, string text)
        {
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            textRange.Text = text;
            return textRange.Text.Trim();
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
