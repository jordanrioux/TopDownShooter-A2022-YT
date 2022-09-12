using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TopDownShooter.Units.Players
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private LayerMask levelCollisionLayer;
        [SerializeField] private Vector2 velocity;
        
        private void Awake()
        {
            Invoke(nameof(DestroyItself), 5f);
        }
        
        private void FixedUpdate()
        {
            var translation = Vector2.up * velocity * Time.fixedDeltaTime;
            transform.Translate(translation, Space.Self);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << other.gameObject.layer)))
            {
                DestroyItself();    
            }
        }

        private void DestroyItself()
        {
            Destroy(gameObject);
        }
    }
}
