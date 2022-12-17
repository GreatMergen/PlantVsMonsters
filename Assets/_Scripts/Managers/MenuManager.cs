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
    public GameObject level1Button, level2Button, level3Button, level4Button, level5Button, level6Button;

    private void Start()
    {
        LevelLock();
    }

    private void Update()
    {
       
    }

    public void StartGame()
   {
       SceneManager.LoadScene("LevelSelectScene");
   }

   public void OpenOptionMenu()
   {
       if (optionsMenuButtons.activeSelf == false)
       {
           optionsMenuButtons.SetActive(true);
           mainMenuButtons.SetActive(false);
       }
   }
   public void CloseOptionMenu()
   {
       optionsMenuButtons.SetActive(false);
       mainMenuButtons.SetActive(true);
   }
   public void ExitGame()
   {
       Application.Quit();
   }
   public void BackToMainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }
   public void OpenLevel1()
   {
       SceneManager.LoadScene("Level1");
   }
   public void OpenLevel2()
   {
       SceneManager.LoadScene("Level2");
   }
   public void OpenLevel3()
   {
       SceneManager.LoadScene("Level3");
   }
   public void OpenLevel4()
   {
       SceneManager.LoadScene("Level4");
   }
   public void OpenLevel5()
   {
       SceneManager.LoadScene("Level5");
   }
   public void OpenLevel6()
   {
       SceneManager.LoadScene("Level6");
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
