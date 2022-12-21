using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragManager : MonoBehaviour, IDragHandler , IBeginDragHandler,IEndDragHandler
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private GameObject plantTransparent;
    private Ray _ray;
    private RaycastHit _hit;
    private Vector3 _startPosition;

    private void Start()
    {
      
        plantTransparent.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = transform.position;
        Cursor.SetCursor(GameManager.instance.plantCursor,Vector2.zero,CursorMode.ForceSoftware);
        GameManager.instance.gameState = GameState.Planting;
        plantTransparent.SetActive(true);
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            Vector3 hitPoint = _hit.point;
            hitPoint.y = 0.5f;
            plantTransparent.transform.position = hitPoint;
        }
    }

  

    public void OnEndDrag(PointerEventData eventData)
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.CompareTag("EmptyLand") && plantPrefab.GetComponent<PlantVariables>().CalculateAndBuyPlant())
            {
              var spawnedPlant =   Instantiate(plantPrefab, _hit.transform.position, Quaternion.identity);
              spawnedPlant.transform.SetParent(_hit.transform);
              spawnedPlant.gameObject.transform.rotation = Quaternion.Euler(0,90,0);
              plantTransparent.SetActive(false);
              _hit.transform.tag = "FullLand";
            }
        }

        transform.position = _startPosition;
        plantTransparent.transform.position = _startPosition;
        GetComponent<Image>().color = new Color(1,1,1,1);
        transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 0, 1);
        plantTransparent.SetActive(false);
        Cursor.SetCursor(GameManager.instance.collectCursor,Vector2.zero, CursorMode.ForceSoftware);
        StartCoroutine(TransitionToCollecting());
    }
    
    IEnumerator TransitionToCollecting()
    {
        yield return new WaitForSeconds(.5f);
        GameManager.instance.gameState = GameState.Collecting;
    }
}


