using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    // 필요한것
    // 1. 클리어 상황 전달할 함수
    // 2. 어떤 이상현상이 있는지 확인 가능한 변수
    // 3. 이상현상들을 모아놓은 배열 - 배열? 리스트?
    

    public List<Anomaly> anomaliesList = new List<Anomaly>(); // 초기 이상현상 담아둘 리스트
    public List<Anomaly> clearAnomaliesList = new List<Anomaly>(); // 게임 진행시 사용할 이상현상 리스트
    public Anomaly currentAnomaly; // 현재 배치된 이상현상

    public bool anomalyClear; // 현재 이상현상이 클리어 되었는가 확인용
    public bool isProgress; // 현재 이상현상이 진행중인가

    public int random;  

    public void AnomalyReset()
    {
        // 이전 일로 돌아갔을 경우 clear로 넘어간걸 다시 되돌리도록
        if (currentAnomaly == null)
            return;
        currentAnomaly.Init();

    }

    // 이상현상 배정
    public void AnomalyInstall()
    {

    }

    // 이상현상 리스트 리셋
    public void AnomalyListReset()
    {

    }
}
