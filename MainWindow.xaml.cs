using System;
using System.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DistanceTextBox.Text) || string.IsNullOrWhiteSpace(TicketsTextBox.Text))
            {
                ResultTextBlock.Text = "Пожалуйста, заполните все поля.";
                return;
            }

            if (!PlatskartRadio.IsChecked.Value && !KupeRadio.IsChecked.Value && !PoluluxRadio.IsChecked.Value && !LuxRadio.IsChecked.Value)
            {
                ResultTextBlock.Text = "Пожалуйста, выберите тип комфортабельности.";
                return;
            }

            if (!double.TryParse(DistanceTextBox.Text, out double distance) || !int.TryParse(TicketsTextBox.Text, out int tickets))
            {
                ResultTextBlock.Text = "Пожалуйста, введите корректные числовые значения.";
                return;
            }

            double ratePerKm = 8.0;
            double comfortFactor = 1.0;

            if (KupeRadio.IsChecked.Value) comfortFactor = 1.1;
            else if (PoluluxRadio.IsChecked.Value) comfortFactor = 1.2;
            else if (LuxRadio.IsChecked.Value) comfortFactor = 1.3;

            double totalCost = distance * ratePerKm * tickets * comfortFactor;
            ResultTextBlock.Text = $"Общая стоимость билетов: {totalCost:C}";
        }
    }
}