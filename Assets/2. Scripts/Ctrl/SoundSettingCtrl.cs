using Jongmin;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingCtrl : MonoBehaviour
{
    [Header("Sound Setting UI")]
    [SerializeField]
    private Slider m_bgm_slider;

    [SerializeField]
    private Slider m_effect_slider;

    private bool m_bgm_slider_interactable;
    private bool m_effect_slider_interactable;
    private void Start()
    {
        m_bgm_slider.value = SoundManager.Instance.BgmVolume;
        m_effect_slider.value = SoundManager.Instance.EffectVolume;

        m_bgm_slider.onValueChanged.AddListener(OnBgmVolumeChanged);
        m_effect_slider.onValueChanged.AddListener(OnEffectVolumeChanged);

        m_bgm_slider_interactable = m_bgm_slider.interactable;
        m_effect_slider_interactable = m_effect_slider.interactable;
    }

    private void Update()
    {
        if(m_bgm_slider.interactable != m_bgm_slider_interactable)
        {
            m_bgm_slider_interactable = m_bgm_slider.interactable;

            if(m_bgm_slider_interactable)
            {
                SoundManager.Instance.BgmVolume = m_bgm_slider.value;
            }
            else
            {
                SoundManager.Instance.BgmVolume = 0f;
            }
        }
        if(m_effect_slider.interactable != m_effect_slider_interactable)
        {
            m_effect_slider_interactable = m_effect_slider.interactable;
            if(m_effect_slider_interactable)
            {
                SoundManager.Instance.SetEffectVolume(m_effect_slider.value);
            }
            else
            {
                SoundManager.Instance.SetEffectVolume(0f);
            }
        }
    }
    private void OnBgmVolumeChanged(float value)
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.BgmVolume = value;

            if(SaveManager.Instance.Player == null)
            {
                Debug.Log("사운드의 볼륨을 참조할 플레이어가 null입니다.");
                return;
            }

            SaveManager.Instance.Player.m_bgm_volume = value;
        }
        else
        {
            Debug.LogError("SoundManager가 null이라 백그라운드 볼륨을 조절할 수 없습니다.");
        }
    }

    private void OnEffectVolumeChanged(float value)
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.SetEffectVolume(value);

            if(SaveManager.Instance.Player == null)
            {
                Debug.Log("사운드의 볼륨을 참조할 플레이어가 null입니다.");
                return;
            }
            
            SaveManager.Instance.Player.m_effect_volume = value;
        }
        else
        {
            Debug.LogError("SoundManager가 null이라 이펙트 볼륨을 조절할 수 없습니다.");
        }
    }
}
