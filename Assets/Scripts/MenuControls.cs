using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    [SerializeField]
    private Button ExitButton;
    [SerializeField]
    private Button StartButton;
    private bool paused;
    public void PlayPressed() 
    { 
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            ExitButton.gameObject.SetActive(false);
            StartButton.gameObject.SetActive(false);
            Time.timeScale = 1;
            paused=false;
        }else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }

    public void ExitPressed() 
    { 
        Application.Quit(); 
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1 )
        {
            
            if(!paused)
            {
                ExitButton.gameObject.SetActive(true);
                StartButton.gameObject.SetActive(true);
                Time.timeScale = 0;
                paused=true;
            }else
            {
                ExitButton.gameObject.SetActive(false);
                StartButton.gameObject.SetActive(false);
                Time.timeScale = 1;
                paused=false;
            }
        }
    }

    public void InfoPressed()
    {
        ExitButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        paused=true;
    } 
}
