using Jongmin;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_slot_grid;
    private SlotData[] m_slots;

    void Start()
    {
        m_slots = m_slot_grid.GetComponentsInChildren<SlotData>();
    }

    public void AcquireItem(ItemData item, int count = 1)
    {
        if(item.ItemType != ItemType.Equipment)
        {
            for(int i = 0; i < m_slots.Length; i++)
            {
                if(m_slots[i].Item != null)
                {
                    if(m_slots[i].Item.ItemName == item.ItemName)
                    {
                        m_slots[i].SetSlotCount(count);
                        return;
                    }
                }
            }
        }

        for(int i = 0; i < m_slots.Length; i++)
        {
            if(m_slots[i].Item == null)
            {
                m_slots[i].AddItem(item, count);
                return;
            }
        }
    }

    public void OpenInventory()
    {
        GameEventBus.Publish(GameEventType.SETTING);
    }

    public void CloseInventory()
    {
        GameEventBus.Publish(GameEventType.PLAYING);
    }
}
