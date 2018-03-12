using System;
using System.Windows;
using ResistanceCalculator;

namespace CalculatorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OhmValueCalculator calculator = new OhmValueCalculator();
            
            //Make sure all four ComboBoxes are populated with a value

            if (ComboBox1.SelectedIndex == -1 || ComboBox2.SelectedIndex == -1 || ComboBox3.SelectedIndex == -1 || ComboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("You must select all four band colors!", "Error");
            }
            else
            {
                int sigFigs = calculator.CalculateOhmValue(ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, ComboBox4.Text);
                int multiplier = calculator.GetMultiplierValue(ComboBox3.Text);
                double tolerance = calculator.GetToleranceValue(ComboBox4.Text);

                result.Text = calculator.GetOhmValueString(sigFigs, multiplier, tolerance);
            }
        }
    }
}

