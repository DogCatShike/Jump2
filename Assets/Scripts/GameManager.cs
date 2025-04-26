using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public static bool isGameOver;

    public GameObject gameOver;
    public GameObject player;

    void Awake() {
        instance = this;
    }

    void Update() {
        Debug.Log(isGameOver);
    }

    public void GameOver() {
        isGameOver = true;
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void OnRestartClick() {
        gameOver.SetActive(false);
        player.transform.position = Vector3.zero;
        Time.timeScale = 1;
        isGameOver = false;
    }
}