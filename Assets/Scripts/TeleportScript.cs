using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] private Transform target;

    public Transform GetTarget(){
        return target;
    }
}
