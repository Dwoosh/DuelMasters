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
        SetupCardFields();
        
    }

    private void SetupCardFields()
    {
        var fieldsList = LoadCardNamesFromFile();
        foreach (var field in fieldsList.list)
        {
            var fd = Instantiate(Resources.Load<CardField>("Prefabs/CardInputField"));
            fd.Setup(field, this);
        }
    }
    
    private CardInfoList LoadCardNamesFromFile()
    {
        var path = Path.Combine(Application.dataPath, fileName);
        if (!File.Exists(path))
        {
            Debug.LogError("Cards file not found!");
            return null;
        }
        var json = File.ReadAllText(path); 
        return JsonUtility.FromJson<CardInfoList>(json);
    }
    
}
