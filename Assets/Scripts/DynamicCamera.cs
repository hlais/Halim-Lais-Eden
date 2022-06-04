using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    Camera camera;
    Table table;

    float scale;


    private void Awake()
    {
        camera = Camera.main;
        table = FindObjectOfType<Table>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
           
    }

    
}
