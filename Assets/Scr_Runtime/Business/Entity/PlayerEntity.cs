using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJ {

    public class PlayerEntity : MonoBehaviour {
        public int id;
        public int typeID;

        public void Ctor() {

        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}