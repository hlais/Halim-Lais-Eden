using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnChairsBasedOnBounds : MonoBehaviour
{

    
    bool hasSpawned = false;
    float halfChairLength;
    public GameObject chair;
    float spaceBetweenChairs = 0.25f;
    private void Awake()
    {
        halfChairLength = chair.transform.localScale.x / 2;
    }
    void Start()
    {

        
    }

    public float SetSpaceBetweenChairs { get; set; }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetLeftBounds());
        //if(!hasSpawned)
        //if (Input.GetKey(KeyCode.A))

        //{
        //     hasSpawned = true;
        //    SpawnChairs();
        //}
    }

    public float GetLeftBounds()
    {
        float leftBounds=  transform.localScale.x * 0.5f;
        return -leftBounds +halfChairLength ;
    }

    public float GetRightBounds()
    {
        float rightBounds = transform.localScale.x * 0.5f;
        return rightBounds -halfChairLength - spaceBetweenChairs;
    }

    public void SpawnChairs()
    {
        RemoveChairs();
        for (float i = GetLeftBounds(); i <GetRightBounds(); i+=spaceBetweenChairs+ chair.transform.localScale.x)
        {
           
            Instantiate(chair, new Vector3(i + spaceBetweenChairs , transform.position.y, transform.position.z -1f),Quaternion.identity);
            Instantiate(chair, new Vector3(i + spaceBetweenChairs, transform.position.y, transform.position.z + 1f), Quaternion.identity);
        }
    }

    public void RemoveChairs()
    {
        Chair[] chairs = GameObject.FindObjectsOfType<Chair>();
        for (int i = 0; i < chairs.Length; i++)
        {
            Destroy(chairs[i].gameObject);
        }
    }
}
