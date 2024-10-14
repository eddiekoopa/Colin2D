using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    static int health = 10;

    public static int PlayerHealth { get { return health; } }
    static bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!done)
        {
            SceneManager.LoadScene(HUDScene.SceneName, LoadSceneMode.Additive);

            done = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health--;
        }
    }

    private void OnDestroy()
    {
        SceneManager.UnloadSceneAsync(HUDScene.SceneName);
        done = false;
    }
}
