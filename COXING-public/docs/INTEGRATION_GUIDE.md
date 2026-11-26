# 의존성과 통합 안내

이 폴더는 독립 실행 프로젝트가 아닌 선별 소스 자료입니다. Unity Hub에서 이 폴더를 프로젝트로 열거나, 3개 스크립트만 복사해서 원래 데모가 재현된다고 기대해서는 안 됩니다.

## 필요한 외부 구성

| 구성 | 용도와 준비 범위 |
|---|---|
| Unity / Android 모듈 | 보존 개발 환경은 6000.2.4f1, ARM64 IL2CPP |
| OpenCV for Unity | ArUco·Calib3d·UnityUtils·ARUtils 등; 정당한 이용 권한에 따라 별도 설치 |
| Meta SDK / 카메라 샘플 | WebCamTextureManager, PassthroughCameraUtils, 카메라 권한, MetaCodeSample 속성 |
| Oculus 런타임 연동 | OVRInput, OVRPlugin, ToOVRPose 등 |
| Unity UI / TextMeshPro | RawImage, CanvasGroup, TextMeshProUGUI |
| 직접 구성할 씬과 콘텐츠 | 카메라 리그, Canvas, 카메라 앵커, ID별 GameObject, 사용 권한이 확보된 모델·폰트 |

OpenCVForUnity 네임스페이스를 사용하는 프로젝트 스크립트만 포함했습니다. 플러그인 구현·바이너리·배포 패키지는 포함하지 않았습니다. 오픈소스 OpenCV와 Unity용 상용 플러그인의 이용 조건은 구분합니다.

## 재구성 시 검토 순서

1. [기반 샘플](https://github.com/TakashiYoshinaga/QuestArUcoMarkerTracking)과 [Meta 카메라 샘플](https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples)의 해당 버전 안내·라이선스를 확인합니다.
2. 별도 Unity 실험 프로젝트에 호환되는 의존성을 설치하고 샘플 카메라 경로를 먼저 확인합니다. 보존 개발본과 최신 upstream의 패키지 조합이 같다고 가정하지 않습니다.
3. 이 자료의 스크립트와 같은 이름의 기존 컴포넌트가 있으면 중복 클래스가 생기지 않게 정리합니다. 기존 씬을 쓰는 경우 .meta/GUID와 Inspector 참조를 별도로 검토합니다. 이 준비본에는 .meta가 없습니다.
4. Coordinator의 WebCamTextureManager, 카메라 앵커, Canvas, RawImage, 검출기 및 마커 ID 목록을 연결합니다. ID 0/1의 대상은 권한이 확보된 단순 도형으로 시작할 수 있습니다.
5. IntroTextFader에는 CanvasGroup과 TMP UI를 구성합니다. 실제 마커 길이와 검출기 설정을 일치시킵니다.
6. 카메라 권한·빌드 씬을 점검한 뒤 [회귀 조건](TROUBLESHOOTING.md)에 따라 기기에서 검증합니다.

이 절차는 검토 방향이며, 공개 코드로 원본 데모를 동일하게 재현했다는 보장은 아닙니다. 보존 개발본의 OpenCV for Unity 실제 설치 버전과 카메라 샘플의 정확한 upstream 커밋은 아직 확정하지 못했습니다. 원본 샘플 README에 적힌 OpenCV for Unity 시험 버전 2.6.5는 설치본 확인값과 구분합니다.
