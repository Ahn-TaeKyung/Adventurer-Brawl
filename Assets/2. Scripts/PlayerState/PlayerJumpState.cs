using UnityEngine;

namespace Junyoung
{
    public class PlayerJumpState : MonoBehaviour, IPlayerState
    {
        private PlayerCtrl m_player_ctrl;
        private float m_jump_power;
        private Rigidbody2D m_player_rigidbody;

        public void Handle(PlayerCtrl player_ctrl)
        {
            if (!m_player_ctrl)
            {
                m_player_ctrl = player_ctrl;
                m_jump_power = m_player_ctrl.JumpPowerP;
                m_player_rigidbody = m_player_ctrl.m_rigidbody;                              
            }

            m_player_rigidbody.linearVelocity = Vector2.up * m_jump_power; // if�� �ȿ� �ۼ��� ���� �ѹ��� ������
        }


    }
}