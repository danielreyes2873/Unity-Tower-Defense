using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class Tower : MonoBehaviour
{

    public int starthealth = 10;
    public float health;
    public Image healthbar;
    public GameObject restart;
    
    // Start is called before the first frame update
    void Start()
    {
        health = starthealth;
        StartCoroutine(MouseClickDamage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        health -= damage;
        //healthbar.fillAmount = health / starthealth;
        Debug.Log($"Tower Health: {health}");
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
            StartCoroutine(Die());
        }
    }
    
    IEnumerator Die()
    {
        var p = gameObject.GetComponent<ParticleSystem>();
        var m = gameObject.GetComponent<MeshRenderer>();
        //var c = transform.GetChild(1).gameObject;
        p.Play();
        m.enabled = false;
        //c.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        restart.SetActive(true);
    }
    
    IEnumerator MouseClickDamage()
    {
        while (true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitInfo.collider.gameObject.name.Equals("Tower"))
                    {
                        this.Damage(1);
                    }
                }
            }
            yield return null;
        }
    }
    
}
