using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
   Planting,Collecting,Removing
}

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public int sun;
   public GameState gameState;
   public Texture2D collectCursor;
   public Texture2D plantCursor;
   public Texture2D removeCursor;
   
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
   
   private void Start()
   {
      Time.timeScale = 1;
      CollectState();
      SaveSystem.instance.LoadSave();
      QualitySettings.SetQualityLevel(2);
   }

   private void CollectState()
   {
      gameState = GameState.Collecting;
      Cursor.visible = true;
      Cursor.SetCursor(collectCursor, Vector2.zero, CursorMode.ForceSoftware);
   }

   private void Update()
   {
      CollectFunction();
      
   }
   
   void CollectFunction()
   {
      if (GameManager.instance.gameState != GameState.Collecting) return;
      if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) return;
      if (hit.collider.CompareTag("Sun") && Input.GetMouseButtonDown(0))
      {
         hit.collider.GetComponent<Sun>().CollectSun();
      }
   }
   
   public void Win()
   {
      SaveSystem.instance.LevelCompletedSave(SceneManager.GetActiveScene().buildIndex);
      GameMenu.instance.WinScreenEnable();
      AudioManager.instance.Stop("LevelMusic");
      AudioManager.instance.Play("WinGame");
      
      Time.timeScale = 0;
      //sesler efectler falan burada
   }
   public void Dead()
   {
      GameMenu.instance.DeathScreenEnable();
      AudioManager.instance.Stop("LevelMusic");
      AudioManager.instance.Play("LostGame");
      Time.timeScale = 0;
   }
}
