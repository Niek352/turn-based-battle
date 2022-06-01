using System;
using UnityEngine;

namespace _Scripts.Character
{
    public class CharacterHover : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            StopHover();
        }

        public void Hover()
        {
            spriteRenderer.enabled = true;
        }

        public void StopHover()
        {
            spriteRenderer.enabled = false;
        }
    }
}