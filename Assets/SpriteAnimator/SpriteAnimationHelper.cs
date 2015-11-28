using UnityEngine;
using System.Collections;

namespace SimpleSpriteAnimator
{
    public class SpriteAnimationHelper
    {
        private float animationTime = 0.0f;

        public SpriteAnimation CurrentAnimation { get; set; }

        public SpriteAnimationHelper()
        {

        }

        public SpriteAnimationHelper(SpriteAnimation spriteAnimation)
        {
            CurrentAnimation = spriteAnimation;
        }

        public SpriteAnimationFrame UpdateAnimation(float deltaTime)
        {
            if (CurrentAnimation)
            {
                animationTime += deltaTime * CurrentAnimation.FPS;
                int currentFrame = (int)animationTime % CurrentAnimation.Frames.Count;

                return CurrentAnimation.Frames[currentFrame];
            }

            return null;
        }

        public void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            animationTime = 0f;
            CurrentAnimation = spriteAnimation;
        }
    }
}
