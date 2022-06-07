using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HexToColour : MonoBehaviour
{
    TMP_InputField textInput;
    Color defaultColor;
    Color currentColor;

    public Color CurrentColoor { get { return currentColor; } } 
    void Awake()
    {
        textInput = GameObject.FindGameObjectWithTag("Hex").GetComponent<TMP_InputField>();
        textInput.onValueChanged.AddListener(delegate { StringChangeCheck(); });
        defaultColor = GameObject.FindGameObjectWithTag("Table").GetComponent<MeshRenderer>().material.color;
        currentColor = defaultColor;
    }
    public string HexColour { get  { return HexToString(currentColor);}}

    void StringChangeCheck()
    { 
  
        if (textInput.text.Length < 1)
        {
            
            RestoreDefaulColour();
          
        }

        else if (textInput.text.Length < 6)
        {
            //TODO UI text to display prompt to user
            Debug.Log("Waiting for you Hexy!");
        }
        else
        {
            // TODO UI text to display prompt to user
            Debug.Log("looks like a hexy");
            HexStringToRGB(textInput.text);
            

        }
    }
    string HexToString(Color color)
    {
        Color32 c = color;
        var hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", c.r, c.g, c.b, c.a);
        return hex;
    }

    public void HexStringToRGB(string HeX)
    {

        if (ColorUtility.TryParseHtmlString(HeX, out Color color))
        {
            Debug.Log("Thats a valid colour");
            //isValidHex = true;
            UpdateColours(color);
            currentColor = color;

        }
        else
        {
            // TODO UI text to display prompt to user
            Debug.Log("The value aint Hexy man!");
         
        }
    }
    

     void UpdateColours(Color convertedFromHex)
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        GameObject table = GameObject.FindGameObjectWithTag("Table");
        table.gameObject.GetComponent<MeshRenderer>().material.color = convertedFromHex;
        foreach (var item in chairs)
        {
            item.gameObject.GetComponent<MeshRenderer>().material.color = convertedFromHex; 
        }
    }

    public void RestoreDefaulColour()
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        GameObject table = GameObject.FindGameObjectWithTag("Table");
        table.gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
        foreach (var item in chairs)
        {
            item.gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
        }
        currentColor = defaultColor;
    }

    
       
}
