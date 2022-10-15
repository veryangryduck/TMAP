using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainscript : MonoBehaviour
{
    public GameObject road;
    private Vector2[] roadStart = new Vector2[2];
    [SerializeField] private bool buildingRoad = false;
    [SerializeField] GameObject intersection;
    [SerializeField] GameObject building;
    public List<Vector2> intersections = new List<Vector2>();
    public List<Vector2> destinations = new List<Vector2>();
    int numbuildings = 0;
    public bool sendcars = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) Application.Quit();
        
        //building
        if (Input.GetKeyDown("a"))
        {
            GameObject newbuilding = Instantiate(building, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion());
            numbuildings++;
            //if (numbuildings > 1) sendcars = true;
            sendcars = true;
            newbuilding.transform.position = new Vector3(newbuilding.transform.position.x, newbuilding.transform.position.y, 0);
            destinations.Add(newbuilding.transform.position);
            foreach (var destination in destinations) 
            {
                Debug.Log(destination);
            }
        }
        //intersection
        if (Input.GetKeyDown("s"))
        {
            GameObject newinter = Instantiate(intersection, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion());
            newinter.transform.position = new Vector3(newinter.transform.position.x, newinter.transform.position.y, 0);
            intersections.Add(newinter.transform.position);
        }

        //road building
        if (Input.GetMouseButtonDown(0) && !buildingRoad)
        {
            //set beggining of road
            buildingRoad = true;
            roadStart[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonDown(0) && buildingRoad)
        {
            buildingRoad = false;
            roadStart[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D testRay = Physics2D.Raycast(roadStart[0], roadStart[1], Vector3.Distance(roadStart[0], roadStart[1]));
            Debug.Log(testRay);
            if (testRay.collider != null)
            {
                //Instantiate(intersection, testRay.point, new Quaternion());
            }
            GameObject curRoad = Instantiate(road);

            curRoad.GetComponent<LineRenderer>().SetPosition(0,new Vector3(roadStart[0].x, roadStart[0].y));
            curRoad.GetComponent<LineRenderer>().SetPosition(1,new Vector3(roadStart[1].x, roadStart[1].y));
            //add box collider to road
            BoxCollider2D col = new GameObject("collider").AddComponent<BoxCollider2D>();
            //col.GetComponent<BoxCollider2D>().isTrigger = true;
            col.transform.parent = curRoad.transform;
            Vector3 mid = (roadStart[0] + roadStart[1]) / 2;
            col.size = new Vector3(Vector3.Distance(roadStart[0], roadStart[1]), 0.5f,0);
            col.transform.position = mid;
            float angle = (Mathf.Abs(roadStart[0].y - roadStart[1].y) / Mathf.Abs(roadStart[0].x - roadStart[1].x));
            if ((roadStart[0].y < roadStart[1].y && roadStart[0].x > roadStart[1].x) || (roadStart[1].y < roadStart[0].y && roadStart[1].x > roadStart[0].x))
            {
                angle *= -1;
            }
            angle = Mathf.Rad2Deg * Mathf.Atan(angle);
            col.transform.Rotate(0, 0, angle);

            

        }
        

    }


    private void OnMouseOver()
    {
        //Debug.Log("good");
       
        
    }
    
    
        
    
}
    