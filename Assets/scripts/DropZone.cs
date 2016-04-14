﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter (PointerEventData eventData)
	{
	}

	public void OnPointerExit (PointerEventData eventData)
	{
	}

	public void OnDrop (PointerEventData eventData)
	{
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			d.parentToReturnTo = this.transform;
		}
	}


}
