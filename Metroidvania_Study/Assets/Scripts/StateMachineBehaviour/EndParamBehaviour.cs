using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour      // ������Ʈ �ӽ� Behaviouer
{
    public string parameter = "IsAttacking";                // �ִϸ����Ϳ��� ������ �Ķ���� ���� ����

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // �ִϸ��̼��� ����ǰ� ��ȯ�Ǵ� �������� ������ �ִϸ��̼� �Ķ���� ���� true -> false ��Ų��.
        animator.SetBool(parameter, false);
    }
}
