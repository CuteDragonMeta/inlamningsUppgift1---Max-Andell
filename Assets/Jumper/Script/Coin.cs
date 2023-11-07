using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private static GameObject[] CoinStat;

    private void OnTriggerEnter(Collider other){
    if(other.gameObject.tag == "Player"){
        gameObject.SetActive(false);  // Removes the coin from the Game
        ScoreManeger.scoreCount += 1; // adds 1 to the scoure
    }   
}

    public static void ReSpawnCoin(){
        foreach(GameObject CoinStat in CoinStat){
            CoinStat.SetActive(true); // Actives all coins
        }
    }     

    void Start(){
        CoinStat = GameObject.FindGameObjectsWithTag("Coin");    // defins CoinStat by all gameObjects with the tag Coin

    }

}
