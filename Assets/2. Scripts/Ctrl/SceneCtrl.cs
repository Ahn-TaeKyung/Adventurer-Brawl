using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Jongmin
{
    public class SceneCtrl : MonoBehaviour
    {
        private static string m_scene_name;

        [SerializeField]
        private Image m_progress_bar;

        private void Start()
        {
            StartCoroutine(LoadSceneProcess());
        }

        public static void ReplaceScene(string scene_name)
        {
            m_scene_name = scene_name;
            SceneManager.LoadScene("Loading");
        }

        private IEnumerator LoadSceneProcess()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(m_scene_name);
            op.allowSceneActivation = false;

            GameEventBus.Publish(GameEventType.LOADING);

            float timer = 0f;
            while(!op.isDone)
            {
                yield return null;

                if(op.progress < 0.7f)
                {
                    m_progress_bar.fillAmount = op.progress;
                }
                else
                {
                    timer += Time.unscaledDeltaTime;
                    m_progress_bar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                    
                    if(m_progress_bar.fillAmount >= 1f)
                    {
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }
            }
        }
    }
}