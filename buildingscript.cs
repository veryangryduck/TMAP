using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingscript : MonoBehaviour
{
    [SerializeField] GameObject car;
    bool sendcars;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
       // Debug.Log(sendcars);
        
    }
    IEnumerator waiter() 
    {
        sendcars = GameObject.Find("Controller").GetComponent<mainscript>().sendcars;
        Debug.Log("Here");
        while (sendcars)
        {


            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
            try
            {
                Instantiate(car, (Vector2)transform.position + new Vector2(.6f,0), new Quaternion(), transform);
            }
            catch (Exception) { }

        }
       
        yield return null;
    }
}
