using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;


namespace DotRescue._Scripts
{
    public class Obstacle : MonoBehaviour
    {
        public bool HasGameFinished;

        [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;
        private float currentRotateSpeed;

        [SerializeField] private float _minRotateTime, _maxRotateTime;
        private float rotateTime;
        private float currentRotateTime;

        private void Awake()
        {
            HasGameFinished = false;

            currentRotateTime = 0;
            currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * Random.Range(0, 11) * 0.1f;
            rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * Random.Range(0, 11) * 0.1f;
            currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
        }

        private void Update()
        {
            currentRotateTime += Time.deltaTime;

            if (currentRotateTime > rotateTime)
            {
                currentRotateTime = 0f;
                currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * 0.1f * Random.Range(0, 11);
                rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);
                currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
            }
        }

        private void FixedUpdate()
        {
            if (HasGameFinished) return;
            transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);
        }
    }
}