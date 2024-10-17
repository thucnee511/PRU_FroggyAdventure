using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private BearPosition[] bearPosition = new BearPosition[]{
        new BearPosition{posX = 10, posY = 10},
        new BearPosition{posX = 34, posY = 10},
        new BearPosition{posX = -12, posY = 30},
        new BearPosition{posX = 25, posY = 40},
        new BearPosition{posX = 20, posY = 55},
    };
    // Start is called before the first frame update
    void Start()
    {
        SpawnBear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBear(){
        foreach (var bearPos in bearPosition)
        {
            GameObject bear = Instantiate(Resources.Load("Prefabs/Bear"),new Vector3(bearPos.posX,bearPos.posY, 0), Quaternion.identity) as GameObject;
            bear.GetComponent<BearScript>().startX = bearPos.posX - 10;
            bear.GetComponent<BearScript>().endX = bearPos.posX + 10;
            bear.GetComponent<BearScript>().Player = player;
        }
    }
}

class BearPosition{
    public float posX;
    public float posY;
}
