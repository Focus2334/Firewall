using System.IO;
using System.Text;
using UnityEngine;

namespace ScObjects
{
    public static class SaveScObject
    {
        public static bool TryLoadSave(out PlayerSaveData playerSaveData)
        {
            var path = Directory.GetCurrentDirectory() + @"\Assets\SaveFiles\SaveData.json";
            if (File.Exists(path))
            {
                playerSaveData = JsonUtility.FromJson<PlayerSaveData>(File.ReadAllText(path, Encoding.UTF8));
                return true;
            }
            
            playerSaveData = null;
            return false;
        }

        public static void SavePreservation(PlayerSaveData saveData)
        {
            var json = JsonUtility.ToJson(saveData);
            var path = Directory.GetCurrentDirectory() + @"\Assets\SaveFiles\SaveData.json";
            if (!File.Exists(path)) 
                File.Create(path).Close();
            
            File.WriteAllText(path, json, Encoding.UTF8);
        }
    }
}