using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
   [SerializeField] private SkeletonAnimation skeletonAnimation;

   private bool truefalse;
   private void OnMouseDown()
   {
      truefalse = !truefalse;
      var animName = truefalse ? "Idle" : "Damage";
      skeletonAnimation.AnimationState.SetAnimation(0,animName,true);
   }
}
