using System;
using SampleApp.Persistence;
using SampleApp.View;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SampleApp
{
	public partial class App : Application
	{

	    private SQLiteAsyncConnection _connection;
	    public SQLiteAsyncConnection Connection
	    {
	        get { return _connection; }
	    }
		public App ()
		{
			InitializeComponent();
		    _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
		    MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
