using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Transform parentToReturnTo = null;

	public void OnBeginDrag (PointerEventData evenData)
	{
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);
	}

	public void OnDrag (PointerEventData evenData)
	{
		this.transform.position = evenData.position;
	}

	public void OnEndDrag (PointerEventData evenData)
	{
		this.transform.SetParent (parentToReturnTo);
	}
}
