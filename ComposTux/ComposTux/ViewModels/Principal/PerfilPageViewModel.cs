using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ComposTux.DbLocal;
using ComposTux.Models.User;
using ComposTux.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ComposTux.ViewModels.Principal
{
    public class PerfilPageViewModel : BindableBase
    {
        #region properties
        private UserModel user;
        public UserModel User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        private Position myPosition = new Position(19.3188895, -99.10986379999997);
        public Position MyPosition
        {
            get
            {
                return myPosition;
            }
            set
            {
                SetProperty(ref myPosition, value);
            }
        }
        private ObservableCollection<Pin> allPines = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> AllPines
        {
            get
            {
                return allPines;
            }
            set
            {
                allPines = value;
                OnPropertyChanged("AllPines");
            }
        }
        //private ObservableCollection<Position> ruta = new ObservableCollection<Position>();
        //public ObservableCollection<Position> Ruta
        //{
          //  get
            //{
              //  return ruta;
            //}
            //set
            //{
              //  SetProperty(ref ruta, value);
            //}
        //}
        #endregion

        #region Constructor
        public PerfilPageViewModel()
        {
            try
            {
                User = new UserModel();
                var db = new DbContext();
                var response = db.GetUser();
                response.Location = "Latitud: " + response.Latitud + ", " + "Longitud: " + response.Longitud; 
                User = response;
                EditCommand = new Command(EditCommandExecuted);
                SaveCommand = new Command(SaveCommandExecuted);
                UpdateMapCommand = new Command(UpdateMapCommandExecuted);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Command
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UpdateMapCommand { get; set; }
        #endregion

        #region CommandExecuted
        int bandera = 0;
        private void EditCommandExecuted()
        {
            try
            {
                if (bandera == 0)
                {
                    IsEnabled = true;
                    bandera = 1;
                }
                else
                {
                    IsEnabled = false;
                    bandera = 0;
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void SaveCommandExecuted()
        {
            try
            {
                if(User != null)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Methods

        private async void UpdateMapCommandExecuted()
        {
            try
            {
                var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                MyPosition = new Position(position.Latitude, position.Longitude);
                AllPines.Add(new Pin() { Position = new Position(position.Latitude, position.Longitude), Type = PinType.SavedPin, Label = "Aqui estas" });
                //Ruta.Add(new Position(37.797534, -122.401827));
                //Ruta.Add(new Position(37.797510, -122.402060));
                //Ruta.Add(new Position(37.790269, -122.400589));
                //Ruta.Add(new Position(37.790265, -122.400474));
                //Ruta.Add(new Position(37.790228, -122.400391));
                //Ruta.Add(new Position(37.790126, -122.400360));
                //Ruta.Add(new Position(37.789250, -122.401451));
                //Ruta.Add(new Position(37.788440, -122.400396));
                //Ruta.Add(new Position(37.787999, -122.399780));
                //Ruta.Add(new Position(37.786736, -122.398202));
                //Ruta.Add(new Position(37.786345, -122.397722));
                //Ruta.Add(new Position(37.785983, -122.397295));
                //Ruta.Add(new Position(37.785559, -122.396728));
                //Ruta.Add(new Position(37.780624, -122.390541));
                //Ruta.Add(new Position(37.777113, -122.394983));
                //Ruta.Add(new Position(37.776831, -122.394627));
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
    }
}
