using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class deletethis : ContentPage
    {
        public deletethis()
        {
            InitializeComponent();
            labelhunger.Text = $"{Application.Current.Properties["hunger"].ToString()}";
            labelthirsty.Text = $"{Application.Current.Properties["thirst"].ToString()}";
            labelsleepy.Text = $"{Application.Current.Properties["sleep"].ToString()}";
            labelhappy.Text = $"{Application.Current.Properties["happy"].ToString()}";
            
        }
    }
}