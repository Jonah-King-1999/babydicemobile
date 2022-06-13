using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace babydiceMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public static List<display> historylist = new List<display>();
        

        public History()
        {
            InitializeComponent();
            

        }
         void Updatehistory(object sender, EventArgs e)
        {
            historylistview.ItemsSource = null;
            historylistview.ItemsSource = historylist;
        }

        public static void updatehistory(string result, ImageSource _Image)
        {
            display newresult = new display();
            newresult.result = result;
            newresult.image = _Image;
            historylist.Insert(0, newresult);


        }
    }

    public class display
    {
        public ImageSource image { get; set; }
        public string result { get; set; }
    }

}