using UnityEngine;

namespace TopDownShooter.Units.Players
{
    public class Bullet : MonoBehaviour
    {
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

        private void DestroyItself()
        {
            Destroy(gameObject);
        }
    }
}
