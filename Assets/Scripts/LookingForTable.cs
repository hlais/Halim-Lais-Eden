using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script stops chair from cliping at the end of the table
public class LookingForTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            Debug.Log("NO table infront of me");
            Destroy(this.gameObject);

        }
    }
}
