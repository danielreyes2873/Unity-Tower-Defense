using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject start;
    public GameObject restart;
    
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        restart.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        start.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Tower Defense Pt. 1 Demo");
    }
}
