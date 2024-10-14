using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDScene : MonoBehaviour
{
    public static string SceneName { get { return "Scenes/HUD"; } }
    TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        // PLEEEEEEAAAAAAAAAASEEEEEEEEEEEEEEEEEEEEEEEEEEE

        //Debug.Assert(SceneManager.GetActiveScene().name != SceneName);
        healthText = GameObject.Find("txt").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(HUDManager.PlayerHealth.ToString());
    }
}
