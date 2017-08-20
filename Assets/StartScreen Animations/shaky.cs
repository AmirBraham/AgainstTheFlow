using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins;

public class shaky : MonoBehaviour {
	public RectTransform rect;

	// Use this for initialization
	void Start () {
		rect = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
//		/rect.DOShakeAnchorPos(Mathf.Infinity,50,5,10,false,false);
	}
}
