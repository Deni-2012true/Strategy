using UnityEngine;
using UnityEngine;

public class InventorySlot : MonoBehaviour, IDropHandler
{

  public void OnDrop(PointerEventData eventData)  
  {
    if (transform.childCount == 0)
    {
        Gameobgect dropper = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
    }
  }
        
}
