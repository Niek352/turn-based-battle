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

    public void StopAnim()
    {
        skeletonAnimation.loop = false;
        skeletonAnimation.timeScale = 0;
    }
    public void TriggerAnimation(string animationName, Action callback)
    {
        skeletonAnimation.AnimationState.Complete += AnimationStateOnEnd;
        
        var trackEntry = skeletonAnimation.AnimationState.SetAnimation(0, animationName, false);
        if (animationName == "Idle")
        {
            trackEntry.trackTime = 120f / 30f;
        }
        animOnCompleteCallback += callback;
    }
    private void AnimationStateOnEnd(TrackEntry trackEntry)
    {
        animOnCompleteCallback?.Invoke();
        animOnCompleteCallback = null;
        skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
        skeletonAnimation.AnimationState.Complete -= AnimationStateOnEnd;
    }
    
    
}