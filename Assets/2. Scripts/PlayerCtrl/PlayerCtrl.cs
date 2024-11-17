using UnityEngine;

namespace Junyoung
{
    public class PlayerCtrl : MonoBehaviour
    {

        private IPlayerState m_stop_state, m_move_state, m_jump_state, m_dead_state, m_clear_state; // PlayerStateContext�� �����ϱ� ���� ������ ���µ� ����
        private PlayerStateContext m_player_state_context; //�÷��̾��� ���¸� �������� �������̽� ����

        private void Start()
        {
            m_player_state_context = new PlayerStateContext(this); //Context�� PlayerCtrl ��ü �ڽ��� ����

            m_stop_state = gameObject.AddComponent<PlayerStopState>(); // context�� ���� ������ ���� ��ũ��Ʈ���� �ҷ���
            m_move_state = gameObject.AddComponent<PlayerMoveState>();
            m_jump_state = gameObject.AddComponent<PlayerJumpState>();
            m_dead_state = gameObject.AddComponent<PlayerDeadState>();
            m_clear_state = gameObject.AddComponent<PlayerClearState>();

            m_player_state_context.Transition(m_stop_state); // �÷��̾��� �ʱ� ���¸� ������ ����
        }

        public void StopPlayer()
        {
            m_player_state_context.Transition(m_stop_state);
        }

        public void MovePlayer()
        {
            m_player_state_context.Transition(m_move_state);
        }

        public void JumpPlayer()
        {
            m_player_state_context.Transition(m_jump_state);
        }

        public void DeadPlayer()
        {
            m_player_state_context.Transition(m_dead_state);
        }

        public void ClearPlayer()
        {
            m_player_state_context.Transition(m_clear_state);
        }
    }
}


