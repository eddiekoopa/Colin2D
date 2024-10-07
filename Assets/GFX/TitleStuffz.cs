using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class TitleStuffz : MonoBehaviour
{
    // Start is called before the first frame update
    public string mainRoom = "SomeScene";
    void Start()
    {
        GameObject.Find("temp1_0").GetComponent<SpriteRenderer>().enabled = false;
    }

    void FixedUpdate()
    {   
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.Find("temp1_0").GetComponent<SpriteRenderer>().enabled = true;
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.Find("temp1_0").GetComponent<SpriteRenderer>().enabled = true;

            SceneManager.LoadScene(1);
        }
    }
}
