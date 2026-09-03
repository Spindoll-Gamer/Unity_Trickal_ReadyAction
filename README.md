# 🎮 [Ready? Action!]

> **[프로젝트 한 줄 요약]**

> 순서 맞추기 퍼즐게임

---

## 📌 1. 프로젝트 개요
* **개발 기간**: 4일
* **개발 인원**: 1인 (개인 프로젝트)
* **사용 기술**: Unity 6.3 LTS, C#, Git
* **담당 역할**: 기획, UI, 시스템 구현

---

## 🎬 2. 주요 기능 및 플레이 시연

<img width="600" height="332" alt="Image" src="https://github.com/user-attachments/assets/c5fe50a1-30f5-48c3-8745-4e946a6b1c48" />
<img width="600" height="335" alt="Image" src="https://github.com/user-attachments/assets/dba593f4-16b7-4fa2-b8a3-0967cb1055d3" />

---

## 🛠️ 3. 핵심 구현 내용

* **[Object Pooling]**: 오브젝트 풀링 기법을 활용하여 자주 사용하는 Ball과 효과음을 효율적으로 관리
  
* **[충돌과 레벨업]**:같은 등급의 Ball들이 충돌할 경우 
    
---

## 💡 4. 트러블슈팅 (Troubleshooting)

### ❓ 문제 상황
* 고속 낙하시 물체를 관통하는 터널링 현상발생
* 충돌시 공의 속도를 기본값으로 변경되게 시도 했으나, 동일 등급 공의 합성로직이 미발동 하는 2차 이슈 발생

### 🔍 원인 분석
* OnCollisionEnter2D의 누락과 기존방식인 Discrete는 고속이동시 프레임간의 이동계산이 충돌감지보다 먼저 일어난다는걸 확인

### 💡 해결 방법 및 성과
* Rigidbody의 Collision Detection 모드를 Continuous로 변경하여
  고속이동에도 연속 충돌 검사를 하여 터널링 해결 및 합성 로직 정상 발동 완료 및 OnCollisionEnter2D로직 추가

---

## 🏗️ 5. 순서도
<img width="600" height="1092" alt="Image" src="https://github.com/user-attachments/assets/09b34d09-6697-49fe-af3e-5d0c65eef37e" />
