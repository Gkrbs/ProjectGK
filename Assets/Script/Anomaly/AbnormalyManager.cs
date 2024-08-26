using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalyManager : MonoBehaviour
{
    // �ʿ��Ѱ�
    // 1. Ŭ���� ��Ȳ ������ �Լ�
    // 2. � �̻������� �ִ��� Ȯ�� ������ ����
    // 3. �̻�������� ��Ƴ��� ����Ʈ

    public static AbnormalyManager instance;

    public List<Abnormaly> currentAbnomaliesList = new List<Abnormaly>(); // ���� ����� �̻����� ��Ƶ� ����Ʈ
    public List<Abnormaly> usedAbnomaliesList = new List<Abnormaly>(); // ���� ����� Ŭ����� �̻����� ����Ʈ
    
    public Abnormaly currentAbnomaly; // ���� ��ġ�� �̻�����

    public bool isEnabled;

    public int random;  


    // �̻����� ����
    public void AbnomalyInstall()
    {
        // 1. ������ ���ڸ� �̴´�
        // 2. �� ���ڿ� �´� index�� ��ġ�� �̻������� �����´�
        // 3. �̻������� currentAnomaly�� ��ġ�Ѵ�
        // 4-1 ������ �̻������� ����Ʈ���� �����ϰ� clear�� �ű��
        // 4-2 Ŭ���� ���θ� Ȯ���ϰ� ����Ʈ���� �����ϰ� clear�� �ű��

        isEnabled = Random.Range(0, 2) == 1 ? true : false;

        if (!isEnabled)
            return;

        int random = Random.Range(0, currentAbnomaliesList.Count);
        Abnormaly selectedAbnormaly = currentAbnomaliesList[random];
        currentAbnomaliesList.RemoveAt(random);
        usedAbnomaliesList.Add(selectedAbnormaly);
        currentAbnomaly = selectedAbnormaly;
        currentAbnomaly.ReInit();
    }

    public void AnomalyReset()
    {        
        if (currentAbnomaly == null)
            return;
        currentAbnomaly.ReSet();
    }

    //�̻����� Ŭ���� �� �� ȣ�� �ؾ��ϴ� �Լ�
    public void ClearAnormaly()
    {
        currentAbnomaly.isClear = true;
        Abnormaly abnormaly = currentAbnomaly;
        usedAbnomaliesList.Add(abnormaly);
        currentAbnomaly = null;
    }

    // �̻����� ����Ʈ ����
    public void AnomalyListReset()
    {
        currentAbnomaliesList.AddRange(usedAbnomaliesList);
        usedAbnomaliesList.Clear();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<AbnormalyManager>();
        }
        else
            Destroy(gameObject);
    }

}
