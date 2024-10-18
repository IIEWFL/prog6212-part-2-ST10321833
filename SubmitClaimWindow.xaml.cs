using CMCS4;
using System;
using System.Windows;

namespace CMCS4
{
    public partial class SubmitClaimWindow : Window
    {
        public SubmitClaimWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            var newClaim = new Claim
            {
                LecturerName = LecturerNameTextBox.Text,
                HoursWorked = double.Parse(HoursWorkedTextBox.Text),
                HourlyRate = double.Parse(HourlyRateTextBox.Text),
                Notes = NotesTextBox.Text
            };

       
            ClaimData.Claims.Add(newClaim);

            
            this.Close();
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
