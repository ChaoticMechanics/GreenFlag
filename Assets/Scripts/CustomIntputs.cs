using Assets.Scripts.DataAccess;
using Assets.Scripts.States;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomIntputs : MonoBehaviour
{
    private Button _rankedButton,
        _multiPlayerButton,
        _freeRideButton,
        _quitButton,
        _settingsButton,
        _profileButton,
        _garageButton,
        _ratingButton,
        _settingsCloseButton,
        _vibrateOnOffButton;
    private GameObject _backgroundImage;
    private Slider _musicSlider, _soundSlider;
    private delegate void ButtonClicked(ButtonActionEnum action, Action<bool> operationSuccess, GameObject active = null);

    private GObject gobjects;
    private event ButtonClicked OnButtonClicked;


    private Data _data;
    private SettingsState _sstate;
    void Start()
    {
        Init((success) =>
        {
            if (success)
            {

            }
            else
            {

            }
        });
        _data = Data.Instance;
        _sstate = _data.LoadData<SettingsState>(Strings.Files[0]);
        OnButtonClicked += DoAction;
        gobjects = GameObject.Find(Strings.GObject).GetComponent<GObject>();
    }

    private void DoAction(ButtonActionEnum action, Action<bool> operationSuccess, GameObject active = null)
    {
        try
        {
            switch (action)
            {
                case ButtonActionEnum.FreeRide:

                    break;
                case ButtonActionEnum.Ranked:

                    break;
                case ButtonActionEnum.MultiPlayer:

                    break;
                case ButtonActionEnum.Quit:

                    break;
                case ButtonActionEnum.Settings:

                    break;
                case ButtonActionEnum.Profile:

                    break;
                case ButtonActionEnum.Rating:

                    break;
                case ButtonActionEnum.Garage:

                    break;
                case ButtonActionEnum.Open:
                    Open(active);
                    break;
                case ButtonActionEnum.Close:
                    Close(active);
                    break;
            }
            operationSuccess?.Invoke(true);
        }
        catch (Exception)
        {
            operationSuccess?.Invoke(false);

        }
    }
    private void Close(GameObject gobject)
    {
        switch (gobject.name)
        {
            case Strings.SettingsWindow:
                gobject.SetActive(false);
                SaveSettings();
                break;
            default:
                gobject.SetActive(false);
                break;
        }
    }
    private void Open(GameObject gobject)
    {
        switch (gobject.name)
        {
            case Strings.SettingsWindow:
                gobject.SetActive(true);
                LoadSettings();
                break;
            default:
                gobject.SetActive(true);
                break;
        }
    }

    private void LoadSettings()
    {
        _sstate = _data.LoadData<SettingsState>(Strings.Files[0]);
        _musicSlider.value = _sstate.MusicSliderValue;
        _soundSlider.value = _sstate.SoundSliderValue;
    }

    private void SaveSettings()
    {
        _sstate.MusicSliderValue = _musicSlider.value;
        _sstate.SoundSliderValue = _soundSlider.value;
        _sstate.IsVibrateAllowed = false;
        _data.SaveData<SettingsState>(Strings.Files[0], _sstate,
            (Success) =>
            {
                if (!Success)
                {

                }
            });
    }



    //Finding GameObject from GUI
    private void GiveUIObject<T>(string child, string from, Action<T> callback)
    {
        var fromUi = _backgroundImage = GameObject.Find(from);
        var temp = fromUi.transform.Find(child).GetComponent<T>();
        if (temp != null)
        {
            callback?.Invoke(temp);
        }
        else
        {
            callback?.Invoke(temp);
        }
    }

    //PlayRanked
    private void PlayRanked()
    {
        throw new NotImplementedException();
    }

    //Initing Button Actions
    private void Init(Action<bool> p)
    {
        try
        {
            GiveUIObject<Button>(Strings.Ranked, Strings.BackgroundImage, (Sccss) =>
{
    if (Sccss)
    {
        _rankedButton = Sccss;
        _rankedButton.onClick.AddListener(delegate
        {
            OnButtonClicked?.Invoke(ButtonActionEnum.Ranked, (clbk) =>
             {
                 if (clbk)
                 {

                 }
                 else
                 {
                     Debug.LogError("Failed To do action");
                 }
             });
        });
    }
    else
    {
        throw new GameCustomException(ErrorStrings.CannotFindGameObject);
    }
});
            GiveUIObject<Button>(Strings.FreeRide, Strings.BackgroundImage, (Sccss) =>
            {
                if (Sccss)
                {
                    _freeRideButton = Sccss;
                    _freeRideButton.onClick.AddListener(delegate
                    {
                        OnButtonClicked?.Invoke(ButtonActionEnum.FreeRide, (clbk) =>
                         {
                             if (clbk)
                             {

                             }
                             else
                             {

                             }
                         });
                    });
                }
                else
                {
                    throw new GameCustomException(ErrorStrings.CannotFindGameObject);
                }
            });
            GiveUIObject<Button>(Strings.MultiPlayer, Strings.BackgroundImage, (Sccss) =>
   {
       if (Sccss)
       {
           _multiPlayerButton = Sccss;
           _multiPlayerButton.onClick.AddListener(delegate
           {
               OnButtonClicked?.Invoke(ButtonActionEnum.MultiPlayer, (clbk) =>
                {
                    if (clbk)
                    {

                    }
                    else
                    {

                    }
                });
           });
       }
       else
       {
           throw new GameCustomException(ErrorStrings.CannotFindGameObject);
       }
   });
            GiveUIObject<Button>(Strings.Quit, Strings.BackgroundImage, (Sccss) =>
            {
                if (Sccss)
                {
                    _quitButton = Sccss;
                    _quitButton.onClick.AddListener(delegate
                    {
                        OnButtonClicked?.Invoke(ButtonActionEnum.Quit, (clbk) =>
                        {
                            if (clbk)
                            {

                            }
                            else
                            {

                            }
                        });
                    });
                }
                else
                {
                    throw new GameCustomException(ErrorStrings.CannotFindGameObject);
                }
            });
            GiveUIObject<Button>(Strings.Settings, Strings.BackgroundImage, (Sccss) =>
         {
             if (Sccss)
             {
                 _settingsButton = Sccss;
                 _settingsButton.onClick.AddListener(delegate
                 {
                     OnButtonClicked?.Invoke(ButtonActionEnum.Open, (clbk) =>
                     {
                         if (clbk)
                         {

                         }
                         else
                         {

                         }
                     }, gobjects.SettingsWindow);
                 });
             }
             else
             {
                 throw new GameCustomException(ErrorStrings.CannotFindGameObject);
             }
         });
            GiveUIObject<Button>(Strings.Garage, Strings.BackgroundImage, (Sccss) =>
            {
                if (Sccss)
                {
                    _garageButton = Sccss;
                    _garageButton.onClick.AddListener(delegate
                    {
                        OnButtonClicked?.Invoke(ButtonActionEnum.Garage, (clbk) =>
                         {
                             if (clbk)
                             {

                             }
                             else
                             {

                             }
                         });
                    });
                }
                else
                {
                    throw new GameCustomException(ErrorStrings.CannotFindGameObject);
                }
            });
            GiveUIObject<Button>(Strings.Profile, Strings.BackgroundImage, (Sccss) =>
            {
                if (Sccss)
                {
                    _profileButton = Sccss;
                    _profileButton.onClick.AddListener(delegate
                    {
                        OnButtonClicked?.Invoke(ButtonActionEnum.Profile, (clbk) =>
                        {
                            if (clbk)
                            {

                            }
                            else
                            {

                            }
                        });
                    });
                }
                else
                {
                    throw new GameCustomException(ErrorStrings.CannotFindGameObject);
                }
            });
            GiveUIObject<Button>(Strings.Rating, Strings.BackgroundImage, (Sccss) =>
{
    if (Sccss)
    {
        _ratingButton = Sccss;
        _ratingButton.onClick.AddListener(delegate
        {
            OnButtonClicked?.Invoke(ButtonActionEnum.Rating, (clbk) =>
             {
                 if (clbk)
                 {

                 }
                 else
                 {

                 }
             });
        });
    }
    else
    {
        throw new GameCustomException(ErrorStrings.CannotFindGameObject);
    }
});
            GiveUIObject<Button>(Strings.Close, Strings.SettingsWindow, (Sccss) =>
            {
                if (Sccss)
                {
                    _settingsCloseButton = Sccss;
                    _settingsCloseButton.onClick.AddListener(delegate
                    {
                        OnButtonClicked?.Invoke(ButtonActionEnum.Close, (clbk) =>
                         {
                             if (clbk)
                             {

                             }
                             else
                             {

                             }
                         }, gobjects.SettingsWindow);
                    });
                }
                else
                {
                    throw new GameCustomException(ErrorStrings.CannotFindGameObject);
                }

            });


        }
        catch (GameCustomException)
        {
            Debug.LogError("Failed");
        }
        catch (Exception)
        {
            Debug.LogError("Failed");

        }
    }
}
