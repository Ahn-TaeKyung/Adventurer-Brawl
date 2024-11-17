using UnityEngine;

namespace Junyoung
{
    //PlayerCtrl���� �� Ŭ������ ��ü�� ����ؼ� �÷��̾��� ���¸� �����Ѵ�
    public class PlayerStateContext : MonoBehaviour
    {
        //������Ƽ, get,set���� ����� �а� �� �� ������ �ο��ϴ� ��� get,set�� ������ ���� ������ �ϴ� ������ ���� ������ ��, ĸ��ȭ�� ���� ���� ����
        //(���߿� ������ �߰� �����ϱ� ������ ������Ƽ�� �ۼ�, ��ȿ�� �˻糪, ���߿� ���� ������ �߰��ϰų� �ϴ� Ȯ�强�� ����)
        //PlayerStateContext ��ü�� �����ϰ� �ִ� �÷��̾��� ���¸� ������(IPlayerState�� ���¸� �߻�ȭ�� �������̽��ϱ� IPlayerState�� ������ Ŭ�������� ���� ����)
        public IPlayerState CurrentState
        { 
          get; 
          set; 
        }

        private readonly PlayerCtrl m_player_ctrl;

        //������, PlayerStateContext ��ü�� ������ �� ȣ��ż� PlayerCtrlŬ������ �ν��Ͻ��� m_player_ctrl �ʵ忡 �Ҵ�
        //-> �� Ŭ�������� PlayerCtrl ��ü�� ���������� ���� �� �� �ְ� ��
        public PlayerStateContext(PlayerCtrl player_controller) //context�� �����ϴ� playerCtrl�� ��ü�� �б� �������� �ҷ��� 
        {
            m_player_ctrl = player_controller;
        }

        //�� �� �޼��带 ���� PlayerCtrl���� ���¸� ������
        public void Transition() // ���� ���¿� ���� m_player_ctrl�� ������ �����ϰ� ��
        {
            CurrentState.Handle(m_player_ctrl);
        }

        public void Transition(IPlayerState state) //���¸� �����ϰ� ����� ���¿� �´� ������ �����Ŵ
        {
            CurrentState = state;
            CurrentState.Handle(m_player_ctrl);
        }
    }

}


