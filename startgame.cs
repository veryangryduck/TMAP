using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startgame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void StartGame() 
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
