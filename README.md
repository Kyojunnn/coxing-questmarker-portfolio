<img width="1672" height="941" alt="AR 캐릭터 선택 인터페이스" src="https://github.com/user-attachments/assets/f80cd2fc-8b3c-475c-903b-0e3a4479c54a" />

# CO·XING QuestMarker Demo

CO・XING QuestMarker Demo는 현실 기물을 XR 콘텐츠 편집을 위한 직관적인 인터페이스로 활용할 수 있는지 탐구하는 Unity 기반 MR 프로토타입입니다. Meta Quest의 카메라와 ArUco 마커 추적 기술을 활용하여 현실 기물의 위치와 회전을 가상 3D 캐릭터에 연결합니다.

**이 자료는 포트폴리오와 코드 검토를 위한 선별 공개 준비본입니다.** 주요 C# 코드 3개와 기술 문서를 포함하며, 씬·프리팹·모델·폰트·SDK·플러그인은 포함하지 않습니다. 이 폴더만 Unity에서 열어 빌드할 수 없습니다.

## 디자인 의도 (Design Motivation)

CO・XING은 창작자가 복잡한 제작 도구에 의존하지 않고, XR 공간에서 자신의 의도를 쉽고 직관적으로 표현하며 콘텐츠를 제작·편집할 수 있는 환경을 지향합니다.

이번 프로토타입은 다음과 같은 디자인 질문에서 출발했습니다.

**"XR 환경에서 콘텐츠를 더욱 쉽고 직관적으로 편집하려면, 어떤 인터랙션 방식이 적합할까?"**

기존 3D 편집 환경에서는 오브젝트의 위치와 회전을 조정하기 위해 별도의 조작 도구와 인터페이스를 익혀야 합니다. 이에 CO・XING은 인형놀이처럼 익숙한 물리적 행동을 콘텐츠 편집 과정에 적용하는 방법을 탐구했습니다.

특히 현실 기물을 가상 3D 캐릭터와 연결하여, 창작자가 물건을 직접 움직이는 행동만으로 가상 콘텐츠의 위치와 방향을 조정할 수 있는 방식을 구상했습니다.

이를 기술적으로 검토하기 위해 Unity와 Meta Quest 3의 패스스루 카메라, OpenCV 기반 ArUco 마커 추적 기술을 활용하여 현실 기물의 위치·회전을 가상 3D 오브젝트에 반영하는 프로토타입을 개발했습니다.

이번 데모는 단순한 객체 인식이나 3D 오브젝트 조작 기술의 구현을 넘어, **물리적 행동을 직관적인 XR 콘텐츠 편집 인터페이스로 활용할 수 있는 가능성을 탐색한 초기 프로토타입**입니다.

장기적으로 CO・XING은 창작자가 자신의 의도를 전달하면 AI가 공간과 인터랙션을 구성하고, 창작자가 XR 환경에서 이를 직접 체험하며 수정할 수 있는 창작 경험을 지향합니다.

자세한 디자인 의사결정 과정은 [Design Rationale](docs/DESIGN_RATIONALE.md)에서 확인할 수 있습니다.

## 기준과 현재 상태

- 개발 기준: **2025-12-13까지 개발된 상태를 기준으로 개발 재개 예정**.
- 자료 정리 및 공개 준비: **2026-11-26**. 과거 날짜의 커밋이나 빌드 성공을 복원했다는 뜻은 아닙니다.
- 현재 확인: 소스·기존 씬·설정의 정적 검토. 이번 준비 과정에서 Unity 컴파일·빌드·Quest 실행은 수행하지 않았습니다.
- 추적 안정성, FPS, 지연, APK와 소스 일치는 미검증입니다. 성능 개선안은 아직 구현하지 않았습니다.

## 먼저 볼 자료

| 자료 | 내용 |
|---|---|
| [프로젝트 개요](docs/PROJECT_OVERVIEW.md) | 사용자 경험, 프로젝트 범위와 출처 |
| [기술 구조](docs/TECHNICAL_ARCHITECTURE.md) | 카메라 → 검출 → 자세 추정 → 오브젝트 표시 |
| [구현 상태](docs/IMPLEMENTATION_STATUS.md) | 파일 확인 사실과 실행 미확인 항목 |
| [문제 해결](docs/TROUBLESHOOTING.md) | 소실 처리 결함 후보와 재현 계획 |
| [의존성과 통합 안내](docs/INTEGRATION_GUIDE.md) | 코드 검토에 필요한 외부 구성 요소와 복원 범위 |
| [개발 재개 계획](docs/REDEVELOPMENT_ROADMAP.md) | 기준 복원, 결함 수정, 성능 비교 순서 |

## 공개 코드

| 파일 | 역할 |
|---|---|
| [ArUcoTrackingAppCoordinator.cs](src/ArUcoTrackingAppCoordinator.cs) | 카메라 준비, ID 매핑, 표시 모드 전환 |
| [ArUcoMarkerTracking.cs](src/ArUcoMarkerTracking.cs) | 마커 검출·자세 추정·보간·스케일 등장/퇴장 |
| [IntroTextFader.cs](src/IntroTextFader.cs) | 인트로 UI 페이드 |

코드는 보존된 개발본에서 내용 변경 없이 선별했습니다. 기존 결함 후보도 남아 있으며 수정 완료 예제가 아닙니다. 코드의 SHA-256은 [파일 목록](PUBLICATION_MANIFEST.json)에 있습니다.

## 출처와 이용 조건

이 프로젝트는 [Takashi Yoshinaga의 QuestArUcoMarkerTracking](https://github.com/TakashiYoshinaga/QuestArUcoMarkerTracking) 및 Meta 카메라 샘플을 기반으로 합니다. 카메라·마커 검출 기반 전체를 독자 구현한 것으로 소개하지 않습니다. 출처와 보존한 MIT 고지는 [THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md)에 있습니다.

프로젝트 추가 코드와 문서의 별도 라이선스는 아직 선택하지 않았습니다. 이 준비본 전체를 MIT 또는 오픈소스로 표시하지 않습니다. 기존 제3자 MIT 허락은 해당 원저작물에 그대로 적용됩니다. 자세한 구분은 [LICENSE_POLICY.md](LICENSE_POLICY.md)를 확인하세요.

구매 플러그인, 권리 미확인 모델·폰트, 실행 파일·영상, 원본 대화 및 기존 개발 저장소의 Git 이력은 이 준비본에 포함하지 않았습니다.
