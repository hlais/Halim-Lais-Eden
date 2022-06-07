using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIController : MonoBehaviour
{
    Slider tableLengthSlider;
    TMP_InputField spaceText;

    Table currentTable;
    SpawnChairsBasedOnBounds currentTableBounds;

    private void Awake()
    {
        currentTable = FindObjectOfType<Table>();
        currentTableBounds = FindObjectOfType<SpawnChairsBasedOnBounds>();
        tableLengthSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        spaceText = GameObject.FindGameObjectWithTag("SpaceBetweenChairs").GetComponent<TMP_InputField>();
        SetUpSliderRange();
        
    }

    //TO DO - itterate through different tables 
    public void Changetable(Table newTable)
    {
        currentTable = newTable;
        SetUpSliderRange();
        //update size to avoid new talbe clipping through Dynamical Room size
        currentTable.gameObject.transform.localScale = new Vector3(tableLengthSlider.minValue, transform.localScale.y, transform.localScale.z);    
    }


    void Start()
    {

        tableLengthSlider.onValueChanged.AddListener(delegate { TableLength(); });
        spaceText.onValueChanged.AddListener(delegate {SpaceBetweenChairs(); });

    }



    // Invoked when the value of the slider changes.
    public void TableLength()
    {
        currentTable.ScaleTable(tableLengthSlider.value);
        currentTableBounds.SpawnChairs();
    }

     void SpaceBetweenChairs()
    {
        float result;
        if (float.TryParse(spaceText.text, out result))
        {
            SetSpaceBetweenChairs(result);
        }
        {
            Debug.Log("Only numbers please");
        }

        
    }



    void SetUpSliderRange()//sets up bounds of Table to slider
    {
        tableLengthSlider.minValue = currentTable.MinLength;
        tableLengthSlider.maxValue = currentTable.MaxLength;

    }

    

     void SetSpaceBetweenChairs(float space)
    {
        if (space < 0.001) { Debug.Log("Chairs are too close"); return; } //avoid clipping
        currentTableBounds.SpaceBetweenChairs = space;
        //update space 
        currentTableBounds.SpawnChairs();

    }


}

