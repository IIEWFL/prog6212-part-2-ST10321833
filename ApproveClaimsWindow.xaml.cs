using System;
using System.Linq;
using System.Windows;

namespace CMCS4
{
    public partial class ApproveClaimsWindow : Window
    {
      
        public event Action ClaimsUpdated;

        public ApproveClaimsWindow()
        {
            InitializeComponent();
          
            ClaimsListBox.ItemsSource = ClaimData.Claims.Select(c => new ClaimViewModel
            {
                Id = c.Id,
                LecturerName = c.LecturerName,
                HoursWorked = c.HoursWorked,
                HourlyRate = c.HourlyRate,
                Status = c.Status
            }).ToList();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsListBox.SelectedItem is ClaimViewModel selectedClaim)
            {
                Claim originalClaim = ClaimData.Claims.First(c => c.Id == selectedClaim.Id);
                originalClaim.Status = "Approved";
                ClaimsListBox.Items.Refresh(); 
                ClaimsUpdated?.Invoke(); 
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsListBox.SelectedItem is ClaimViewModel selectedClaim)
            {
                Claim originalClaim = ClaimData.Claims.First(c => c.Id == selectedClaim.Id);
                originalClaim.Status = "Rejected";
                ClaimsListBox.Items.Refresh(); 
                ClaimsUpdated?.Invoke(); 
            }
        }

       private void Close_Click(object sender, RoutedEventArgs e)
{
    this.Close();
}

    }
}
