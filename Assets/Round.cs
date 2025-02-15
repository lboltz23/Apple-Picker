using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Round : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;
    private Text ui2Text;

    public ApplePicker applePicker;
    public AppleTree appleTree;
    public float  timeBetween = 7f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     ui2Text = GetComponent<Text>();
     applePicker = Camera.main.GetComponent<ApplePicker>(); 
     appleTree = FindAnyObjectByType<AppleTree>();

     

     Invoke("ChangeRound", timeBetween);
    }

    // Update is called once per frame
    void Update()
    {
      int numBaskets = applePicker.basketList.Count; 
      if (numBaskets == 0) {
        ui2Text.text = "Game Over";
      }
      else if( round > 4) {
        ui2Text.text = "You Win!";
      }
      
      else {
        ui2Text.text = "Round " + round;
      }
    }
    void ChangeRound() 
    {  
      round++;
      
      appleTree.appleDropDelay = appleTree.appleDropDelay * 0.9f;
      appleTree.poisonAppleDropDelay = appleTree.poisonAppleDropDelay * 0.9f;
      appleTree.speed = appleTree.speed * 1.1f;
      if(round > 4) {
        ui2Text.text = "You Win!";
        Time.timeScale = 0;
      }
      else{
      Invoke("ChangeRound", timeBetween);
      }
    }
}
