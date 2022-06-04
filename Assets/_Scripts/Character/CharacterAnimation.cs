using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using Animation = Spine.Animation;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    private Action animOnCompleteCallback;
    
    private void Start()
    {
        skeletonAnimation.AnimationState.Complete += AnimationStateOnEnd;
    }

    private void AnimationStateOnEnd(TrackEntry trackEntry)
    {
        if (trackEntry.animation.name != "Idle")
        {
            animOnCompleteCallback?.Invoke();
            animOnCompleteCallback = null;
            skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
        }
    }
    
    public void TriggerAnimation(string animationName, Action callback)
    {
        skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);
        animOnCompleteCallback += callback;
    }
}