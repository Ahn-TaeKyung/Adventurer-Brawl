using Junyoung;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Data",menuName ="Scriptable Object/Enemy Status",order =int.MaxValue)]
public class EnemyStatus : ScriptableObject
{
    [SerializeField]
    private EnemyType m_enemy_type;
    public EnemyType EnemyType { get { return m_enemy_type; } }

    [SerializeField]
    private float m_enemy_hp;
    public float EnemyHP { get { return m_enemy_hp; } }

    [SerializeField]
    private float m_enemy_move_speed;
    public float EnemyMoveSpeed { get { return m_enemy_move_speed; } }

    [SerializeField]
    private float m_enemy_damage;
    public float EnemyDamage { get { return m_enemy_damage; } }

    [SerializeField]
    private float m_enemy_attack_delay;
    public float EnemyAttackDelay { get { return m_enemy_attack_delay; } }



}
