using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sphere;
    float beat = 60.0f/143.0f;
    float timer = 0.0f;
    float mini_timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        sphere.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat){
            mini_timer = 1f;
            timer -= beat;
            Debug.Log("beat");
        }
        if (mini_timer > 0){
            sphere.SetActive(true);
            mini_timer -= Time.deltaTime;
        }
        else {
            sphere.SetActive(false);
        }

        timer += Time.deltaTime;
        Debug.Log(timer);
    }
}
