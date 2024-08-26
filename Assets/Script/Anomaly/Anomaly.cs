using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly : MonoBehaviour
{
    // 1. 인터페이스로 해서 상속시키는 것이 맞는가?
    // 2. 클래스로 만들고 상속시키는 것이 맞는가 - 변수 포함하려면 클래스가 맞는듯?
    /*
       변수 목록
       애당초 기본 변수가 필요한가...?
       그나마 가질만한건 이상현상끼리 구분할 수 있는 고유 번호?
       이상현상 진행 상태
     */ 
    
    /*
       함수 목록
       1. 이상 현상 발현용 함수
       2. 이상 현상 내부 초기화 함수
     */

    // 진행 상태 표기용
    // 기본, 진입, 실행, 종료 순인가
    // 트리거 밟으면 enter - 진행중 interAction - 이상현상 보고 완료시 or 실패시 exit - 기본은 default

    // 시작과 동시에 실행되는 경우, 트리거 발동 시 실행

    public virtual void Init() // 이상현상 내부 초기화용 함수
    {
        
    }

    public virtual void onEnable() // 이상현상 실행 조건 확인
    {

    }

    public virtual void Play() // 이상현상 실행
    {
        
    }


}
