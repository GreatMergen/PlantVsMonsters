using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButtons;
    [SerializeField] private GameObject optionsMenuButtons;
    public GameObject  level2Button, level3Button, level4Button, level5Button, level6Button;

    private void Start()
    {
        LevelLock();
    }
    
    public void StartGame()
   {
       AudioManager.instance.Play("ClickSound");
       SceneManager.LoadScene("LevelSelectScene");
   }

   public void OpenOptionMenu()
   {
       AudioManager.instance.Play("ClickSound");
       if (optionsMenuButtons.activeSelf == false)
       {
           optionsMenuButtons.SetActive(true);
           mainMenuButtons.SetActive(false);
       }
   }
   public void CloseOptionMenu()
   {
       AudioManager.instance.Play("ClickSound");
       optionsMenuButtons.SetActive(false);
       mainMenuButtons.SetActive(true);
   }
   public void ExitGame()
   {
       AudioManager.instance.Play("ClickSound");
       Application.Quit();
   }
   public void BackToMainMenu()
   {
       AudioManager.instance.Play("ClickSound");
       SceneManager.LoadScene("MainMenu");
   }
   public void OpenLevel(String levelName)
   {
       AudioManager.instance.Play("ClickSound");
       SceneManager.LoadScene(levelName);
   }

   public void OpenYoutube()
   {
       Application.OpenURL("https://www.youtube.com/channel/UCky2ZiAeSBE3RAKAUyUvJ-g");
   }
   public void LevelLock()
   {
       if (SceneManager.GetActiveScene().buildIndex != 1) return;
       
       if (SaveSystem.instance.level2Save == 1)
       {
           level2Button.GetComponent<Button>().interactable = true;
       }
       if (SaveSystem.instance.level3Save == 1)
       {
           level3Button.GetComponent<Button>().interactable = true;
       }
       if (SaveSystem.instance.level4Save == 1)
       {
           level4Button.GetComponent<Button>().interactable = true;
       }
       if (SaveSystem.instance.level5Save== 1)
       {
           level5Button.GetComponent<Button>().interactable = true;
       }
       if (SaveSystem.instance.level6Save== 1)
       {
           level6Button.GetComponent<Button>().interactable = true;
       }
   }
}
