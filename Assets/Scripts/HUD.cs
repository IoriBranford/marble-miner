using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public GameObject gemSlot;

	public Sprite gemSprite;

	public void FillGemSlot (GameObject gemSlot) {
		var image = gemSlot.GetComponent<Image>();
		image.sprite = gemSprite;
	}

	public GameObject AppendGemSlot (Color color) {
		gemSlot = GameObject.Instantiate(gemSlot);

		var rectTransform = gemSlot.GetComponent<RectTransform>();
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		anchoredPosition.x -= rectTransform.rect.width;
		rectTransform.anchoredPosition = anchoredPosition;

		gemSlot.transform.SetParent(transform, false);

		var image = gemSlot.GetComponent<Image>();
		if (image != null) {
			image.color = color;
		}

		return gemSlot;
	}
}
