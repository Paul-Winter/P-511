using Avalonia.Controls;
using SportsClub.ViewModels;

namespace SportsClub.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }
    }
}