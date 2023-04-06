using System;
using UnityEngine;

namespace _Scripts
{
    public class Parallax : MonoBehaviour
    {
        private MeshRenderer meshRenderer;
        public float animationSpeed;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0f);
        }
    }
}