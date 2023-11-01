using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManeger : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;
    [SerializeField] private GameObject WinText;

    GameObject[] Level2; // A list of objects that is defind as level 2
    GameObject[] Level3; // A list of objects that is defind as level 3
    
    // resets all coins to Active and setting your score count to 0
    public static void CoinReset(){
        scoreCount = 0;
        GameObject.FindGameObjectWithTag("Coin").SetActive(true);

        Coin.ReSpawnCoin();
    }
    

    //A if function to check if Player can move to the next Level and if true opens the door
    private void DoorControl(){
        if (scoreCount >= 3 && scoreCount < 6){
            foreach(GameObject Level2 in Level2){
            Level2.SetActive(false);
        }
        }else if (scoreCount >= 6){
            foreach(GameObject Level3 in Level3){
            Level3.SetActive(false);
        }
        }else{
            foreach(GameObject Level2 in Level2){
            Level2.SetActive(true);
         } 
            foreach(GameObject Level3 in Level3){
            Level3.SetActive(true);
         }
        }

    }

// Display a Win Screen on gathering 7 coins
        IEnumerator Win(){
        WinText = GameObject.Find("Win");
        WinText.GetComponent<Text>().text = "You gatherd all Coins. YOU WIN";
        yield return new WaitForSeconds(10);
        WinText.GetComponent<Text>().text = "";
        scoreCount +=1 ; // Add one coin to stop the uppdate code to avoid flickers
    }
    
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Coins: " + Mathf.Round(scoreCount); // displays the amount of coin collected
        DoorControl();
        if(scoreCount == 7){
            StartCoroutine(Win());
            }

    }

    void Start(){
        // Defines the vergibols level 2 and 3 by assaging them with objocts with corosponding tags.
        Level2 = GameObject.FindGameObjectsWithTag("R1-R2");   
        Level3 = GameObject.FindGameObjectsWithTag("R2-R3");   
    }

}
