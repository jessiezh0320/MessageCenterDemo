using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessageApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadItemPutawayTemplate : ContentView
    {
        public LoadItemPutawayTemplate()
        {
            InitializeComponent();
        }

        private void LocationBtn_Clicked(object sender, EventArgs e)
        {
            LocationModel stringInThisCell = (LocationModel)((Button)sender).BindingContext;

            System.Diagnostics.Debug.WriteLine("send  msg  current update = " + stringInThisCell.ToLocation);

            string source = stringInThisCell.ToLocation;
            string result = "XYZ";

            string[] values = { source, result };

            MessagingCenter.Send<LoadItemPutawayTemplate, string[]>(this, "Location", values);
        }
    }
}