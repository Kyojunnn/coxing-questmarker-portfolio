# CO·XING QuestMarker Demo

현실의 물건과 가상 인형을 연결해 XR 장면을 만드는 Unity 기반 프로토타입입니다. Quest 카메라 영상에서 ArUco 마커를 검출하고 마커 ID에 연결된 3D 오브젝트의 위치와 회전을 갱신하는 구조를 사용합니다. CREKI는 CO·XING의 이전 이름입니다.

**이 자료는 포트폴리오와 코드 검토를 위한 선별 공개 준비본입니다.** 주요 C# 코드 3개와 기술 문서를 포함하며, 씬·프리팹·모델·폰트·SDK·플러그인은 포함하지 않습니다. 이 폴더만 Unity에서 열어 빌드할 수 없습니다.

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
