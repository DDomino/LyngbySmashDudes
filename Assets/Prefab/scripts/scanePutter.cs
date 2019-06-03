using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanePutter : MonoBehaviour
{


    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        platform.GetComponent<killPlayer>().stage =1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
