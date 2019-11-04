using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Heal_base : MonoBehaviour
{
    public Heal_orb orb_link;
    public Transform orb_start_location;
    public Transform orb_end_location;
    public float arm_time_seconds = 5.0f;

    private Heal_orb orb;
    private float arm_timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Create associated orb
        orb = Instantiate(orb_link, transform.position + orb_start_location.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location_diff = orb_end_location.position - orb_start_location.position;

        if (orb != null)
        {
            if (arm_timer < arm_time_seconds)
            {
                arm_timer += Time.deltaTime;

                // Update the orb's             
                orb.transform.position = transform.position + orb_start_location.localPosition + location_diff * (arm_timer / arm_time_seconds);
            }
            else
            {
                // Final location update
                orb.transform.position = transform.position + orb_start_location.localPosition + location_diff;

                orb.OnReady();
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (orb != null)
        {
            orb.Destroy();
        }
    }
}
