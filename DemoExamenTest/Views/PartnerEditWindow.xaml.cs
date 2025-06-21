using System.Windows;
using DemoExamenTest.Models;
using DemoExamenTest.Data;
using DemoExamenTest.ViewModels;

namespace DemoExamenTest.Views;

public partial class PartnerEditWindow : Window
{
    private readonly PartnerViewModel _viewModel;
    private readonly int? _partnerId;
    
    public PartnerEditWindow(int? partnerId)
    {
        InitializeComponent();
        _partnerId = partnerId;
        _viewModel = new PartnerViewModel(new PartnerDbContext());
        Title = partnerId == null ? "Добавить партнера" : "Редактировать партнера";
        if (partnerId != null) LoadPartner();
        LoadPartnerTypes();
    }

    private void LoadPartnerTypes()
    {
        var partnerTypes = _viewModel.GetPartnerTypes();
        partnerTypeComboBox.ItemsSource = partnerTypes;
        partnerTypeComboBox.DisplayMemberPath = "Name";
        partnerTypeComboBox.SelectedValuePath = "Id";
    }

    private void LoadPartner()
    {
        var partner = _viewModel.GetPartnerById(_partnerId.Value);
        if (partner == null) return;
        nameTextBox.Text = partner.Name;
        directorTextBox.Text = partner.Director;
        emailTextBox.Text = partner.Email;
        phoneTextBox.Text = partner.Phone;
        addressTextBox.Text = partner.Address;
        innTextBox.Text = partner.Inn;
        ratingTextBox.Text = partner.Rating.ToString();
        partnerTypeComboBox.ItemsSource = partner.PartnerTypes;
        partnerTypeComboBox.DisplayMemberPath = "Name";
        partnerTypeComboBox.SelectedValuePath = "Id";
        partnerTypeComboBox.SelectedValue = _viewModel.GetPartnerTypeId(partner.PartnerTypeName);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (partnerTypeComboBox.SelectedValue == null)
        {
            MessageBox.Show("Пожалуйста, выберите тип партнера.");
            return;
        }

        if (!int.TryParse(ratingTextBox.Text, out int rating))
        {
            MessageBox.Show("Рейтинг должен быть числом.");
            return;
        }

        if (_partnerId == null)
        {
            _viewModel.AddPartner(new Partner
            {
                Name = nameTextBox.Text,
                Director = directorTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
                Address = addressTextBox.Text,
                Inn = innTextBox.Text,
                Rating = rating,
                PartnerTypeId = (int)partnerTypeComboBox.SelectedValue,
            });
            
            Close();
        }
        
        _viewModel.EditPartner(new PartnerModelView
        {
            Id = _partnerId.Value,
            Name = nameTextBox.Text,
            Director = directorTextBox.Text,
            Email = emailTextBox.Text,
            Phone = phoneTextBox.Text,
            Address = addressTextBox.Text,
            Inn = innTextBox.Text,
            Rating = rating,
            PartnerTypeName = partnerTypeComboBox.SelectedValue.ToString()
        });
        
        Close();
    }
}