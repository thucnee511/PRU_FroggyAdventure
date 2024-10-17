using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCollectTrigger()
    {
        GetComponent<Animator>().SetTrigger("Collect");
    }

    public void DestroyItem(){
        Destroy(gameObject);
    }
}
