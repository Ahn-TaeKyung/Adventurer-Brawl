using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Jongmin;

public class PlayStatusCtrl : MonoBehaviour
{
    [Header("Character")]
    [SerializeField]
    private GameObject[] m_character_portrait;
    [SerializeField]
    private TMP_Text m_character_name_text;

    [Header("Stamina")]
    [SerializeField]
    private Slider m_stamina_slider;
    [SerializeField]
    private TMP_Text m_player_stamina_text;

    [Header("Level")]
    [SerializeField]
    private Slider m_exp_slider;
    [SerializeField]
    private TMP_Text m_level_text;

    private void Start()
    {
        for(int i = 0; i < m_character_portrait.Length; i++)
        {
            if(i == (int)GameManager.Instance.CharacterType)
            {
                m_character_portrait[i].SetActive(true);
            }
            else
            {
                m_character_portrait[i].SetActive(false);
            }
        }

        switch(GameManager.Instance.CharacterType)
        {
            case Character.SOCIA:
                m_character_name_text.text = "소셔";
                break;
            
            case Character.GOV:
                m_character_name_text.text = "거브";
                break;

            case Character.ENVA:
                m_character_name_text.text = "엔바";
                break;
        }
    }

    void Update()
    {
        m_stamina_slider.value = (float)SaveManager.Instance.Player.m_player_status.m_stamina / SaveManager.Instance.Player.m_player_status.m_max_stamina;
        m_player_stamina_text.text = $"{SaveManager.Instance.Player.m_player_status.m_stamina} / {SaveManager.Instance.Player.m_player_status.m_max_stamina}";

        if(SaveManager.Instance.Player.m_player_status.m_current_level >= 10)
        {
            m_exp_slider.value = (float)SaveManager.Instance.Player.m_player_status.m_current_exp / ExpData.m_exps[8];
        }
        else
        {
            m_exp_slider.value = (float)SaveManager.Instance.Player.m_player_status.m_current_exp / ExpData.m_exps[SaveManager.Instance.Player.m_player_status.m_current_level - 1];
        }
        m_level_text.text = SaveManager.Instance.Player.m_player_status.m_current_level.ToString();
    }
}
