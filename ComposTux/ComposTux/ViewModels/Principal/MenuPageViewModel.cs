using System;
using System.Collections.Generic;
using System.Windows.Input;
using ComposTux.Models;
using ComposTux.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ComposTux.ViewModels.Principal
{
    public class MenuPageViewModel : BindableBase
    {
        #region Properties

        private List<MenuLateralModel> listMenu;
        public List<MenuLateralModel> ListMenu
        {
            get { return listMenu; }
            set { SetProperty(ref listMenu, value); }
        }

        #endregion

        #region Constructor

        public MenuPageViewModel()
        {
            try
            {
                ItemSelectedCommand = new Command<MenuLateralModel>(ItemSelectedCommandExecuted);
                LoadMenu();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Command

        public ICommand ItemSelectedCommand { get; set; }

        #endregion

        #region CommandExecuted

        private async void ItemSelectedCommandExecuted(MenuLateralModel menuLateralModel)
        {
            try
            {
                if (menuLateralModel != null)
                {
                    ResetColorMenu(menuLateralModel);
                    if (menuLateralModel.IDMenu == 4)
                    {
                        LogOut();
                    }
                    else
                    {
                        if (menuLateralModel.IDMenu == 1)
                        {
                            NavigationPageAsync(new Views.Principal.PerfilPage());
                        }
                        else if (menuLateralModel.IDMenu == 2)
                        {
                            NavigationPageAsync(null);
                            await PopupNavigation.PushAsync(new Views.Popups.AboutPage(), true);
                        }
                        else if (menuLateralModel.IDMenu == 3)
                        {
                            NavigationPageAsync(null);
                            await PopupNavigation.PushAsync(new Views.Popups.SharedPopup(), true);
                        }
                        else if (menuLateralModel.IDMenu == 5)
                        {
                            NavigationPageAsync(new Views.Principal.MessagePage());                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Methods

        private void LoadMenu()
        {
            try
            {
                ListMenu = new List<MenuLateralModel>();
                ListMenu.Clear();
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 1,
                    Icon = "profile",
                    Title = "Perfil",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 5,
                    Icon = "message",
                    Title = "Mensages",
                    IsVisible = true
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 2,
                    Icon = "info",
                    Title = "Acerca de",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 3,
                    Icon = "share",
                    Title = "Compartir",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 4,
                    Icon = "logout",
                    Title = "Cerrar sesion",
                    IsVisible = false
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //metodo despues de validar si ya se asigno a un proyecto
        private void LoadMenuResultResponse()
        {
            try
            {
                ListMenu = new List<MenuLateralModel>();
                ListMenu.Clear();
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 1,
                    Icon = "profile",
                    Title = "Perfil",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 5,
                    Icon = "message",
                    Title = "Mensages",
                    IsVisible = true
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 2,
                    Icon = "info",
                    Title = "Acerca de",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 3,
                    Icon = "share",
                    Title = "Compartir",
                    IsVisible = false
                });
                ListMenu.Add(new MenuLateralModel
                {
                    IDMenu = 4,
                    Icon = "logout",
                    Title = "Cerrar sesion",
                    IsVisible = false
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void ResetColorMenu(MenuLateralModel menuLateralModel)
        {
            try
            {
                foreach (var item in ListMenu)
                {
                    if (item.IDMenu == menuLateralModel.IDMenu)
                    {
                        if (item.Icon.Contains("_blue"))
                        {

                        }
                        else
                        {
                            item.Icon = item.Icon + "_blue";
                        }
                    }
                    else
                    {
                        if (item.Icon.Contains("_blue"))
                        {
                            var image = item.Icon.Split('_');
                            item.Icon = image[0];
                        }
                        else
                        {
                            item.Icon = item.Icon;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
