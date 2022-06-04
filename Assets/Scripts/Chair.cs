using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject rightChairToSpawn;
    public GameObject leftChairToSpawn;
    [SerializeField] float xDistance = 5f;
    public Transform rightPos;
    public Transform leftPos;
    Vector3 rightOffset;
    Vector3 leftOffset;
    static int spawnedChair = 2;



    void Start()
    {
     

    }

        // Update is called once per frame
        void Update()
    {
      
    }

    public void SpawnAChair(string direction)
    {
        
            if (direction == "Left")
            {
                Instantiate(leftChairToSpawn, leftPos.position, transform.localRotation);
              

            }
            if (direction == "Right")
            {
                Instantiate(rightChairToSpawn, rightPos.position, transform.localRotation);
          
                spawnedChair++;
               
            
        }
     
    }

 
}
