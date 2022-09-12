using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter.Units.Players
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Properties")]
        [SerializeField] private Vector2 velocity;
        [SerializeField] private SpriteRenderer armRenderer;
        [SerializeField] private List<SpriteRenderer> characterRenderers;
        
        [Header("Weapon Properties")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnerDirection;
        [SerializeField] private Transform weaponPivot;
        
        private Vector2 _currentMousePosition;
        private Vector2 _movement;
        
        public void OnShoot(InputValue value)
        {
            var t = bulletSpawnerDirection.transform;
            var bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.SetActive(true);
        }
        
        public void OnMovement(InputValue value)
        {
            _movement = value.Get<Vector2>();
        }

        private void Update()
        {
            _currentMousePosition = Mouse.current.position.ReadValue();
        }
        
        private void FixedUpdate()
        {
            MoveCharacter();
            RotateCharacterWeapon();
        }
        
        private void MoveCharacter()
        {
            var translation = _movement * velocity * Time.fixedDeltaTime;
            transform.Translate(translation, Space.World);
        }
        
        private void RotateCharacterWeapon()
        {
            var worldPos = Camera.main.ScreenToWorldPoint(_currentMousePosition);
            var newAim = (worldPos - transform.position).normalized;
            RotateArm(newAim);
        }
        
        private void RotateArm(Vector2 newAimDirection)
        {
            var rotationZ = Mathf.Atan2(newAimDirection.y, newAimDirection.x) * Mathf.Rad2Deg;
            FlipCharacterBasedOnAimAngle(rotationZ);
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        private void FlipCharacterBasedOnAimAngle(float rotationZ)
        {
            armRenderer.flipY = Mathf.Abs(rotationZ) > 90f;
            foreach (var characterRenderer in characterRenderers)
            {
                characterRenderer.flipX = armRenderer.flipY;
            }
        }
    }
}
