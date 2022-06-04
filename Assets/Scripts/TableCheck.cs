using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TableCheck : MonoBehaviour
{
    Chair chair;
    bool hasSpawn = false;

    string checkDirection;
    public enum spawnDirection {Left,Right };
    public spawnDirection currentSpawnDirection;


  
    


    private void Awake()
    {
        chair = GetComponentInParent<Chair>();
      
    }
    void Start()
    {
        checkDirection = gameObject.tag;
        if (checkDirection == "")
        {
            Debug.Log("must assign a tag, either Left or Right");
        }
      
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (hasSpawn == false)
        {
            if (other.gameObject.tag == "Table")
            {
                hasSpawn = true;
                chair.SpawnAChair(checkDirection);
                Debug.Log("Spawn");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            hasSpawn = false;
        }
    }

}
