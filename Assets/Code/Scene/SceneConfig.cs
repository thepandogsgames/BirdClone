using System;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Scene
{
    public class SceneConfig : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private void Awake()
        {
            InstancePlayer();
        }

        private void InstancePlayer()
        {
            Instantiate(player, Vector3.zero, quaternion.identity );
        }

    }
}
