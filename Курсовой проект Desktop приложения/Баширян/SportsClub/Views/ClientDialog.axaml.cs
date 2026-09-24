using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SportsClub.Views
{
    public partial class ClientDialog : Window
    {
        public ClientDialog()
        {
            InitializeComponent();
        }

        private void OnSaveClick(object? sender, RoutedEventArgs e)
        {
            Close(true);
        }

        private void OnCancelClick(object? sender, RoutedEventArgs e)
        {
            Close(false);
        }
    }
}