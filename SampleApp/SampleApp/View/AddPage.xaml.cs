using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{

	    public EntryCell FirstEntry
	    {
	        get { return EntryFirst; }
	    }
	    public EntryCell LastEntry
	    {
	        get { return EntryLast; }
	    }
	    public Button SaveBtn
	    {
	        get { return BtnSave; }
	    }
		public AddPage (Person person = null)
		{
			InitializeComponent ();
		    if (person == null)
		    {
		        return;
		    }

		    BindingContext = person;
		}
	}
}