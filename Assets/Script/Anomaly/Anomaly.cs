using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly : MonoBehaviour
{
    // 1. �������̽��� �ؼ� ��ӽ�Ű�� ���� �´°�?
    // 2. Ŭ������ ����� ��ӽ�Ű�� ���� �´°� - ���� �����Ϸ��� Ŭ������ �´µ�?
    /*
       ���� ���
       �ִ��� �⺻ ������ �ʿ��Ѱ�...?
       �׳��� �������Ѱ� �̻����󳢸� ������ �� �ִ� ���� ��ȣ?
       �̻����� ���� ����
     */ 
    
    /*
       �Լ� ���
       1. �̻� ���� ������ �Լ�
       2. �̻� ���� ���� �ʱ�ȭ �Լ�
     */

    // ���� ���� ǥ���
    // �⺻, ����, ����, ���� ���ΰ�
    // Ʈ���� ������ enter - ������ interAction - �̻����� ���� �Ϸ�� or ���н� exit - �⺻�� default

    // ���۰� ���ÿ� ����Ǵ� ���, Ʈ���� �ߵ� �� ����

    public virtual void Init() // �̻����� ���� �ʱ�ȭ�� �Լ�
    {
        
    }

    public virtual void onEnable() // �̻����� ���� ���� Ȯ��
    {

    }

    public virtual void Play() // �̻����� ����
    {
        
    }


}
