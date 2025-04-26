using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    float jumpForce;

    int jumpTimes;

    void Start() {
        rb = GetComponent<Rigidbody>();
        jumpForce = 3;
        jumpTimes = 1;
    }

    void Update() {
        float dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            jumpForce += 5 * dt;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            Jump();
        }
    }

    void Reset() {
        jumpForce = 3;
        jumpTimes = 1;
    }

    void Jump() {
        if (jumpTimes > 0) {
            Vector3 dir = new Vector3(1, 1, 0);
            rb.AddForce(dir * jumpForce, ForceMode.Impulse);
            jumpTimes--;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            Reset();
        }
    }
}
