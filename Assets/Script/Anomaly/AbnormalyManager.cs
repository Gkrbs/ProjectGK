using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalyManager : MonoBehaviour
{
    // 필요한것
    // 1. 클리어 상황 전달할 함수
    // 2. 어떤 이상현상이 있는지 확인 가능한 변수
    // 3. 이상현상들을 모아놓은 리스트

    public static AbnormalyManager instance;

    public List<Abnormaly> currentAbnomaliesList = new List<Abnormaly>(); // 게임 진행시 이상현상 담아둘 리스트
    public List<Abnormaly> usedAbnomaliesList = new List<Abnormaly>(); // 게임 진행시 클리어된 이상현상 리스트
    
    public Abnormaly currentAbnomaly = null; // 현재 배치된 이상현상
    public Abnormaly delayAbnomaly = null; // 현재 배치된 이상현상

    public bool isEnabled;

    public int random;  


    // 이상현상 배정
    public void AbnomalyInstall()
    {
        // 1. 랜덤한 숫자를 뽑는다
        // 2. 그 숫자에 맞는 index에 위치한 이상현상을 가져온다
        // 3. 이상현상을 currentAnomaly에 배치한다
        // 4-1 꺼내진 이상현상을 리스트에서 제외하고 clear로 옮긴다
        // 4-2 클리어 여부를 확인하고 리스트에서 제외하고 clear로 옮긴다

        isEnabled = Random.Range(0, 2) == 1 ? true : false;

        if (!isEnabled)
        {
            if (currentAbnomaly != null)
                currentAbnomaly.ReSet();
            
            return;
        }

        if (delayAbnomaly != null)
        {
            currentAbnomaliesList.Add(delayAbnomaly);
            delayAbnomaly = null;
        }

        if (currentAbnomaly != null)
        {
            Abnormaly ab = currentAbnomaly;
            ab.ReSet();
            currentAbnomaly = null;
            delayAbnomaly = ab;
        }

        int random = Random.Range(0, currentAbnomaliesList.Count);
        Abnormaly selectedAbnormaly = currentAbnomaliesList[random];
        currentAbnomaliesList.RemoveAt(random);
        currentAbnomaly = selectedAbnormaly;
        currentAbnomaly.ReInit();
    }

    //이상현상 클리어 될 시 호출 해야하는 함수
    public void ClearAnormaly()
    {
        currentAbnomaly.isClear = true;
        Abnormaly abnormaly = currentAbnomaly;
        usedAbnomaliesList.Add(abnormaly);
        currentAbnomaly = null;
    }

    // 이상현상 리스트 리셋
    public void AnomalyListReset()
    {
        foreach (Abnormaly abnormal in usedAbnomaliesList)
        {
            abnormal.isClear = false;
        }

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
