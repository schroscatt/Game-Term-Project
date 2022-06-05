using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
	public Transform swingTarget;
    private bool isGoingLeft;

    void Start()
    {
	    StartCoroutine(nameof(Swing));
    }


	void Update()
	{

	}

	IEnumerator Swing()
	{

		var duration = 5f;
		var elapsed = 1f;
		while (true)
		{
			elapsed += Time.deltaTime;
			var ratio = elapsed / duration;
			if (ratio >= 1f)
			{
				elapsed = Time.deltaTime;
				ratio = elapsed / duration;
			}

			var z = 0f;
			if (ratio <= 0.5f)
			{
				z = Mathf.Lerp(-60f, 60, 2f*ratio);
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
			}
			else
			{
				z = Mathf.Lerp(60f, -60f, 2f*(ratio - 0.5f));
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
			}
			
			yield return null;
		}
	}
	
}