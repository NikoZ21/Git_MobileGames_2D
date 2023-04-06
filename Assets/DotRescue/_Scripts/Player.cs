using UnityEngine;

namespace DotRescue._Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private AudioClip _moveClip;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.Instance.PlaySound(_moveClip);
                _rotateSpeed *= -1f;
            }
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}