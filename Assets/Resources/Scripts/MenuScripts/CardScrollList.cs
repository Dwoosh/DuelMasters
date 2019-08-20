using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CardScrollList : MonoBehaviour
{
    public List<CardField> cardFieldList;
    public CardSettingsHolderScript settingsHolder;
    public GameObject listContent;
    
    private const string fileName = "cards.json";
    
    public void SetupCardFields()
    {
        if (settingsHolder.fields == null || settingsHolder.fields.Count == 0)
        {
            var fieldsList = LoadCardNamesFromFile();
            foreach (var field in fieldsList.list)
            {
                var fd = Instantiate(Resources.Load<CardField>("Prefabs/CardInputField"), listContent.transform, false);
                fd.Setup(field, this);
            }
        }
        else
        {
            cardFieldList.AddRange(settingsHolder.fields);
            cardFieldList.Sort();
            settingsHolder.fields.Clear();
        }
    }
    
    private CardInfoList LoadCardNamesFromFile()
    {
        var path = Path.Combine(Application.dataPath, "Resources/" + fileName);
        if (!File.Exists(path))
        {
            Debug.LogError("Cards file not found!");
            return null;
        }
        var json = File.ReadAllText(path); 
        return JsonUtility.FromJson<CardInfoList>(json);
    }
    
}
