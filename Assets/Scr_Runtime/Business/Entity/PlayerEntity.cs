using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJ {

    public class PlayerEntity : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;

        public int id;
        public int typeID;

        public float moveSpeed;

        public void Ctor() {

        }

        public void Move(Vector2 dir) {
            Vector2 pos = rb.velocity;
            dir = dir.normalized;
            pos = dir * moveSpeed;
            rb.velocity = pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}