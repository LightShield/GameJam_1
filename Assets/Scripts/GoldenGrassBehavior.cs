using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGrassBehavior : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 100f;
    [SerializeField]
    private float floatingDistance = 0.005f; //amplitude of floating sin wav
    [SerializeField]
    private float floatingSpeed = 1f; // frequency of floating sin wav
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime); //spin
        Vector3 tempPosition = transform.position;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatingSpeed) * floatingDistance; //levitate
        transform.position = tempPosition;
    }
}
