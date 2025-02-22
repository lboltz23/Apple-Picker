using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject   basketPrefab;
    public int          numBaskets  = 4;
    public float        basketBottomY = -5f;
    public float        basketSpacingY = 1f;

    public List<GameObject> basketList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      basketList = new List<GameObject>();
      for(int i = 0; i < numBaskets; i++) {
        GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY + (basketSpacingY * i);
        tBasketGO.transform.position = pos;
        basketList.Add( tBasketGO );
      }  
    }

    public void AppleMissed() {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }
    
        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt( basketIndex);
        Destroy( basketGO );

        if (basketList.Count == 0) {
            Time.timeScale = 0;
        }
    }
    public void PoisonAppleMissed() {
      GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Poison");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
