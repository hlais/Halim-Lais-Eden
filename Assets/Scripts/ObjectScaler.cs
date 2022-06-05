using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScaler : MonoBehaviour
{

    
    
    public Slider slider;
    Table currentTable;
    SpawnChairsBasedOnBounds currentTableBounds;
    float currentTableMaxLength;
    float currentTableMinLenght;


    private void Awake()
    {
        currentTable = FindObjectOfType<Table>();
        currentTableBounds = FindObjectOfType<SpawnChairsBasedOnBounds>();
        SetUpSliderRange();
    }

    //TO DO - itterate through different tables 
    public void Changetable(Table newTable)
    {
        currentTable = newTable;
        SetUpSliderRange();
        //update size to avoid new talbe clipping through Dynamical Room size
        currentTable.gameObject.transform.localScale = new Vector3(slider.minValue, transform.localScale.y, transform.localScale.z);
       
        
    }


    void Start()
    {
        
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }



    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        ScaleTable(slider.value);
        currentTableBounds.SpawnChairs();
    }

    public void ScaleTable(float scale)
    {
        currentTable.gameObject.transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }

    //set up bounds of Table
    void SetUpSliderRange()
    {
        slider.minValue = currentTable.MIN_LENGTH;
        slider.maxValue = currentTable.MaxLength;
    }


}

