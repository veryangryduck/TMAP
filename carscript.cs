using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carscript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] Vector2 smallest;
    Vector2 temp;
    [SerializeField] private List<Vector2> intersections;
    [SerializeField] private List<Vector2> destinationlist;
    [SerializeField]Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {

        destinationlist = new List<Vector2>(GameObject.Find("Controller").GetComponent<mainscript>().destinations);
        destinationlist.Remove(gameObject.transform.parent.transform.position);
        destination = destinationlist[Random.Range(0, destinationlist.Count)];
        intersections = new List<Vector2>(GameObject.Find("Controller").GetComponent<mainscript>().intersections) ;
        intersections.Add(destination);
        rigidbody = GetComponent<Rigidbody2D>();
        smallest = intersections[0];
        foreach (Vector2 intersection in intersections) 
        {
            
            if (Vector2.Distance(transform.position, intersection) < Vector2.Distance(transform.position, smallest)) 
            {
                smallest = intersection;
            } 
        }
        intersections.Remove(smallest);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), smallest, 1 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Vector2.Distance(new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), destination) < 0.5)
        {

            Destroy(this.gameObject);
        }
        if (intersections.Count > 0)
        {
            
            
            smallest = intersections[0];
            
            foreach (Vector2 intersection in intersections)
            {

                if (Vector2.Distance(transform.position, intersection) < Vector2.Distance(transform.position, smallest))
                {
                    Debug.Log("Here");
                    smallest = intersection;
                }
            }
            intersections.Remove(smallest);
        }
        else 
        {
            intersections = new List<Vector2>(GameObject.Find("Controller").GetComponent<mainscript>().intersections);
            smallest = intersections[0];

            foreach (Vector2 intersection in intersections)
            {

                if (Vector2.Distance(transform.position, intersection) < Vector2.Distance(transform.position, smallest))
                {
                    Debug.Log("Here");
                    smallest = intersection;
                }
            }
            intersections.Remove(smallest);
        }
        
        //Debug.Log(smallest);
    }
    private void OnTriggerExit(Collider other)
    {
        //intersections.Add(smallest);
    }
}
