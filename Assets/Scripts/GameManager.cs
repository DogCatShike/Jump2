using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public static bool isGameOver;

    public GameObject gameOver;
    public GameObject player;

    public GameObject groundPrefab;
    GameObject nowGround;
    List<GameObject> grounds;
    public Transform groundParent;
    Vector3 GroundPos;

    void Awake() {
        instance = this;

        isGameOver = false;
        grounds = new List<GameObject>();
        GroundPos = new Vector3(0, -1, 0);
    }

    void Update() {
        SpawnGround();
    }

    public void GameOver() {
        isGameOver = true;
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void OnRestartClick() {
        nowGround = null;
        DestroyGround();
        GroundPos = new Vector3(0, -1, 0);

        gameOver.SetActive(false);
        player.transform.position = Vector3.zero;
        Time.timeScale = 1;
        isGameOver = false;
    }

    public bool IsNewGround(GameObject ground) {
        if (nowGround == null) {
            nowGround = ground;
            return true;
        } else if (nowGround != ground) {
            nowGround = ground;
            return true;
        } else {
            return false;
        }
    }

    void SpawnGround() {
        if (grounds.Count < 3) {
            GameObject newGround = Instantiate(groundPrefab, groundParent);
            newGround.transform.position = GroundPos;
            grounds.Add(newGround);
            GroundPos.x += Random.Range(3f, 6f);
        }
    }

    public void DestroyGround() {
        bool canDestroy = false;

        for (int i = grounds.Count - 1; i >= 0; i--) {
            var ground = grounds[i];
            if (ground == nowGround) {
                canDestroy = true;
            }

            if (canDestroy && ground != nowGround) {
                grounds.Remove(ground);
                Destroy(ground);
            }

        }
    }
}