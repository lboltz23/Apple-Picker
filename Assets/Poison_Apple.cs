using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Apple : MonoBehaviour
{
    public static float     bottomY = -20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < bottomY ) {
            Destroy( this.gameObject);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.PoisonAppleMissed();
        }
        

    }
}
