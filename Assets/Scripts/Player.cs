using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    ParticleSystem particle;

    float jumpForce;

    int jumpTimes;

    void Start() {
        rb = GetComponent<Rigidbody>();
        particle = GetComponentInChildren<ParticleSystem>();

        jumpForce = 0;
        jumpTimes = 1;
    }

    void Update() {
        float dt = Time.deltaTime;

        if (jumpTimes > 0) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                particle.Play();
            }

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
                if (jumpForce < 10) {
                    jumpForce += 6 * dt;
                } else {
                    jumpForce = 10;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
                Jump();
                particle.Stop();
                particle.Clear();
            }
        }

        Check();
    }

    void Reset() {
        jumpForce = 0;
        jumpTimes = 1;
    }

    void Jump() {
        if (GameManager.isGameOver) {
            return;
        }

        if (jumpTimes > 0) {
            Vector3 dir = new Vector3(1, 1, 0);
            rb.AddForce(dir * jumpForce, ForceMode.Impulse);
            jumpTimes--;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            bool isNewGround = GameManager.instance.IsNewGround(collision.gameObject);

            GameManager.instance.DestroyGround();
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Ground" && jumpTimes != 1) {
            Reset();
        }
    }

    void Check() {
        if (transform.position.y <= -3) {
            GameOver();
        }
    }

    void GameOver() {
        GameManager.instance.GameOver();
    }
}
