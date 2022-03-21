using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace VFX
{
    public class VFXEffect : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Color VFXColor = SnakeController.InstanceSnakeController.SnakeColor;

            ParticleSystem.MainModule DeadVFX = gameObject.GetComponent<ParticleSystem>().main;

            DeadVFX.startColor = VFXColor;
        }
    }
}
