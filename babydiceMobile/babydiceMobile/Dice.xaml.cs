using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace babydiceMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dice : ContentPage
    {
        public Dice()
        {
            InitializeComponent();
        }

        public void MakeInt(Entry sender, TextChangedEventArgs e)
        {
            Decimal result = 0;
            decimal.TryParse(sender.Text, out result);
            sender.Text = Convert.ToString(Convert.ToInt32(result));
        }


        public void Stepperloop(Object sender, ValueChangedEventArgs e)
        {
            Stepper stepper = sender as Stepper;
            if (stepper.Minimum == 1)
            {
                double value = e.NewValue;
                rollcountlabel.Text = ("" + value);
            }
            else
            {
                double value = e.NewValue;
                flatmodlabel.Text = ("" + value);
            }
        }
        async void imagebuttontestclass(Object sender, EventArgs e)
        {
            ImageSource image = null;
            ImageButton button = sender as ImageButton;
            int rolls = 0;
            rolls = int.Parse(rollcountlabel.Text);
            Random random = new Random();
            int sum = 0;
            int maxroll = 0;
            string rolldisplay = "";

            if (button.ClassId == "d4")
            {
                maxroll = 4;
                image = ImageSource.FromResource("babydiceMobile.images.d4.png");
            }
            if (button.ClassId == "d20")
            {
                maxroll = 20;
                image = ImageSource.FromResource("babydiceMobile.images.d20.png");
            }
            if (button.ClassId == "d8")
            {
                maxroll = 8;
                image = ImageSource.FromResource("babydiceMobile.images.d8.png");
            }
            if (button.ClassId == "d10")
            {
                maxroll = 10;
                image = ImageSource.FromResource("babydiceMobile.images.d10.png");
            }
            if (button.ClassId == "d12")
            {
                maxroll = 12;
                image = ImageSource.FromResource("babydiceMobile.images.d12.png");
            }
            if (button.ClassId == "d100")
            {
                maxroll = 100;
                image = ImageSource.FromResource("babydiceMobile.images.d100.png");
            }
            if (button.ClassId == "d6")
            {
                maxroll = 6;
                image = ImageSource.FromResource("babydiceMobile.images.d6.png");
            }


            for (int i = 0; i < rolls;)
            {
                i++;
                int x = random.Next(1, maxroll + 1);
                sum = sum + x;

                if (rolls == 1)
                    rolldisplay = (rolldisplay + x);

                else if (rolls == i)
                    rolldisplay = (rolldisplay + x);

                else if (rolls != 1 && rolls != i)
                    rolldisplay = (rolldisplay + x + ", ");
            }

            sum = sum + int.Parse(flatmodlabel.Text);

            string testempty = " ";
            string result = ("Your rolled " + rolls + button.ClassId + " (" + Convert.ToString(sum) + ")");

            if (int.Parse(flatmodlabel.Text) != 0)
            {
                rolldisplay = (rolldisplay + " + " + flatmodlabel.Text);
            }
            await DisplayAlert(result, rolldisplay, testempty);
            History.updatehistory(result, image);

        }


        async void resetrolls(object sender, EventArgs e)
        {
            Button button = sender as Button;

            flatmodlabel.Text = "0";
            rollcountlabel.Text = "1";
        }

        async void coinflip(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int flip = rnd.Next(1, 3);
            string result = "";

            if (flip == 1)
                result = "heads";
            if (flip == 2)
                result = "tails";

            await DisplayAlert("You flipped a coin!", result, " ");
        }

    }
}