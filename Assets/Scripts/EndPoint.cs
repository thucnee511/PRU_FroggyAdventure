using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endMenu;
    public GameObject defaultUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Checkpoint()
    {
        GetComponent<Animator>().SetTrigger("Checked");

    }

    public void DisplayUI()
    {
        endMenu.SetActive(true);
        defaultUI.SetActive(false);
    }
}
