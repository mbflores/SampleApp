using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<Person> _person =new ObservableCollection<Person>();
		public MainPage ()
		{
			InitializeComponent ();
		}

	    public App app = (App) Application.Current;
        protected override async void OnAppearing()
        {
            await app.Connection.CreateTableAsync<Person>();
            var persons = await app.Connection.Table<Person>().ToListAsync();
            LstView.ItemsSource = persons;
            base.OnAppearing();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            var page = new AddPage();
            page.SaveBtn.Clicked += async (s, x) =>
            {
                var person = new Person
                {
                    FirstName=page.FirstEntry.Text.ToString(),
                    LastName=page.LastEntry.Text.ToString()
                };
                _person.Add(person);
                await app.Connection.InsertAsync(person);
                 Navigation.PopAsync();

            };
             await Navigation.PushAsync(page);
        }

        private  async void LstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (Person) e.SelectedItem;
            var page = new AddPage(selected);
            page.SaveBtn.Clicked += async (s, x) =>
            {
                var person = new Person
                {
                    FirstName=page.FirstEntry.Text.ToString(),
                    LastName=page.LastEntry.Text.ToString()
                };
                
                await app.Connection.UpdateAsync(person);
                LstView.SelectedItem = null;
                 Navigation.PopAsync();

            };
            await Navigation.PushAsync(page);
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var selected = ((MenuItem)sender).CommandParameter as Person;
            
            await app.Connection.DeleteAsync(selected);
            _person.Remove(selected);
        }
    }
}