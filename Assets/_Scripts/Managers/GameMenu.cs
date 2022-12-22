using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
   public static GameMenu instance;
   public GameObject pauseScreen;
   public static bool gamePaused;
   public GameObject winScreen;
   public GameObject deathScreen;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

   private void Update()
   {
      if (!Input.GetKeyDown(KeyCode.Escape)) return;
      if (gamePaused)
      {
         ContinueGame();
      }
      else
      {
         PauseGame();
      }
   }


   public void PauseGame()
   {
      Time.timeScale = 0;
      gamePaused = true;
      pauseScreen.SetActive(true);
      pauseScreen.transform.GetChild(1).gameObject.SetActive(true);
      pauseScreen.transform.GetChild(2).gameObject.SetActive(false);
   }

   public void ContinueGame()
   {
      Time.timeScale = 1;
      gamePaused = false;
      pauseScreen.SetActive(false);
   }

   public void WinScreenEnable()
   {
      winScreen.gameObject.SetActive(true);
   }

   public void DeathScreenEnable()
   {
      deathScreen.gameObject.SetActive(true);
   }
   
   
   public void NextLevel()
   {
      SaveSystem.instance.LevelCompletedSave(SceneManager.GetActiveScene().buildIndex);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void ReturnToMainMenu()
   {
      SceneManager.LoadScene(0);
   }

   public void RestartLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
