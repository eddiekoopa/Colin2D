using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string mainRoom;
    public GameObject loadObj;

    public string[] arrayTest;
    public ArrayList arrayTest2 = new ArrayList();

    void Start()
    {
        Debug.Log($"Check loading obj ...");

        Debug.Assert(loadObj != null);
        loadObj.GetComponent<SpriteRenderer>().enabled = false;

        Debug.Log($"Init was successful !");
    }

    void FixedUpdate()
    {
        Update();
    }

    // Update is called once per frame
    bool isnowloading = false;
    void Update()
    {
        if (isnowloading)
        {
            Debug.Log($"Test array ...");

            arrayTest2 = new ArrayList();
            arrayTest2.Add("value1");
            arrayTest2.Add("value2");

            for (int i = 0; i < arrayTest.Length; i++)
            {
                Debug.Log($"ARRAY_ELM: " + arrayTest[i].ToString());
            }

            for (int i = 0; i < arrayTest2.Count; i++)
            {
                Debug.Log($"ARRAY2_ELM: " + arrayTest2[i].ToString());
            }

            SceneManager.LoadScene(mainRoom);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log($"Pushed.");
                loadObj.GetComponent<SpriteRenderer>().enabled = true;
                isnowloading = true;
            }
        }
    }
}
