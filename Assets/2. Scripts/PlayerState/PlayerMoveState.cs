using UnityEngine;

namespace Junyoung
{
    public class PlayerMoveState : MonoBehaviour, IPlayerState
    {
        private PlayerCtrl m_player_ctrl;

        public void Handle(PlayerCtrl player_ctrl) //���¿� ���� ������ �����Ѵ�
        {
            if (!m_player_ctrl) // ����ó�� null�� �ƴϸ� �ʱ�ȭ
            {
                m_player_ctrl = player_ctrl;
            }





        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}