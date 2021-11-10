using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct EquipmentSlot
{
    [SerializeField] private Item item;
    public Item EquipedItem
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
            itemEquiped.Invoke(this);
        }
    }
    public Transform visualLocation;
    public Vector3 offset;

    public delegate void ItemEquiped(EquipmentSlot _item);
    public event ItemEquiped itemEquiped;
}
public class Equipment : MonoBehaviour
{

    public EquipmentSlot primary;
    public EquipmentSlot secondary;
    public EquipmentSlot defenseive;
    // Start is called before the first frame update
    void Awake()
    {
        primary.itemEquiped += EquipItem;
        secondary.itemEquiped += EquipItem;
        defenseive.itemEquiped += EquipItem;
    }
    private void Start()
    {
        EquipItem(primary);
        EquipItem(secondary);
        EquipItem(defenseive);
    }

    public void EquipItem(EquipmentSlot _item)
    {
        if (_item.EquipedItem.Mesh == null)
            return;
        foreach (Transform child in _item.visualLocation)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject meshInstance = Instantiate(_item.EquipedItem.Mesh, _item.visualLocation);
        meshInstance.transform.localPosition = primary.offset;
        OffsetLocal offset = meshInstance.GetComponent<OffsetLocal>();

        meshInstance.transform.position += offset.positionOffset;
        meshInstance.transform.localRotation = Quaternion.Euler(offset.rotationOffset);
        meshInstance.transform.localScale = offset.scaleOffset;
    }
}