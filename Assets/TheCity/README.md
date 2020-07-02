# README

The City는 Google ARCore를 활용해 평면 인식(Cloud Anchor) & 이미지 인식(AugmentedImage) & 주변 조명 인식을 사용했습니다. 

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


## 조명 인식


주변 조명 인식은 ARCore에서 제공되는 기능으로, 카메라에 보여지는 픽셀의 값을 인식하여 현실 공간의 빛을 계산합니다.

조명 인식 기능을 활용해 낮과 밤을 구분하고  건물에 낮과 밤의 차이를 주는 효과를 연출하였습니다.  
