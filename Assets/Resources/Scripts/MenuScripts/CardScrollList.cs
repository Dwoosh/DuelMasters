using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CardScrollList : MonoBehaviour
{
    public List<CardField> cardFieldList;

    private const string fileName = "cards.json";
    
    void Start()
    {
        var names = LoadCardNamesFromFile();
        //..
    }

    private string[] LoadCardNamesFromFile()
    {
        var path = Path.Combine(Application.dataPath, fileName);
        if (!File.Exists(path))
        {
            Debug.LogError("Cards file not found!");
            return new string[]{};
        }
        var json = File.ReadAllText(path); 
        var cardInfoList = JsonUtility.FromJson<CardInfoList>(json);
        return cardInfoList.list.Select(x => x.name).ToArray();
    }
    
}
