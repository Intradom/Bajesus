using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_bob : MonoBehaviour
{
    public float bob_distance = 5f;

    private float traveled;
    private int dir;

    // Start is called before the first frame update
    void Start()
    {
        traveled = bob_distance / 2;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep going
        if (traveled < bob_distance)
        {

        }
        else // Reverse
        {
            dir *= -1;
        }


    }
}
