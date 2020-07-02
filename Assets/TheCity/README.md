# README

The City는 Google ARCore를 활용해 평면 인식(Cloud Anchor) & 이미지 인식(AugmentedImage)을 사용했습니다. 

##	평면 인식(Cloud Anchor)

### 보드게임
1. 게임 실행 후 디바이스를 움직여 평면 인식
2. 인식된 평면에 보드 게임 맵을 생성하고 보드판을 터치하면서 건물 건설 
3. 건물 건설을 완료하면 디바이스 카메라를 움직여 특정 이미지 인식
4. 포탈 씬으로 전환

**제작 스크립트**
https://github.com/ParkGG/TheCity/tree/master/Assets/TheCity/CloudAnchor/Scripts

## 이미지 인식(Augmented Image)

### 포탈
1. 보드게임 씬에서 건설했던 건물들을 확장
2. 사용자가 디바이스를 들고 이동하며 건설된 건물들 사이를 체험

**제작 스크립트**
https://github.com/ParkGG/TheCity/tree/master/Assets/TheCity/AugmentedImage/Scripts
