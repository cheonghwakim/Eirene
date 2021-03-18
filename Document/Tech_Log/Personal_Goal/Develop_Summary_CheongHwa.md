# 개발 일지 🐱‍👓

> 청화 개발 일지 

<br>

### 2021-03-10

- 색깔별 맵 컨셉 정하기

  | 색깔        | 의미                                                         |
  | ----------- | ------------------------------------------------------------ |
  | 빨강        | 노을 지는 컨셉 (일을 마치고 집에 돌아오는 길 노을이 지고 있는 느낌) |
  | 주황        | 단풍으로 물들어 있는 길을 걷는 (가을의 맑은 하늘을 보여주기 → 경쾌 낙천) |
  | 노랑        | 황금빛 건물이나 사막 (사막은 약간 황폐한 느낌이 있을 수도 있으니까 황금빛 건물 안을 탐험하는 느낌...) |
  | 초록        | 오솔길 걸으면서 식물들과 소통하는 느낌 (피톤치드~)           |
  | 파랑        | 바다, 섬에서 길 따라가면서 ~~ (조약돌, 불가사리 같은 거랑 상호작용) 아니면 배 타고 다니면서 |
  | 진청        | 보름달 뜬 밤, 평화로운 느낌                                  |
  | 보라        | 보랏빛 숲 속 탐험  (몽환적인 느낌)                           |
  | 자주 (핑크) |                                                              |

  

- 회의중

빨강 - 크리스마스 방, 난로 

노랑 - 황금빛 건물

파랑 - 난파선 보물상자, 열쇠 

진청 - 배타고 반딧불이



### 2021-03-11

SubPJT1 하면서 생긴 에러



1.  raise RuntimeError(message)

해결 방법:

```
File "/home/gerald/miniconda3/envs/maskrcnn_benchmark/lib/python3.8/site-packages/torch/utils/cpp_extension.py", line 1413, in _run_ninja_build
raise RuntimeError(message)
RuntimeError: Error compiling objects for extension

이 에러가 떴을 때: 현재 설치되어있는 CUDA와 맞지않은 pytorch 패키지가 설치되어 있어서 생긴 문제

1) 현재 설치되어있는 cuda 버전과 맞는 pytorch 패키지를 설치
conda install pytorch torchvision cudatoolkit=11.2 -c pytorch

conda install pytorch torchvision cudatoolkit=10.0 -c pytorch

2) 만약 image_captioning.py를 실행할 때 DLL load failed가 뜬다면
환경 변수에 'C:\ProgramData\Anaconda3\Library\bin' 를 추가해준다

만약 그래도 안 되면 Intel-openmp을 설치해본다.. 참고: https://mclearninglab.tistory.com/30
```

2. DLL load failed : 지정된 모듈이 ~ 

해결방법:

```
CuDNN 버전, pytorch 버전, cuda 버전을 맞춰야 함
```



## 2021-03-11

```
logging 사용하기

사용하는 이유: 
	- 파이썬 프로그램에서 발생한 로그를 파일로 기록한다.
	- 매일 새로운 파일이 생성되며, 생성날짜를 파일명에 넣고 싶다.

사용 방법: 
	1) logging 과 logging의 handler를 import
	
	- __init__.py 를 쓰지않으면 이렇게 하위 모듈 (= logging.handler) 를 별도로 가져와야 하는 경우도 있다.
	
	 
	
	2) logging.Formatter
	
	- 어떤 형식으로 로그가 생성될지를 정한다
	
	→ 여기서는 로그 생성시간(ms 단위까지) + "," + 메시지로 carLogFormatter 설정
	
	- %(asctimes)s 는 로그가 기록되는 시간
	
	- %(message)s 는 입력한 로그가 된다.
	
	 
	
	3) handler.TimedRotatingFileHandler
	
	- 링크 참조: https://docs.python.org/3/library/logging.handlers.html#timedrotatingfilehandler
	
	- 새로운 파일을 만드는 기준
	
	- 저장할 파일명은 car.log
	
	- when='midnight'의 경우 매일밤 자정에 새로운 파일이 만들어진다.
	
	- 이때 만들어지는 형식은 suffix에 따라 설정된다.
	
	→ 예를 들면 여기서는 carLogHandler.suffix = "%Y%m%d" 이므로 car.log.20180504
	
	-
	
	4) 실제 사용할 logger를 생성하고 설정
	
	- carLogger 를 만들고
	
	- 출력레벨을 INFO 이상으로 설정하고
	
	- handler를 추가
	
	 
	
	5) 실제 사용
	
	- carLogger.info("car is coming") 라고 사용하면
	
	- 2018-05-04 08:52:11, 599,car is coming 이라고 car.log 라는 파일에 저장이 된다.
	
	→ 밤 12시가 지나면 car.log.20180504 와 같은 이름으로 다른 파일이 생성됨
```

```
파이썬 self 이해하기

self는 객체의 인스턴스 그 자체를 말한다. 
즉, 객체 자기 자신을 참조하는 매개변수
객체지향 언어는 모두 이걸 메소드에 안보이게 전달하지만, 파이썬은 클래스의 메소드를 정의할 때 self를 명시한다.
메소드를 불러올 때 self는 자동으로 전달된다. self를 사용함으로 클래스내에 정의한 멤버에 접근할 수 있게된다.

근데 그래서 tacotron.py 에서 왜 self를 쓰는지 이해가 안 됨..
```









