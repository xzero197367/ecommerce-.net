using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Ecommerce.AdminFront.Pages.Home.sections
{
    public class ViewModel
    {
        public ISeries[] Series { get; set; } 
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
            };
    }
    public partial class AnalyseCardsSection : UserControl
    {
    
        public AnalyseCardsSection()
        {
            InitializeComponent();
       
        }
    }
}

