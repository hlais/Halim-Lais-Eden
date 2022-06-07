using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoreUserToJSon : MonoBehaviour
{
    UserDetails currentUser = new UserDetails();
    HexToColour hexDetails;
    void Start()
    {
        hexDetails = FindObjectOfType<HexToColour>();
        
    }

    public void UpdateUserDetails()
    {

        float tableLength = FindObjectOfType<Table>().MaxLength;
        Chair[] chairs = FindObjectsOfType<Chair>();

        currentUser.chairs = chairs.Length;
        currentUser.lengthOfTable = tableLength;
        currentUser.hexColor = hexDetails.HexColour;
        JosonToConsole(currentUser);
    }
    void JosonToConsole(UserDetails user)
    {

        string jSon = JsonUtility.ToJson(user);
        Debug.Log(jSon); // PRINT JSON TO CONSOLE
    }
}
