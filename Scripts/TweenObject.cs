using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TweenObject : MonoBehaviour
{
    public bool isYoyo = true;
	public GameObject TargetPosition;

	public float TweenTime;
	public float DelayTime = 0f;
	public Ease easeType = Ease.InOutSine;

	private string uniqueId;

	public bool isAutoStartAutomatically = true;

	void Start()
	{
		if(isAutoStartAutomatically)
		{
			StartTween();
		}
	}


	public void StartTween()
	{
		uniqueId = transform.GetInstanceID().ToString();

		if(TargetPosition != null)
		{
			DOTweenMove();
		}
	}



	private void DOTweenMove()
	{
        int numberLoops = isYoyo ? 2 : 1;

		// transform.DOMove(TargetPosition.transform.position, TweenTime).SetDelay(DelayTime).SetLoops(numberLoops, LoopType.Yoyo).SetEase(easeType).SetId(uniqueId).OnComplete(DOTweenMove);
		transform.DOMove(TargetPosition.transform.position, TweenTime).SetDelay(DelayTime).SetLoops(numberLoops, LoopType.Yoyo).SetEase(easeType).SetId(uniqueId).SetLoops(-1, LoopType.Restart);
	}

	public void StopMoving()
	{
		DOTween.Kill(uniqueId);
	}
}
