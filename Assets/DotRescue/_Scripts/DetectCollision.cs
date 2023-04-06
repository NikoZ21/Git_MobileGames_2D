using UnityEngine;

namespace DotRescue._Scripts
{
    public class DetectCollision : MonoBehaviour
    {
        [SerializeField] private AudioClip _loseClip;
        [SerializeField] private GamePlayManager _gm;
        [SerializeField] private GameObject _explosionPrefab;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("colliided");
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Instantiate(_explosionPrefab, transform.GetChild(0).position, Quaternion.identity);
                SoundManager.Instance.PlaySound(_loseClip);
                _gm.GameEnded();
                Destroy(gameObject);
            }
        }
    }
}
