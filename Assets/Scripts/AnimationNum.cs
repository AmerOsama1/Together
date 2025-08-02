using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNum : MonoBehaviour
{
    public float moveDistance = 0.2f;
    public float moveSpeed = 1f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
