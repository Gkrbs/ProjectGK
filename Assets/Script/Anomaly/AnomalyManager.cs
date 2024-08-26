using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    // �ʿ��Ѱ�
    // 1. Ŭ���� ��Ȳ ������ �Լ�
    // 2. � �̻������� �ִ��� Ȯ�� ������ ����
    // 3. �̻�������� ��Ƴ��� ����Ʈ

    static AnomalyManager _instance;

    public List<Anomaly> currentAnomaliesList = new List<Anomaly>(); // ���� ����� �̻����� ��Ƶ� ����Ʈ
    public List<Anomaly> usedAnomaliesList = new List<Anomaly>(); // ���� ����� Ŭ����� �̻����� ����Ʈ
    
    public Anomaly currentAnomaly; // ���� ��ġ�� �̻�����

    public int random;  

    public AnomalyManager Instance()
    {
        if(_instance == null)
        {
            _instance = new AnomalyManager();
        }
        return _instance;
    }
    // �̻����� ����
    public void AnomalyInstall()
    {
        // 1. ������ ���ڸ� �̴´�
        // 2. �� ���ڿ� �´� index�� ��ġ�� �̻������� �����´�
        // 3. �̻������� currentAnomaly�� ��ġ�Ѵ�
        // 4-1 ������ �̻������� ����Ʈ���� �����ϰ� clear�� �ű��
        // 4-2 Ŭ���� ���θ� Ȯ���ϰ� ����Ʈ���� �����ϰ� clear�� �ű��
        
        int random = Random.Range(0, currentAnomaliesList.Count);
        Anomaly selectedAnomaly = currentAnomaliesList[random];
        currentAnomaliesList.RemoveAt(random);
        usedAnomaliesList.Add(selectedAnomaly);
        currentAnomaly = selectedAnomaly;
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
        if (_instance == null)
        {
            _instance = GetComponent<AnomalyManager>();
        }
        else
            Destroy(gameObject);
    }

}
