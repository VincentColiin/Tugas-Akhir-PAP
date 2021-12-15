using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UI;

public class MainMenuScreenBehaviors : MonoBehaviour
{
    // public Button 
    public Button playButton;
    public Button quitButton;
    public Button visitSourceCodeButton;

    // Start is called before the first frame update
    void Start()
    {
        ///constrcuctor?
        if (playButton) {
            Button playButtonEl = playButton.GetComponent<Button>();
            playButtonEl.onClick.AddListener(OnPlayButtonClick);
        }
        if (quitButton) {
            Button quitButtonEl = quitButton.GetComponent<Button>();
            quitButtonEl.onClick.AddListener(OnQuitButtonClick);
        }
        if (visitSourceCodeButton) {
            Button visitSourceCodeButtonEl = visitSourceCodeButton.GetComponent<Button>();
            visitSourceCodeButton.onClick.AddListener(() => {
                Application.OpenURL("https://github.com/VincentColiin/Tugas-Akhir-PAP");
            });
        }
    }

    private void OnPlayButtonClick() {
        Debug.Log("yo! play yo!");
    }

    private void OnQuitButtonClick() {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
