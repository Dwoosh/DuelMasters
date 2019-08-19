using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardSettingsHolderScript : MonoBehaviour
{
    public List<CardField> fields;
    
    void Start()
    {
        fields = new List<CardField>();
    }

}
