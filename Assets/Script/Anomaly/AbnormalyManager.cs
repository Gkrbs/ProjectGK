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

    public List<Abnormaly> currentAnomaliesList = new List<Abnormaly>(); // ���� ����� �̻����� ��Ƶ� ����Ʈ
    public List<Abnormaly> usedAnomaliesList = new List<Abnormaly>(); // ���� ����� Ŭ����� �̻����� ����Ʈ
    
    public Abnormaly currentAnomaly; // ���� ��ġ�� �̻�����

    public int random;  


    // �̻����� ����
    public void AnomalyInstall()
    {
        // 1. ������ ���ڸ� �̴´�
        // 2. �� ���ڿ� �´� index�� ��ġ�� �̻������� �����´�
        // 3. �̻������� currentAnomaly�� ��ġ�Ѵ�
        // 4-1 ������ �̻������� ����Ʈ���� �����ϰ� clear�� �ű��
        // 4-2 Ŭ���� ���θ� Ȯ���ϰ� ����Ʈ���� �����ϰ� clear�� �ű��
        
        int random = Random.Range(0, currentAnomaliesList.Count);
        Abnormaly selectedAbnormaly = currentAnomaliesList[random];
        currentAnomaliesList.RemoveAt(random);
        usedAnomaliesList.Add(selectedAbnormaly);
        currentAnomaly = selectedAbnormaly;
        currentAnomaly.Init();
    }

    public void AnomalyReset()
    {        
        if (currentAnomaly == null)
            return;
        currentAnomaly.Init();      
    }
  
    // �̻����� ����Ʈ ����
    public void AnomalyListReset()
    {
        currentAnomaliesList.AddRange(usedAnomaliesList);
        usedAnomaliesList.Clear();
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
