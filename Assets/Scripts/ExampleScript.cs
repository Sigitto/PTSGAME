using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public float speed;
    public float distance;
    public float time;
    public float maxLimit = 70;
    public float minLimit = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpeedCheck();
        }
        
    }

    void SpeedCheck()
    {
        speed = distance / time;

        if(speed > 70)
        {
            print("You broken the law");
        }
        else if (speed < 40 )
        {
            print("You have to more faster");
        }
        else if (speed == 70 || speed == 40)
        {
            print("You almost get to the limit");
        }
        else
        {
            print("Keep your speed");
        }
    }
}
