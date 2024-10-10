using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CutsceneManager : MonoBehaviour
{
    public string myText;
    public int myDelay;
    public int myDelayWait;
    public string myNextScene;

    private TMP_Text mTextPro;
    private string typer;
    private float tick;
    private int idx;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        typer = "";
        tick = 0;
        mTextPro = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If did not reach the text boundary.
        if (idx >= myText.Length)
        {
            // then we done!
            done = true;
        }
        
        if (!done)
        {
            // If tick reaches delay tick
            if (tick++ >= myDelay)
            {
                // Reset Tick
                tick = 0;
                // Add character to the typer
                typer += myText[idx++];
                // Update the typer
                mTextPro.text = typer;
                new WaitForNextFrameUnit();
            }
        }
        else if (done)
        {
            Debug.Log($"Cutscene has been done.");
            mTextPro.text = myText; // When we skip it, it might not display the full text. So we do it ourselves.

            Debug.Log($"Defined Scene will be loaded.");
            SceneManager.LoadScene(myNextScene);
        }
    }

    private void Update()
    {
        // Pressing any key skips.
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            done = true;
        }
    }
}
