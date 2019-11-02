using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_behavior : MonoBehaviour
{
    public GameObject trigger;
    public Object next_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == trigger.name)
        {
            SceneManager.LoadScene(next_scene.name);
        }
    }
}
