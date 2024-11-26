using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using Junyoung;

public class CoworkerAICtrl : MonoBehaviour
{
    [Header("Pathfinding")]
    private Transform m_target;

    [SerializeField]
    private float m_activate_distance = 10f;

    [SerializeField]
    private float m_path_update_seconds = 0.5f;

    [Header("Physics")]
    [SerializeField]
    private float m_speed = 150f;

    [SerializeField]
    private float m_next_waypoint_distance = 0.2f;

    [SerializeField]
    private float m_jump_node_height_requirement = 0.3f;

    [SerializeField]
    private float m_jump_modifier = 0.3f;

    [SerializeField]
    private float m_jump_check_offset = 0.1f;

    private bool m_follow_enabled = true;
    private bool m_jump_enabled = true;
    private bool m_direction_look_enabled = true;

    private Path m_path;
    private int m_current_waypoint = 0;
    private bool m_is_grounded = false;
    private Seeker m_seeker;
    private Rigidbody2D m_rigidbody;

    private void Start()
    {
        m_seeker = GetComponent<Seeker>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_target = FindAnyObjectByType<PlayerCtrl>().GetComponent<Transform>();

        InvokeRepeating("UpdatePath", 0f, m_path_update_seconds);
    }

    private void FixedUpdate()
    {
        if (m_follow_enabled && TargetInDistance())
        {
            PathFollow();
        }

        if (TargetReached())
        {
            m_follow_enabled = false;
            m_rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            m_follow_enabled = true;
        }
    }

    private void UpdatePath()
    {
        if(m_follow_enabled && TargetInDistance() && m_seeker.IsDone())
        {
            m_seeker.StartPath(m_rigidbody.position, m_target.position, OnPathComplete);
        }
    }

    private bool TargetReached()
    {
        float target_distance = 0.1f;

        return Vector2.Distance(transform.position, m_target.position) <= target_distance;
    }

    private void PathFollow()
    {
        if (m_path == null || m_current_waypoint >= m_path.vectorPath.Count)
        {
            return;
        }

        m_is_grounded = Physics2D.Raycast(
                                            transform.position, 
                                            Vector3.down, 
                                            GetComponent<Collider2D>().bounds.extents.y + m_jump_check_offset
                                         );

        Vector2 direction = ((Vector2)m_path.vectorPath[m_current_waypoint] - m_rigidbody.position).normalized;

        if (m_jump_enabled && m_is_grounded && direction.y > m_jump_node_height_requirement)
        {
            m_rigidbody.AddForce(Vector2.up * m_speed * m_jump_modifier, ForceMode2D.Impulse);
        }

        m_rigidbody.linearVelocity = new Vector2(direction.x * m_speed * Time.fixedDeltaTime, m_rigidbody.linearVelocity.y);

        if (Vector2.Distance(m_rigidbody.position, m_path.vectorPath[m_current_waypoint]) < m_next_waypoint_distance)
        {
            m_current_waypoint++;
        }

        if (m_direction_look_enabled)
        {
            if((direction.x < 0f))
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if((direction.x > 0f))
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, m_target.transform.position) < m_activate_distance;
    }

    private void OnPathComplete(Path p)
    {
        m_path = p;
        m_current_waypoint = 0;
    }
}