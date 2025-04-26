using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    Vector3 offset;

    void Start() {
        offset = transform.position - target.position;
    }

    void Update() {
        Vector3 pos = target.position + offset;
        pos.y = transform.position.y;
        transform.position = pos;
    }
}