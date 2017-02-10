using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public GameObject gem;

	public void AddGem (Color color) {
		gem = GameObject.Instantiate(gem);

		RectTransform rectTransform = gem.GetComponent<RectTransform>();
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		anchoredPosition.x -= 32;
		rectTransform.anchoredPosition = anchoredPosition;
		gem.transform.SetParent(transform, false);

		var image = gem.GetComponent<Image>();
		if (image != null) {
			image.color = color;
		}
	}
}
