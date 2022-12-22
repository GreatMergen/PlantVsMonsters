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
      gameState = GameState.Collecting;
      Cursor.visible = true;
      Cursor.SetCursor(collectCursor,Vector2.zero,CursorMode.ForceSoftware);
      SaveSystem.instance.LoadSave();
      QualitySettings.SetQualityLevel(2);
   }
   
   private void Update()
   {
      CollectFunction();
      
      if (Input.GetKeyDown(KeyCode.A))
      {
       
      }
      
      if (Input.GetKeyDown(KeyCode.T))
      {
         AudioManager.instance.Play("hitHurt");
      }
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
      GameMenu.instance.WinScreenEnable();
      Time.timeScale = 0;
      //sesler efectler falan burada
   }
   public void Dead()
   {
      GameMenu.instance.DeathScreenEnable();
      Time.timeScale = 0;
   }

   
  
}
