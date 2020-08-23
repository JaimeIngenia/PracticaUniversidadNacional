using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Datachart = Microcharts.ChartEntry;


namespace AppInternet
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<WSResult> d;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCallWS_Click(object sender, EventArgs e)
        {
            WSClient client = new WSClient();
            List<Datachart> datachartList = new List<Datachart>();
            d = await client.Get<WSResult>("https://gensyslabs.net/listado3.php");//https://gensyslabs.net/listado3.php//https://gensyslabs.net/listado3.php****https://gensyslabs.net/listado_panel.php?h=2//http://practica2020.ml/prueba1.php
            foreach (var item in d)
            {
                Datachart x = new Datachart(float.Parse(item.corriente))//.current
                {
                    Color = SkiaSharp.SKColor.Parse("#ff92a0"),
                    TextColor = SkiaSharp.SKColor.Parse("#ff92a0"),
                    Label = item.tiempo,//tiempo,uptime
                   
                    ValueLabel = item.tiempo//tiempo,uptime
                };

                datachartList.Add(x);

            }
            Grafica1.Chart = new Microcharts.LineChart()
            {
                Entries = datachartList

            };
        }
    }
}
