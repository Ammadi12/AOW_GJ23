using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
      public static void Save(CoinData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetPath(), FileMode.Create);

       

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static CoinData Load()
    {
        if(!File.Exists(GetPath()))
        {
            CoinData emptydata = new CoinData();    
            Save(emptydata);
            return emptydata;
        }
        
        
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GetPath(), FileMode.Open);

            CoinData data = formatter.Deserialize(stream) as CoinData;
            stream.Close();
            return data;


        }
      
    private static string GetPath()
    {
        return Application.persistentDataPath + "/game.aow";
    }
    }

