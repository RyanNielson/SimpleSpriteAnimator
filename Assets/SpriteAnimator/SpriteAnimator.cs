using UnityEngine;
using System.Collections.Generic;

namespace SimpleSpriteAnimator
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField]
        private List<SpriteAnimation> spriteAnimations;

        private SpriteRenderer spriteRenderer;

        private SpriteAnimationHelper spriteAnimationHelper;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            spriteAnimationHelper = new SpriteAnimationHelper(spriteAnimations[0]);
        }

        private void Update()
        {
            UpdateAnimation(Time.deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                Play("Nah");
            }

            if (Input.GetButtonDown("Horizontal"))
            {
                Play("Woo");
            }
        }

        public void Play(string name)
        {
            SpriteAnimation newSpriteAnimation = GetAnimationByName(name);

            // Need to just change animation instead of resetting.
            spriteAnimationHelper = new SpriteAnimationHelper(newSpriteAnimation);
        }

        private void UpdateAnimation(float deltaTime)
        {
            SpriteAnimationFrame frame = spriteAnimationHelper.UpdateAnimation(Time.deltaTime);

            spriteRenderer.sprite = frame != null ? frame.Sprite : null;
        }

        private SpriteAnimation GetAnimationByName(string name)
        {
            for (int i = 0; i < spriteAnimations.Count; i++)
            {
                if (spriteAnimations[i].Name == name)
                {
                    return spriteAnimations[i];
                }
            }

            return null;
        }
    }
}
