using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
	
	public Transform obstacle;
    public GameObject ball;

    private float frequency = 2f, objSpeed = 0.1f;
    private bool didCreate;
    private List<Transform> objects;
    private int counter = 0;
   

    void Start()
    {
        didCreate = false;
        StartCoroutine("DoCreate");
        objects = new List<Transform>();
    }

    IEnumerator DoCreate()
    {
        while(true)
        {
            var obj = Create();
            counter++;
            yield return new WaitForSeconds(frequency);
        }
    }


    void Update()
    {
        int seconds = (int)Mathf.Floor(Time.time);

        if(didCreate)
        {
            var obj = GameObject.Find("Obstacle " + (counter - 1)).transform;
            objects.Add(obj);
            didCreate = false;
        }

        foreach (var obj in objects.ToArray())
        {
            obj.transform.Translate(0, 0, -objSpeed);

            if(obj.transform.position.z < ball.transform.position.z)
            {
                objects.Remove(obj);
                Destroy(obj.gameObject);
            }
        }


        if(seconds % frequency == 0)
        {
            objSpeed += 0.01f * Time.deltaTime;
        }
    }
    
    Transform Create()
    {
        int randomZ = Random.Range(20, 30);
        float randomX = Random.Range(-1.5f, 1.5f);

        Vector3 ballPos = ball.transform.position;
        Vector3 pos = new Vector3(randomX, ballPos.y, (int)ballPos.z + randomZ);
        didCreate = true;
        var obj = Instantiate(obstacle, pos, Quaternion.identity);
        obj.name = "Obstacle " + counter;
        return obj;
    }
}
