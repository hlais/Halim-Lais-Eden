using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIController : MonoBehaviour
{
    Slider tableLengthSlider;
    TMP_InputField spaceInput;
    TMP_InputField hexInput;
    
    Table currentTable;
    SpawnChairsBasedOnBounds currentTableBounds;
    HexToColour hexToColour;

    private void Awake()
    {
        //cache objects
        currentTable = FindObjectOfType<Table>();
        currentTableBounds = FindObjectOfType<SpawnChairsBasedOnBounds>();
        hexToColour = FindObjectOfType<HexToColour>();

        /// UI set ups
        tableLengthSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        spaceInput = GameObject.FindGameObjectWithTag("SpaceBetweenChairs").GetComponent<TMP_InputField>();
        hexInput = GameObject.FindGameObjectWithTag("Hex").GetComponent<TMP_InputField>();

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
        spaceInput.onValueChanged.AddListener(delegate { SpaceBetweenChairs(); });
        hexInput.onValueChanged.AddListener(delegate { StringChangeCheck(); });

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
        if (float.TryParse(spaceInput.text, out result))
        {
            SetSpaceBetweenChairs(result);
        }
        {
            // TODO UI text to display prompt to user
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

    void StringChangeCheck()
    {

        if (hexInput.text.Length < 1)
        {

            hexToColour.RestoreDefaulColour();

        }

        else if (hexInput.text.Length < 6)
        {
            //TODO UI text to display prompt to user
            Debug.Log("Waiting for you Hexy!");
        }
        else
        {
            // TODO UI text to display prompt to user
            Debug.Log("looks like a hexy");
            hexToColour.HexStringToRGB(hexInput.text);


        }
    }


}

