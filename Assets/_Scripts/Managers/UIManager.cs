using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  
  public static UIManager instance;
  public GameObject removeShovel;
  [SerializeField] private TextMeshProUGUI sunText;
 
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
    UpdateCurrentSunText();

  }

  public void UpdateCurrentSunText()
  {
    sunText.text = GameManager.instance.sun.ToString();
  }

  public void SelectRemovePlant()
  {
    removeShovel.GetComponent<RemovePlant>().enabled = true;
  }
  
}
