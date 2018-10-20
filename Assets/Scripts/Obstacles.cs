using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacles : MonoBehaviour
{
    public Transform obstacle;
    public GameObject ball;
    public Text countDown, score;

    private bool started = false;
    private float changeSpeedFrequency = 2f, objSpeed = 0.1f;
    private float increaseDifficultyFrequency = 2f, spawnTimer = 3f;
    private bool didCreate;
    private List<Transform> objects;
    private int counter = 0;


    void Start()
    {
        Game.isGameOver = false;
        didCreate = false;
        objects = new List<Transform>();
        StartCoroutine("DoStart");
    }

    IEnumerator DoStart()
    {
        for (int i = 0; i <= 3; i++)
        {
            countDown.text = Convert.ToString(3 - i);

            if (i == 3)
            {
                countDown.text = "GO!";
            }
            yield return new WaitForSeconds(1f);
        }

        started = true;
        countDown.enabled = false;
        StartCoroutine("DoCreate");
    }

    IEnumerator DoCreate()
    {
        while (!Game.isGameOver)
        {
            Create();
            counter++;
            yield return new WaitForSeconds(spawnTimer);
        }

    }


    void Update()
    {
        int seconds = (int)Mathf.Floor(Time.time);

        if (didCreate)
        {
            var obj = GameObject.Find("Obstacle " + (counter - 1)).transform;
            objects.Add(obj);
            didCreate = false;
        }

        foreach (var obj in objects.ToArray())
        {
            obj.transform.Translate(0, 0, -objSpeed);

            if (obj.transform.position.z < ball.transform.position.z)
            {
                objects.Remove(obj);
                Destroy(obj.gameObject);
            }
        }

        if (started && !Game.isGameOver)
        {
            double s = Math.Round(Time.timeSinceLevelLoad * objSpeed * 5, 1);
            score.text = "Score: " + Convert.ToString(s);
            Game.score = s;
        }

        if (seconds % increaseDifficultyFrequency == 0)
        {
            if(spawnTimer > 0.3f)
                spawnTimer -= 0.1f * Time.deltaTime;
        }
        if (seconds % changeSpeedFrequency == 0)
        {
            objSpeed += 0.01f * Time.deltaTime;
        }
    }

    Transform Create()
    {
        int randomZ = UnityEngine.Random.Range(40, 70);
        float randomX = UnityEngine.Random.Range(-1.5f, 1.5f);

        Vector3 ballPos = ball.transform.position;
        Vector3 pos = new Vector3(randomX, 1, (int)ballPos.z + randomZ);
        didCreate = true;
        var obj = Instantiate(obstacle, pos, Quaternion.identity);
        obj.name = "Obstacle " + counter;
        return obj;
    }
}
