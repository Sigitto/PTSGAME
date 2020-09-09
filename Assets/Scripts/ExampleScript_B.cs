using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript_B : MonoBehaviour
{
    private int enemyDistance = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySearch()
    {
        for(int i = 0; i < 5; i++)
        {
            enemyDistance = Random.Range(1, 10);

            if(enemyDistance >= 8)
            {
                print("Enemies are far away"); 
            }
        }
    }
}
