using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
namespace testes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainpage : ContentPage
    {
        public mainpage()
        {
            BindingContext = this;
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(100), done);
            bool done()
            {
                if (playtime >= 0) { playtime--;
                }
                if (hungry >= 0) { hungry--;
                }
                if (thirsty >= 0) { thirsty--;
                }
                if (lights == true)
                {
                    if (sleep >= 0) { sleep--; }
                }
                else
                {
                    if (sleep <= 10) { sleep++; }
                }
                state();
                return true;
            }

        }
        public bool lights
        {
            get => Preferences.Get("lights", false);
            set
            {
                Preferences.Set("lights", value);
                OnPropertyChanged(nameof(lights));
            }

        }


        public int sleep
        {
            get => Preferences.Get("sleep", 10);
            set
            {
                Preferences.Set("sleep", value);
                OnPropertyChanged(nameof(sleep));
            }
        }



        public int hungry
        {
            get => Preferences.Get("hungry", 7);
            set
            {
                Preferences.Set("hungry", value);
                OnPropertyChanged(nameof(hungry));
            }
        }
        public int thirsty
        {
            get => Preferences.Get("thirsty", 7);
            set
            {
                Preferences.Set("thirsty", value);
                OnPropertyChanged(nameof(thirsty));
            }
        }
        public int playtime
        {
            get => Preferences.Get("playtime", 5);
            set
            {
                Preferences.Set("playtime", value);
                OnPropertyChanged(nameof(playtime));
            }
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            if (lights == true) 
            {
                lights = false;
                button1.Text = "Lightswitch";
                state();
            }


            else 
            {
                lights = true;
                button1.Text = "lightswitch";
                state();
            }


        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            if (hungry <= 10)
            {
                hungry++;
            }
            state();
        }

        private void button3_Clicked(object sender, EventArgs e)
        {
            if (thirsty <= 10)
            {
                thirsty++;
            }
            state();
        }

        private void button4_Clicked(object sender, EventArgs e)
        {
            if(playtime <=20){
                playtime++;
            }
            state();
        }



        void state()
        {
            if (lights == false)
            {
                if (hungry < 5 || thirsty < 5 || playtime < 5) 
                {
                    face.Text = ">w<"; 
                } else 
                { 
                    face.Text = "UwU"; 
                }
            }else
            {
                if (sleep < 5 || hungry < 5 || thirsty < 5 || playtime < 5 || playtime > 15) 
                {
                    if (playtime > 15) { face.Text = "=w="; } else {
                        face.Text = "QwQ"; }
                } else 
                { 
                    face.Text = "OwO"; 
                }
            }
        }

        private void status_Clicked(object sender, EventArgs e)
        {
            if (playtime < 5 || playtime > 15) 
            { 
                if (playtime > 15)
                {
                    Application.Current.Properties["happy"] = "i am exhausted";
                }
                else { Application.Current.Properties["happy"] = "i am lonely"; }
            }else
            {
                Application.Current.Properties["happy"] = "i am happy";
            }

            if (thirsty< 5) { Application.Current.Properties["thirst"] = "i am thirsty"; }
            else { Application.Current.Properties["thirst"] = ""; }

            if (hungry < 5) { Application.Current.Properties["hunger"] = "i am hungry";
            }
            else { Application.Current.Properties["hunger"] = ""; }
            if (sleep < 5) { Application.Current.Properties["sleep"] = "i am sleepy"; }
            else { Application.Current.Properties["sleep"] = ""; }

            Navigation.PushAsync(new deletethis());
        }
    }
}