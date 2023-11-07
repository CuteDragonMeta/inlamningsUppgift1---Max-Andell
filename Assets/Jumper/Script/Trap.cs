using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{   
    private CharacterController cc;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GameOverText;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Player = other.gameObject; // Assigns the veriabel player with the object with colided with the GameObject
             cc = other.GetComponent<CharacterController>();
            PlayerDeath(); 
            StartCoroutine(GameOver()); 
        }
    } 

// Displays a GameOverScreen
    IEnumerator GameOver(){
        GameOverText = GameObject.Find("GameOver");
        GameOverText.GetComponent<Text>().text = "GAME OVER. Try Again";
        cc.enabled = false; // disaple movement
        yield return new WaitForSeconds(5); // creats a wait in order for the Player to read the text
        GameOverText.GetComponent<Text>().text = "";
        cc.enabled = true; // enable movement
    }

    void PlayerDeath(){
        cc.enabled = false;
        Player.transform.position = PlayerMovement.startPosition; // resets player to start posision
        cc.enabled = true;
        ScoreManeger.CoinReset();
    }
}
