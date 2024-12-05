using System;
using System.Collections;
using UnityEngine;

namespace DJ {
    public class PlatformEntity : MonoBehaviour {

        public int id;
        public int typeID;
        public float bounceSpeed;

        public void Ctor() {
            bounceSpeed = 9;
        }

        void OnCollisionEnter2D(Collision2D collision) {

            if (collision.contacts[0].normal == Vector2.down) {

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null) {
                    rb.velocity = Vector2.up * bounceSpeed;
                }
            }

        }

    }
}