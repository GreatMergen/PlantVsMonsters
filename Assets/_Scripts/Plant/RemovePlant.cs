using System;
using UnityEngine;



public class RemovePlant : MonoBehaviour
{
    private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                enabled = false;
                GameManager.instance.gameState = GameState.Collecting;
                Cursor.SetCursor(GameManager.instance.collectCursor,Vector2.zero,CursorMode.ForceSoftware);
            }
            else
            {
                GameManager.instance.gameState = GameState.Removing;
                Cursor.SetCursor(GameManager.instance.removeCursor,Vector2.zero,CursorMode.ForceSoftware);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("FullLand") && Input.GetMouseButtonDown(0))
                    {
                       hit.collider.transform.GetChild(0).transform.GetComponent<PlantVariables>().SellPlant();
                       hit.collider.tag = "EmptyLand";
                       
                       enabled = false;
                       GameManager.instance.gameState = GameState.Collecting;
                       Cursor.SetCursor(GameManager.instance.collectCursor,Vector2.zero,CursorMode.ForceSoftware);
                    }
                  
                }
               
            }
        }
       
    }
