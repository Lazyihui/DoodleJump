using System;
using System.Collections;
using UnityEngine;

namespace DJ {
    public class PlatformEntity : MonoBehaviour {

        public float bounceSpeed;

        public void Ctor() {
            bounceSpeed = 9;
        }
    }
}