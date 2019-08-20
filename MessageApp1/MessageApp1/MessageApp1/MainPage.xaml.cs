using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessageApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public List<LocationModel> WorkItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            WorkItems = new List<LocationModel>();

            WorkItems.Add(new LocationModel { ToLocation = "Tomato"});
            WorkItems.Add(new LocationModel { ToLocation = "Zucchini" });
            WorkItems.Add(new LocationModel { ToLocation = "Tomato2"});
            WorkItems.Add(new LocationModel { ToLocation = "Romaine2" });
            WorkItems.Add(new LocationModel { ToLocation = "Zucchin2"});

            MessagingCenter.Subscribe<LoadItemPutawayTemplate, string[]>(this,
             "Location", async (sender, values) =>
            {

                string source = values[0];
                string result = values[1];
                System.Diagnostics.Debug.WriteLine("receive message current update = " + source +" -----  "+ result);

                for (int i = 0; i < WorkItems.Count; i++)
                {
                    LocationModel model = WorkItems[i];
                    if (source.Equals(model.ToLocation)) {
                        model.ToLocation = result;
                        break;
                    }
                }
            });



            workList.ItemsSource = WorkItems;  // ItemsSource="{ Binding WorkItems}"      
         

        }
    }
}
