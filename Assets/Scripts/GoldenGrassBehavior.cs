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

    public GameObject floor; //used to calculate random location generation
    public float mapTolerance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = createRandomInBoundsLocation();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime); //spin
        Vector3 tempPosition = transform.position;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatingSpeed) * floatingDistance; //levitate
        transform.position = tempPosition;
    }

    public void creatNewGrass(GameObject oldGrass)
    {
        Vector3 newPosition = createRandomInBoundsLocation();
        GameObject newGrass = Instantiate(oldGrass, newPosition, Quaternion.identity) as GameObject;
        newGrass.transform.parent = oldGrass.transform.parent;
    }

    private Vector3 createRandomInBoundsLocation()
    {
        
        float x = Random.Range(-10f + mapTolerance, 10f - mapTolerance);
        float z = Random.Range(-10f + mapTolerance, 10f - mapTolerance);
        return new Vector3(x, 1f, z);
    }

}
