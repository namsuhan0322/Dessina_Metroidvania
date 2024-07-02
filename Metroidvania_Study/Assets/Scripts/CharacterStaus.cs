using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStaus : MonoBehaviour
{
    [Header("���� �� ����")]
    public int hp = 10;                                 // �÷��̾� ����
    public bool invincible = false;                     // ���� ����
    public bool canMove = true;                         // �̵� ���� ����
    public bool isDashing = false;                      // ��� ����
    public bool canDash = true;                         // ��� ���� ���� ����
    public float mDashForce = 25f;                      // ��� ���� ��

    //=================================================================================
    // Ÿ�̸� ���� ��
    //=================================================================================

    public Timer stunTimer = new Timer(0.25f);          // ���� Ÿ�̾� 0.25f �� �Ҵ�
    public Timer invincibilityTimer = new Timer(1f);    // ���� Ÿ�̸� 1��
    public Timer moveTimer = new Timer(0f);
    public Timer checkTimer = new Timer(0f);
    public Timer endSlidingTimer = new Timer(0f);
    public Timer deadTimer = new Timer(1.5f);
    public Timer dashCooldownTimer = new Timer(0.6f);


    void Start()
    {
        
    }

    void Update()
    {
        //=================================================================================
        // Ÿ�̸� ������Ʈ
        //=================================================================================

        float deltaTime = Time.deltaTime;
        stunTimer.Update(deltaTime);
        invincibilityTimer.Update(deltaTime);
        moveTimer.Update(deltaTime);
        checkTimer.Update(deltaTime);
        endSlidingTimer.Update(deltaTime);
        deadTimer.Update(deltaTime);
        dashCooldownTimer.Update(deltaTime);

        //=================================================================================
        // Ÿ�̸� ���� üũ
        //=================================================================================

        if (!stunTimer.IsRunning())                             // ���� Ÿ�̸� ���� üũ
        {
            canMove = true;
        }

        if (!invincibilityTimer.IsRunning())                    // ���� Ÿ�̸� ���� üũ
        {
            invincible = false;
        }

        if (!moveTimer.IsRunning())                             // �̵� Ÿ�̸� ���� üũ
        {
            canMove = true;
        }

        if (isDashing && !dashCooldownTimer.IsRunning())        // ���� Ÿ�̸� ���� üũ
        {
            isDashing = false;
            canMove = true;
            canDash = true;
        }

        if (deadTimer.GetRemainingTime() <= 0)                  // ���� ���� ó��
        {
            // �� ó�� ��� ���ش�.
        }
    }

    public void StartDash(float dashDuration)
    {
        // animator.SetBool("isDashing", true);
        isDashing = true;
        canMove = false;
        canDash = false;
        dashCooldownTimer = new Timer(dashDuration);            // ���ο� Ÿ�̸� ����
    }

    public void ApplyDamage(int damage, Vector3 position)       // �������� �޾����� ��� ���� �ð��� �ְ� ���� ó��
    {
        if (!invincible)
        {
            // animator.SetBool("Hit", true);
            hp -= damage;

            if (hp <= 0)
            {
                deadTimer.Start();
            }
            else
            {
                stunTimer.Start();
                invincibilityTimer.Start();
            }
        }
    }
}
