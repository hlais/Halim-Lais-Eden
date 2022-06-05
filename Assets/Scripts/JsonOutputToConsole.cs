using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonOutputToConsole : MonoBehaviour
{
    UserDetails currentUser = new UserDetails();
    

    HexToRGB hexDetails;
    void Start()
    {
        hexDetails = FindObjectOfType<HexToRGB>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUserDetails()
    {
      
        float tableLength = FindObjectOfType<Table>().transform.localScale.x;
        Chair[] chairs = FindObjectsOfType<Chair>();

        currentUser.chairs = chairs.Length;
        currentUser.lengthOfTable = tableLength;
        currentUser.hexColor = hexDetails.HexColour;

        JosonToConsole(currentUser);
    }
    void JosonToConsole(UserDetails user)
    {

        string jSon = JsonUtility.ToJson(user);
        Debug.Log(jSon);
    }
}
