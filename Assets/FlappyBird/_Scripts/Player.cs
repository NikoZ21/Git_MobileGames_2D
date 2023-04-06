using System;
using UnityEngine;

namespace _Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;
        private SpriteRenderer _spriteRenderer;
        private int spriteIndex;

        [SerializeField] float gravity = -9.8f;
        [SerializeField] private float strength = 5;
        private Vector3 direction;


        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    direction = Vector3.up * strength;
                }
            }

            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }


        private void AnimateSprite()
        {
            spriteIndex++;
            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }

            _spriteRenderer.sprite = sprites[spriteIndex];
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.CompareTag("Scoring"))
            {
                FindObjectOfType<GameManager>().IncreaseScore();
            }
            else if (col.transform.CompareTag("Obstacle"))
            {
                print("dead");
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }
}