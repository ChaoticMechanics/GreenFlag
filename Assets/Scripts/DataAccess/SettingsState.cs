using System;

namespace Assets.Scripts.DataAccess
{
    [Serializable]
    public class SettingsState :IData
    {
       
        public float MusicSliderValue;
        public float SoundSliderValue;
        public bool IsVibrateAllowed;
    }
}
