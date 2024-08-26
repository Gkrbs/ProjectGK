using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    // 필요한것
    // 1. 클리어 상황 전달할 함수
    // 2. 어떤 이상현상이 있는지 확인 가능한 변수
    // 3. 이상현상들을 모아놓은 리스트

    static AnomalyManager _instance;

    public List<Anomaly> currentAnomaliesList = new List<Anomaly>(); // 게임 진행시 이상현상 담아둘 리스트
    public List<Anomaly> usedAnomaliesList = new List<Anomaly>(); // 게임 진행시 클리어된 이상현상 리스트
    
    public Anomaly currentAnomaly; // 현재 배치된 이상현상

    public int random;  

    public AnomalyManager Instance()
    {
        if(_instance == null)
        {
            _instance = new AnomalyManager();
        }
        return _instance;
    }
    // 이상현상 배정
    public void AnomalyInstall()
    {
        // 1. 랜덤한 숫자를 뽑는다
        // 2. 그 숫자에 맞는 index에 위치한 이상현상을 가져온다
        // 3. 이상현상을 currentAnomaly에 배치한다
        // 4-1 꺼내진 이상현상을 리스트에서 제외하고 clear로 옮긴다
        // 4-2 클리어 여부를 확인하고 리스트에서 제외하고 clear로 옮긴다
        
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
  
    // 이상현상 리스트 리셋
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
