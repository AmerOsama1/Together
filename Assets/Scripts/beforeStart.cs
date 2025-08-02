using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class beforeStart : MonoBehaviour
{
    public TextMeshProUGUI t;
    public GameObject TT;
    public Movement mv;
    Collider[] co;
    public float Ti = 5f;
    Camera cam;

    void Awake()
    {
        Invoke("ss", .5f);
        TT.SetActive(false);
    }

    void Update()
    {
        t.text = Ti.ToString("0");
        Ti -= 1 * Time.deltaTime;

        if (Ti <= 0)
        {
            foreach (var item in co)
            {
                if (item != null && item.CompareTag("Player"))
                {
                    cam = item.GetComponentInChildren<Camera>();
                    mv = item.GetComponent<Movement>();

                    if (mv != null)
                    {
                        mv.enabled = true;
                    }
                }
            }

            Destroy(gameObject, .5f); 
        }

        if (Ti <= 7)
        {
            if (cam != null)
            {
                cam.enabled = true;
            }
            TT.SetActive(true);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 300);
    }

    void ss()
    {
        co = Physics.OverlapSphere(transform.position, 300f);
        foreach (var item in co)
        {
            if (item != null && item.CompareTag("Player"))
            {
                mv = item.GetComponent<Movement>();
                cam = item.GetComponentInChildren<Camera>();

                if (mv != null)
                {
                    mv.enabled = false;
                }

                if (cam != null)
                {
                    cam.enabled = false;
                }
            }
        }
    }
}
