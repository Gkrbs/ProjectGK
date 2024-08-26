using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    // �ʿ��Ѱ�
    // 1. Ŭ���� ��Ȳ ������ �Լ�
    // 2. � �̻������� �ִ��� Ȯ�� ������ ����
    // 3. �̻�������� ��Ƴ��� �迭 - �迭? ����Ʈ?
    

    public List<Anomaly> anomaliesList = new List<Anomaly>(); // �ʱ� �̻����� ��Ƶ� ����Ʈ
    public List<Anomaly> clearAnomaliesList = new List<Anomaly>(); // ���� ����� ����� �̻����� ����Ʈ
    public Anomaly currentAnomaly; // ���� ��ġ�� �̻�����

    public bool anomalyClear; // ���� �̻������� Ŭ���� �Ǿ��°� Ȯ�ο�
    public bool isProgress; // ���� �̻������� �������ΰ�

    public int random;  

    public void AnomalyReset()
    {
        // ���� �Ϸ� ���ư��� ��� clear�� �Ѿ�� �ٽ� �ǵ�������
        if (currentAnomaly == null)
            return;
        currentAnomaly.Init();

    }

    // �̻����� ����
    public void AnomalyInstall()
    {

    }

    // �̻����� ����Ʈ ����
    public void AnomalyListReset()
    {

    }
}
