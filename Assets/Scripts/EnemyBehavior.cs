using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : AnyPlayerBehavior
{
    [Header("Behavior Data")]
    public float CollectionChance = 0.5f;
    public bool collectionMode;
    public bool aggressiveMode;
    private GameObject target; //target to pursue - collectable\ player

    // Start is called before the first frame update
    void Start()
    {
        chooseBehavior();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        { // the grass i was pursuing was collected \ destroyed
            target = findNearestCollectable();
        }
        Vector3 directonToMove = (target.transform.position - player.transform.position).normalized;
        directonToMove = new Vector3(directonToMove.x, 0f, directonToMove.z);
        player.AddForce(directonToMove * movmentSpeed);
    }
    override public void OnTriggerEnter(Collider other)
    {
        chooseBehavior();
    }

    public void correctAfterCollision() {
        chooseBehavior();
    }

    private void chooseBehavior()
    {
        float behavior = Random.Range(0f, 1f);
        if (behavior <= CollectionChance)
        {
            collectionMode = true;
            aggressiveMode = false;
            target = findNearestCollectable();
            //Debug.Log("collection");
        }
        else
        {
            aggressiveMode = true;
            collectionMode = false;
            //Debug.Log("aggression");
            target = GameObject.FindWithTag("Player");
        }
    }

    private GameObject findNearestCollectable()
    {
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Grass");
        var minDistance = Mathf.Infinity;
        GameObject nearest = collectables[0];
        foreach (GameObject grass in collectables)
        {
            var distance = Vector3.Distance(grass.transform.position, this.transform.position);
            if(distance < minDistance)
            {
                distance = minDistance;
                nearest = grass;
            }
        }
        return nearest;
    }

}
