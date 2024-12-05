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
            moveSpeed = 5;
        }

        public void Move(Vector2 dir, Vector2 face) {
            Vector2 pos = rb.velocity;
            pos.x = dir.x * moveSpeed;
            rb.velocity = pos;

            // face 
            if (face.x > 0) {
                transform.localScale = new Vector3(1, 1, 1);
            } else if (face.x < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }



        public void TearDown() {
            Destroy(gameObject);
        }
    }
}