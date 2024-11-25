using UnityEngine;

public class OptionCtrl:MonoBehaviour
{
    public GameObject m_option_button;
 
    public void ActiveFunctionOption()
    {
        bool is_active = m_option_button.activeSelf;
 
        m_option_button.SetActive(!is_active);
    }
}
