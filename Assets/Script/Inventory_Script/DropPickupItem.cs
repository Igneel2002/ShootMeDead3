using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPickupItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private Camera cam;
    public void DropItem()
    {
        if (inventory.selectedItem == null)
        {
            return;
        }
        GameObject mesh = inventory.selectedItem.Mesh;
        if (mesh != null)
        {
            GameObject spawnMesh = Instantiate(mesh, null);
            spawnMesh.transform.position = dropPoint.position;
            DroppedItem droppedItem = mesh.GetComponent<DroppedItem>();
            droppedItem.item = new Item(inventory.selectedItem, 1);
        }

        inventory.selectedItem.Amount--;
        if (inventory.selectedItem.Amount <= 0)
        {
            //inventory.inventory.Remove(inventory.selectedItem);
            inventory.RemoveItemFromInventory(inventory.selectedItem);
            inventory.selectedItem = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 25f))
            {
                DroppedItem droppedItem = hitInfo.collider.GetComponent<DroppedItem>();

                if (droppedItem != null)
                {
                    inventory.AddItemToInventory(droppedItem.item);
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}