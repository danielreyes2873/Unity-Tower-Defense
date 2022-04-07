using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public GameObject unit;
    public Player player;

    private int price = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnUnit()
    {
        while (true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitInfo.collider.gameObject.name.Equals("Tower(Clone)"))
                    {
                        var position = hitInfo.collider.gameObject.transform.position;
                        if (player.purse > price)
                        { 
                            Instantiate(unit,new Vector3(position.x,position.y + 1.5f, position.z), Quaternion.identity);
                            player.SubtractCoins(price);
                            Debug.Log($"Placing Unit Costs {price} coins");
                        }
                        else
                        {
                            Debug.Log("Not Enough Coins");
                            {
                                
                            }
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
