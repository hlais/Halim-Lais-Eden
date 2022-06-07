using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnChairsBasedOnBounds : MonoBehaviour
{
    
    float halfChairLength;
    float chairYCentre;
    float fullChairLength;
    public GameObject chair;
    float spaceBetweenChairs = 0.20f;
    float spaceFromTable = 1f;

    public float SpaceBetweenChairs { get { return spaceBetweenChairs; } set { spaceBetweenChairs = value; } }
    public float SpaceFromTable { get { return spaceFromTable; } set { spaceFromTable = value; } } // TODO make this adjustable UI Element
    private void Awake()
    {
        halfChairLength = chair.transform.localScale.x * 0.5f; //cache this, for better performance
        fullChairLength = chair.transform.localScale.x;
        chairYCentre = chair.transform.localScale.y * 0.5f;
    }
    void Start()
    {
        SimplePool.Preload(chair, 100);
        
    }
    
    //Dynamic bounds 
    public float GetLeftBounds()
    {
        float leftBounds=  transform.localScale.x * 0.5f;
        return -leftBounds +halfChairLength - spaceBetweenChairs ;
        
    }
    
    public float GetRightBounds()
    {
        float rightBounds = transform.localScale.x * 0.5f;
        return rightBounds - halfChairLength - spaceBetweenChairs; 
    }

    public void SpawnChairs()
    {       
        RemovePreviousChairs();
        //spawn new chairs
        for (float i = GetLeftBounds(); i <GetRightBounds(); i+=spaceBetweenChairs+ fullChairLength )
        {           
            SimplePool.Spawn(chair, new Vector3(i + spaceBetweenChairs , chairYCentre, transform.position.z -1f),Quaternion.identity);
            SimplePool.Spawn(chair, new Vector3(i + spaceBetweenChairs, chairYCentre, transform.position.z + 1f), Quaternion.identity);
        }    
    }

    public void RemovePreviousChairs()
    {
        Chair[] chairs = GameObject.FindObjectsOfType<Chair>();
        for (int i = 0; i < chairs.Length; i++)
        {
            SimplePool.Despawn(chairs[i].gameObject);
        }
    }
}
