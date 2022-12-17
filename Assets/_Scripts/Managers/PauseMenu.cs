using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public GameObject pauseScreen;
   public static bool gamePaused;


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

}
