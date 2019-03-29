using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComposTux.ViewModels.Base;
using Xamarin.Forms;

namespace ComposTux.ViewModels.Principal
{
    public class InicioPageViewModel : BindableBase
    {
        private List<CarouselModel> myDataSource;
        public List<CarouselModel> MyDataSource
        {
            get { return myDataSource; }
            set { SetProperty(ref myDataSource, value); }
        }
        private int _position;
        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public InicioPageViewModel()
        {
            LoadData();
            Title = "Inicio";
            PositionLoad();
        }
        private void PositionLoad()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Task.Run(() =>
                {
                    Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                    {
                        if (Position == MyDataSource.Count - 1)
                        {
                            Position = 0;
                        }
                        else
                        {
                            Position += 1;
                        }
                        return true;
                    });
                });
            });
        }
        private void LoadData()
        {
            MyDataSource = new List<CarouselModel>()
            {
                new CarouselModel()
                {
                    Title = "XamSarpContenido de Xamarin.Forms"
                },
                new CarouselModel()
                {
                    Title = "Sigue el Contenido de Xamarin.Forms"
                },
                new CarouselModel()
                {
                    Title = "Blog Contenido de Xamarin.Forms"
                }
            };
        }
    }
    public class CarouselModel
    {
        public string Title { get; set; }
    }
}
