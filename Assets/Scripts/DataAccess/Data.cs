using Assets.Scripts.States;
using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.DataAccess
{
    public class Data
    {
        private const int fileCountConstant = 1;
        private string[] fileNameStrings = Strings.Files;
        private Data() { }
        private static Data _instance;
        public static Data Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new Data();
                }
            }
            private set { }
        }
        public T LoadData<T>(string name)
        {

            try
            {
                var jsonString = File.ReadAllText(Application.persistentDataPath + name);
                var result = JsonUtility.FromJson<T>(jsonString);
                return result;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        
        public void SaveData<T>(string name, IData data, System.Action<bool> operationState)
        {
            try
            {
                var jsonString = JsonUtility.ToJson(data);
                File.WriteAllText(Application.persistentDataPath + name, jsonString);
                operationState.Invoke(true);
            }
            catch (System.Exception ex)
            {
                operationState.Invoke(false);
            }
        }
        [RuntimeInitializeOnLoadMethod]
        private void CreateFiles()
        {
            for (int i = 0; i < fileCountConstant; i++)
            {
                if (!File.Exists(Application.persistentDataPath + fileNameStrings[i]))
                {
                    File.Create(Application.persistentDataPath + fileNameStrings[i]);
                }
            }
        }


    }
}
