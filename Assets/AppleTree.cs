using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject   applePrefab;
    public GameObject   poisonPrefab;
    public float        speed = 1f;

    public float        leftAndRightEdge = 10f;

    public float        changeDirChance = 0.1f;

    public float        appleDropDelay = 1f;

    public float        poisonAppleDropDelay = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke( "DropApple", 2f);
        Invoke( "DropPoisonApple", 3f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>( applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);

    }

    void DropPoisonApple() {
        GameObject poison = Instantiate<GameObject>( poisonPrefab);
        poison.transform.position = transform.position;
        Invoke("DropPoisonApple", poisonAppleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if(pos.x <-leftAndRightEdge) {
            speed = Mathf.Abs(speed); //Move right
        } else if(pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        //} else if (Random.value < changeDirChance) {
        //    speed *= -1; // Change direction
        }
        
        
    }

    void FixedUpdate() {
        //Random direction changes are now time-based due to FixedUpdate() 
        if (Random.value < changeDirChance) {
            speed *= -1;
        }
    }
}
