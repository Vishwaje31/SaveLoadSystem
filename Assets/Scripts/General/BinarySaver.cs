using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class BinarySaver
{
    static string e_filepath = Application.persistentDataPath + "/EnemyData.save";
    static string p_filepath = Application.persistentDataPath + "/PlayerData.save";

    public static void SaveGame(SaveEnemyData _data)
    {
        BinaryFormatter binaryData = new BinaryFormatter();
        FileStream file;

        if (File.Exists(e_filepath))
            File.Delete(e_filepath);

        file = File.Create(e_filepath);
        binaryData.Serialize(file, _data);

        file.Close();
        Debug.Log("Saved enemy data");

    }

    public static SaveEnemyData LoadGame()
    {
        if (File.Exists(e_filepath))
        {
            try
            {
                BinaryFormatter binaryData = new BinaryFormatter();
                FileStream file = File.Open(e_filepath, FileMode.Open);
                SaveEnemyData save_d = (SaveEnemyData)binaryData.Deserialize(file);
                file.Close();

                Debug.Log("Loaded enemy data");
                return save_d;
            }
            catch
            {
                Debug.Log("Cant load enemy due to exception");
                return new SaveEnemyData();
            }
        }
        else
        {
            return new SaveEnemyData();
        }



    }

    public static void SavePlayerData(SavePlayerData _data)
    {
        BinaryFormatter binaryData = new BinaryFormatter();
        FileStream file;

        if (File.Exists(p_filepath))
            File.Delete(p_filepath);

        file = File.Create(p_filepath);
        binaryData.Serialize(file, _data);

        file.Close();

        Debug.Log("Saved Player data");

    }

    public static SavePlayerData LoadPlayerData()
    {
        if (File.Exists(p_filepath))
        {
            try
            {
                BinaryFormatter binaryData = new BinaryFormatter();
                FileStream file = File.Open(p_filepath, FileMode.Open);
                SavePlayerData save_d = (SavePlayerData)binaryData.Deserialize(file);
                file.Close();
                return save_d;
            }
            catch
            {
                return new SavePlayerData();
            }
        }
        else
        {
            return new SavePlayerData();
        }

    }



}
