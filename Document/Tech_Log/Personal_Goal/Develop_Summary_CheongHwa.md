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



### 2021-03-12

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



### 2021-03-15

```
STT, TTS는 안드로이드에서 바로 구현하기
```



### 2021-03-16

```
1. VR에서 멀티버스 구현하기

PUN(Photon Unity Networking) : 멀티플레이어 게임용 유니티 패키지 사용
```

```
2. 모션 인식

tensorflow.js / https://github.com/iconms12/Image_Captioning (pythorch 이미지 캡셔닝)
YOLO / 모션 인식 API 등 자료 조사 필요
```



### 2021-03-17

ec2에 nginx 설치하고 html 배포하기

```
$ sudo apt-get update
$ sudo apt-get install nginx
```

sites-available로 가서 default 파일을 수정한다.

```
$ cd /etc/nginx/sites-available
```

default

root /home/ubuntu/s04p22a401/Web/eriene; (index.html 이 있는 위치) 로 수정 후 nginx 시작

```
$ systemctl start nginx
```

주소로 들어가서 잘 나오는지 확인

```
http://j4a401.p.ssafy.io/
```



### 2021-03-18

```
photon unity network 사용준비

- 유니티 2019.04 (LTS 버전 다운) -> Unity Hub: 유니티 버전 관리를 쉽게 해주는 툴
  (모듈 추가 Android Build Support, iOS Build Support, WebGL Build Support, 		Windows Build Support, 한국어)
- unity asset store에서 photon 추가
```



### 2021-03-19

```
unity에 photon import하기

- Unity asset store에서 PUN 다운한 뒤 appId 발급받기
- Unity 실행 -> Window -> asset store -> PUN import -> appId 붙여넣기
```

```
unity VScode에서 작업하기 (VS말고)
유니티 연동에 필요한 의존 라이브러리 설치
- 깃: https://git-scm.com
- 닷넷 코어: https://microsoft.com/net/core
- 모노: http://www.mono-project.com/download/
```



![keystore 생성](C:\Users\multicampus\AppData\Roaming\Typora\typora-user-images\image-20210319142628495.png)



### 2021-03-22

```
Unity-Firebase 연동

firebase에서 프로젝트(Unity, Android) google-services.json을 발급받은 뒤 
Unity 프로젝트 -> asset 폴더 내에 갖다 놓기

Streaming assets/firebase-services-desktop.json이 생성되면 인식 완료
!! 하지만 unable to load google-services-desktop.json 등 파베가 로드 안 되는 문제가 발생했을 때
```

```
* unable to load google-services-desktop.json 해결하기

1. 현재 해결방법은 없이 unity 2019.3.15f버전으로 다운그레이드 하였다....?!
	-> 우리는 2019.4인데,,,, ㅜ 일단 흐린눈,,
	
2. google-services.json 파일 때문이었는데, 파일 위치를 StreamingAssets로 옮겨주면 해결된다.
	-> 해결 안 된다.^^
	
3. https://firebase.google.com/docs/unity/setup?hl=ko 역시 공식문서 참조하기 ㅎ..
    .NET 4.x를 사용하는 경우 다음과 같은 방법으로 컴파일 오류를 해결하세요.

    모든 플랫폼에서 다음 DLL을 삭제하거나 사용 중지합니다.
    Parse/Plugins/Unity.Compat.dll
    Parse/Plugins/Unity.Tasks.dll
    모든 플랫폼에서 다음 DLL을 사용 설정합니다.
    Parse/Plugins/dotNet45/Unity.Compat.dll
    Parse/Plugins/dotNet45/Unity.Tasks.dll
    
    ....
    
4. 경로에 한글을 다 없앰 --> 정답...!! (경로에 한글은 앵간함 넣지 말자...)
```



### 2021-03-23

```
Android-Unity 연동위해 Android Studio plugin 작업 필요 

- 참조
https://xinyustudio.wordpress.com/2015/12/31/step-by-step-guide-for-developing-android-plugin-for-unity3d-i/

```

프론트 배포하는 방법 정리

- EC2에 HTML 배포하기
  https://www.notion.so/EC2-HTML-ee65722e4ed7484e88cc55b7cc6517f6

1. EC2 접속(mobaXtreme 가능)

   ```
   $ ssh -i J4A401T.pem ubuntu@j4a401.p.ssafy.io
   ```

2. ec2에 nginx 설치하고 html 배포하기

   ```
   $ sudo apt-get update
   $ sudo apt-get install nginx
   ```

3. git clone https://lab.ssafy.com/s04-ai-speech-sub3/s04p23a401.git 하고 index.html 위치 확인

4. sites-available로 가서 default 파일을 수정한다.

   ![https://user-images.githubusercontent.com/43662673/112101474-0a849000-8bea-11eb-8e5c-dba07af2414b.png](https://user-images.githubusercontent.com/43662673/112101474-0a849000-8bea-11eb-8e5c-dba07af2414b.png)

   ```
   $ cd ~
   $ cd /etc/nginx/sites-available
   $ sudo vi default
   ```

   4 - 1. default 파일 수정

   ![https://user-images.githubusercontent.com/43662673/112101684-6b13cd00-8bea-11eb-8b13-b0c3ba33ad7a.png](https://user-images.githubusercontent.com/43662673/112101684-6b13cd00-8bea-11eb-8b13-b0c3ba33ad7a.png)

   root /home/ubuntu/s04p22a401/Web/eriene; (index.html 이 있는 위치) 로 수정 후 nginx 시작

   ```
   $ systemctl start nginx
   ```

5. 주소로 들어가서 잘 나오는지 확인

   ```
   <http://j4a401.p.ssafy.io/>
   ```



- EC2에 HTML 업데이트하기

  https://www.notion.so/EC2-HTML-b8e0513e699c402d96a0c3c99023d8c6

  1. EC2 접속(mobaXtreme 가능)

     ```
     $ ssh -i J4A401T.pem ubuntu@j4a401.p.ssafy.io
     ```

  2. git directory로 이동

  ![https://user-images.githubusercontent.com/43662673/112101929-d3fb4500-8bea-11eb-8c21-eac62ae23c7e.png](https://user-images.githubusercontent.com/43662673/112101929-d3fb4500-8bea-11eb-8c21-eac62ae23c7e.png)

  ```
  $ cd s04p23a401
  $ git pull
  $ sudo service nginx restart
  ```

  3. 주소로 들어가서 잘 나오는지 확인

  ```
  http://j4a401.p.ssafy.io/
  ```


    여러 에러들

    ```
    Could not open lock file /var/lib/apt/lists/lock - open (13: Permission denied)
    
    1. sudo su, su 로 관리자 계정으로 넘어간다
    2. $ rm /var/lib/apt/lists/lock
    3. $ rm /var/cached/apt/archives/lock
    
    그 다음 $ apt-get upgrade -y 하면 apt-get이 에러 없이 잘 되는 것을 볼 수 있다.
    ```
    
    2. E: The repository 'http://ppa.launchpad.net/certbot/certbot/ubuntu focal Release' does not have a Release file. 에러
    
    ![image-20210323195500613](C:\Users\0901B\AppData\Roaming\Typora\typora-user-images\image-20210323195500613.png)
    
    ```
    sudo apt-add-repository -r ppa:certbot/certbot
    ```
    
    After that, the following commands do not generate any errors:
    
    ```
    sudo apt update
    sudo apt-get update
    ```


ubuntu에 기본으로 yum이 설치되어 있는 것 같으나 저번 플젝도 그렇고 이번 우리 서버에서도 yum이 없다..

![image](https://user-images.githubusercontent.com/43662673/112128641-f781b800-8c09-11eb-9f78-6644c3f5ea3e.png)



그래서  yum부터 설치하자

1. apt-get install yum
   ![image](https://user-images.githubusercontent.com/43662673/112129906-38c69780-8c0b-11eb-9dfb-283011d116fe.png)

   전에 해봤다.. 역시 안 된다.

2. yum-3.4.3.tar.gz 직접 다운받기

   2 - 1. wget을 이용하여 다운로드 한다.

   ![image](https://user-images.githubusercontent.com/43662673/112133768-5eee3680-8c0f-11eb-99ef-e9e1ce41ac2b.png)

   ```
   $ wget http://yum.baseurl.org/download/3.4/yum-3.4.3.tar.gz
   ```

   2 - 2. 확장자가 tar.gz이므로 tar을 이용하여 압축을 해제한다

   ```
   $ tar -xvzf yum-3.4.3-tar.gz
   ```

   2 - 3. 압축을 해제하면 폴더가 생성되므로, 해당 폴더로 이동

   ```
   $ cd yum-3.4.3
   ```

   -> 보통은 여기서 ./configure을 가서 make install을 하라고 해서 막힌다

   일단 이 상태에서도 인식을 못하는 건 마찬가지..

   ![image](https://user-images.githubusercontent.com/43662673/112131641-1afa3200-8c0d-11eb-980d-e663b48d9a0f.png)

   3 - 1. yum-3.4.3 폴더에 있는 yummain을 실행한다

   ```
   $ run ./yummain.py
   ```

   ![image](https://user-images.githubusercontent.com/43662673/112135205-e25c5780-8c10-11eb-8009-5bc47090f73e.png)

   안 되네...?



3. 이제부터는 sudo apt install yum이 가능하게 하기

   ![image](https://user-images.githubusercontent.com/43662673/112136254-0d937680-8c12-11eb-938b-5e826b0518b6.png)

   ubuntu version 확인

   ```
   $ lsb_release -a
   ```

   ![image](https://user-images.githubusercontent.com/43662673/112136610-872b6480-8c12-11eb-9e34-bd6874919ecb.png)

   

4. 미러사이트 건드리기!

   

   1) 일단 yum-3.4.3 폴더로 이동 -> etc/yum.repos.d 

   ![image](https://user-images.githubusercontent.com/43662673/112136841-dffafd00-8c12-11eb-9af4-19a719fd8789.png)

   yum.repos.d 파일이 없음 -> yum.conf 파일 건드려보기

    ![image-20210323204603821](C:\Users\0901B\AppData\Roaming\Typora\typora-user-images\image-20210323204603821.png)


### 2021-03-24

1. 예전 방법

   ```
   $ wget https://raw.githubusercontent.com/certbot/certbot/7f0fa18c570942238a7de73ed99945c3710408b4/letsencrypt-auto-source/letsencrypt-auto -O /opt/certbot-auto
   
   $ chmod 755 /opt/certbot-auto
   
   $ mv /opt/certbot-auto /기존설치경로/certbot-auto
   ```

2. certbot 홈페이지 가서 하라는 대로 하기

   우리 서버는 ubuntu 20.04니까 

   ![image](https://user-images.githubusercontent.com/43662673/112248319-124f3d80-8c99-11eb-9226-5a855c359aeb.png)

   위와 같이 들어가서 하라는 대로 따라한다.

   ```
   $ sudo snap install core; sudo snap refresh core
   $ sudo snap install --classic certbot
   $ sudo ln -s /snap/bin/certbot /usr/bin/certbot
   $ sudo certbot --nginx
   ```

   

![image](https://user-images.githubusercontent.com/43662673/112247741-2e9eaa80-8c98-11eb-9105-563d0357961a.png)



```
# openssl pkcs12 -export -in fullchain.pem -inkey privkey.pem -out keystore.p12 -name airpageserver -CAfile chain.pem -caname root
```

![image](https://user-images.githubusercontent.com/43662673/112248011-93f29b80-8c98-11eb-9577-e12008deb9fc.png)

비밀번호는 귀찮으니 그냥 root로 ㅎㅎ

어쨌든 위의 명령어를 치고 나면 keystore.p12가 생성된다.

![image](https://user-images.githubusercontent.com/43662673/112248118-c0a6b300-8c98-11eb-884b-a3bc1da1202c.png)

mv하라고 하지만 무서우니까 cp로 home 디렉토리로 이동

![image](https://user-images.githubusercontent.com/43662673/112248175-df0cae80-8c98-11eb-946a-6b5bd0533088.png)


### 2021-03-25

먼저 젠킨스도 웹서버이기 때문에 현재 Ubuntu에서 사용하는 포트를 확인한다.

포트확인 위해 nmap을 설치한다.

```
$ sudo apt-get install nmap
$ nmap localhost
```

![image](https://user-images.githubusercontent.com/43662673/112255119-f5b90280-8ca4-11eb-9b67-915ad8294efc.png)

8080포트를 사용하고 있지 않지만,, 혹시 모르니까 7070 포트를 사용하기로 한다.

그리고 Jenkins는 java가 필요하기 때문에 java가 설치되어 있는지 버전을 확인한다.

![image](https://user-images.githubusercontent.com/43662673/112255210-1f722980-8ca5-11eb-99b6-9c08da356878.png)



Jenkins 설치를 위한 repository key를 추가한다.

```
$ wget -q -O - https://pkg.jenkins.io/debian/jenkins-ci.org.key | sudo apt-key add -
```

![image](https://user-images.githubusercontent.com/43662673/112255325-47fa2380-8ca5-11eb-81e7-30dd5d166364.png)

추가가 되면 OK 메세지가 뜬다.

이번에는 repository를 추가한다.

![image](https://user-images.githubusercontent.com/43662673/112255375-65c78880-8ca5-11eb-8dbe-befafeb6443d.png)

이제 apt-get 업데이트 후 jenkins를 설치합니다.

```
$ sudo apt-get update
```

![image](https://user-images.githubusercontent.com/43662673/112255528-b9d26d00-8ca5-11eb-9b9c-cef5c199960d.png)

그런데 GPG error 가 나서 업데이트에 실패

```
W: GPG error: https://pkg.jenkins.io/debian-stable binary/ Release: The following signatures couldn't be verified because the public key is not available: NO_PUBKEY <16개의 대문자 알파벳>
```

그럴 때는 

```
$ sudo apt-key adv --keyserver  keyserver.ubuntu.com --recv-keys <아까 그 16개 대문자 알파벳>
```

로 해결할 수 있다.

![image](https://user-images.githubusercontent.com/43662673/112255604-e1293a00-8ca5-11eb-891c-2fdf919bedc5.png)



다시 apt-get update를 하자.

![image](https://user-images.githubusercontent.com/43662673/112255671-05851680-8ca6-11eb-9233-9049e0f266d3.png)

성공!

그 다음

```
$ sudo apt-get install jenkins
```

설치가 되면 Jenkins 실행하기 전에 포트를 변경한다.

포트 변경은 /etc/default/jenkins에서 한다.

```
$ sudo vim /etc/default/jenkins 
```

파일 안에서 HTTP_PORT를 찾아 7070으로 변경한다.

```
# port for HTTP connector (default 8080; disable with -1)
HTTP_PORT=7070
```

systemctl을 이용해 jenkins를 실행한다.

```
$ sudo systemctl start jenkins
```

systemctl은 아무런 메시지가 나오지 않습니다. 그래서 status로 상태를 확인해 봐야 한다.

```
$ sudo systemctl status jenkins
```

![image](https://user-images.githubusercontent.com/43662673/112257172-c5bf2e80-8ca7-11eb-9c61-464a7a105968.png)



이제 브라우저를 열고 http://j4a401.p.ssafy.io:7070 에 들어간다.

만약 아래와 같이 젠킨스 화면이 보이지 않는다면

![image](https://user-images.githubusercontent.com/43662673/112257479-42eaa380-8ca8-11eb-94ba-a0d7a7bad7b5.png)

```
$ sudo systemctl stop jenkins
$ sudo systemctl start jenkins
```

중지했다가 다시 시작하면 보인다.



/var/lib/jenkins/secrets/initialAdminPassword 이 경로에 있는 password를 확인해서 입력하라고 하니 뭐가 써있는지 보러 간다. (보안인증같은 거라고 한다.)

![image](https://user-images.githubusercontent.com/43662673/112257761-aaa0ee80-8ca8-11eb-8bb7-52494639fe36.png)



추천하는 플러그인 설치하고

![image](https://user-images.githubusercontent.com/43662673/112257788-b7254700-8ca8-11eb-99ec-3e285c43790f.png)

플러그인 설치 중

![image](https://user-images.githubusercontent.com/43662673/112257831-c7d5bd00-8ca8-11eb-8964-6f6ade500372.png)

플러그인 설치 끝나고 유저 생성 화면이보임 -> 자주 사용하는 계정과 비번을 입력

![image](https://user-images.githubusercontent.com/43662673/112258772-66165280-8caa-11eb-8a6f-dade321c27a9.png)

![image](https://user-images.githubusercontent.com/43662673/112258886-a1b11c80-8caa-11eb-92a5-7a586a0871bf.png)

끄읏


### 2021-03-26

이전에 Jenkins를 Gitlab에 연결까지 했고 머지했는데 반응이 업따..!

분명 build history에도 찍혔고

![image](https://user-images.githubusercontent.com/43662673/112315380-6f74de80-8ced-11eb-8b19-2fff82455d3b.png)

근데 바뀐 게 없단다...

![image](https://user-images.githubusercontent.com/43662673/112315421-7a2f7380-8ced-11eb-8fb7-6d8eb00684a9.png)



알고보니.,, 푸시할 때마다 shell을 수행하는 걸 넣어야 됐다...!

![image](https://user-images.githubusercontent.com/43662673/112315034-0beab100-8ced-11eb-82f1-3a28ad0631fd.png)

![image](https://user-images.githubusercontent.com/43662673/112315227-45bbb780-8ced-11eb-96e0-b498695f8dc8.png)



근데 저거 넣으니까 왜 자꾸 빌드 실패하는거지,,,?

Console Output을 보니까 경로가 home 디렉토리가 아니었다..

![image](https://user-images.githubusercontent.com/43662673/112316476-7c460200-8cee-11eb-9094-0632b5ab85f8.png)



경로 바꿔주니까 또 에러가,,

![image-20210324221636303](C:\Users\0901B\AppData\Roaming\Typora\typora-user-images\image-20210324221636303.png)



### SSH Key 생성해서 비밀번호 없이 pull하기

ubuntu에서 비밀번호 없이 pull할 수 있게 하자

![image](https://user-images.githubusercontent.com/43662673/112318932-e8c20080-8cf0-11eb-96b3-84f8e2a604b5.png)

id_rsa.pub이 있으면 ssh가 있는 것

https://goddaehee.tistory.com/254 여기 참고



근데 결국 https://webisfree.com/2017-05-19/git-%EC%95%84%EC%9D%B4%EB%94%94-%ED%8C%A8%EC%8A%A4%EC%9B%8C%EB%93%9C-%EC%9E%85%EB%A0%A5-%EC%95%88%ED%95%98%EB%8A%94-%EB%B0%A9%EB%B2%95 이걸로 해결..

### 2021-03-27

1. GitLab에서 access Token 발급받기

   위의 메뉴에서 Settings로 이동

![image](https://user-images.githubusercontent.com/43662673/112259660-03be5180-8cac-11eb-8b01-e28372eec981.png)

2. 권한 설정 후 Create Personal access token을 누른다.

   ![image](https://user-images.githubusercontent.com/43662673/112259753-27819780-8cac-11eb-9821-475941c7d1e8.png)

3. 생성된 토큰 복사

   ![image-20210324142146668](C:\Users\0901B\AppData\Roaming\Typora\typora-user-images\image-20210324142146668.png)

4. Jenkins에서 GitLab 플러그인 설치

   ![image](https://user-images.githubusercontent.com/43662673/112260212-dcb44f80-8cac-11eb-8e8c-ea15af94b1c7.png)

   ![image](https://user-images.githubusercontent.com/43662673/112260745-de324780-8cad-11eb-83e1-1c4f6212ff97.png)

기달기달,,

못참아서 그냥 끔 ㅋㅋㅋㅋ

뭐 껐다 키니까... Installed에 잘 있다. --> GitLab 말고,,, GitLab API를 설치하쟈

![image](https://user-images.githubusercontent.com/43662673/112263079-0d4ab800-8cb2-11eb-823b-cae41ab02d11.png)

![image](https://user-images.githubusercontent.com/43662673/112263196-408d4700-8cb2-11eb-8497-dc7d217f6b1e.png)

(global)을 눌러 들어간다.

![image](https://user-images.githubusercontent.com/43662673/112263167-32d7c180-8cb2-11eb-8994-2d330befc968.png)

adding some credentials를 눌러 들어간다.

![image](https://user-images.githubusercontent.com/43662673/112263320-72061280-8cb2-11eb-8b6e-80671d7781dc.png)

아까 받은 토큰도 넣어주고 OK

![image](https://user-images.githubusercontent.com/43662673/112263474-b5608100-8cb2-11eb-9623-771113cb7cf0.png)

new Item을 눌러준다.

![image](https://user-images.githubusercontent.com/43662673/112275212-b4cfe680-8cc2-11eb-8394-61a584f4af5c.png)



---

다시



![image-20210324211032561](C:\Users\0901B\AppData\Roaming\Typora\typora-user-images\image-20210324211032561.png)

![image](https://user-images.githubusercontent.com/43662673/112309886-418c9b80-8ce7-11eb-94a3-7172fadd2d8c.png)

요건 에러~

![image](https://user-images.githubusercontent.com/43662673/112309932-52d5a800-8ce7-11eb-9ce7-a7347fb9b0bc.png)

요건 성공~

![image](https://user-images.githubusercontent.com/43662673/112310016-6bde5900-8ce7-11eb-9822-f39cd164effd.png)

jenkins에 GitLab에 연동할 User 생성해야 함

![image](https://user-images.githubusercontent.com/43662673/112311006-8e24a680-8ce8-11eb-916e-409aa2aa47e5.png)

메뉴에서 New Item 눌러주고

![image](https://user-images.githubusercontent.com/43662673/112310879-68979d00-8ce8-11eb-9378-914545bab4c3.png)

여기서 파란색으로 스크랩한 부분이 webhook url이다.



다음으로 GitLab에서 webhook 등록해야 한다.

![img](https://tech.osci.kr/assets/images/86039236/9.png)

1. ID/Password 방식

![img](https://tech.osci.kr/assets/images/86039236/10.png)

2. Secret Token 방식

   다시 build Trigger에 가서 고급 버튼을 눌러주면

   ![image](https://user-images.githubusercontent.com/43662673/112311887-887b9080-8ce9-11eb-8035-0dc5f31103fb.png)

   위와 같이 발급 받을 수 있다.

   ![image](https://user-images.githubusercontent.com/43662673/112312207-e6a87380-8ce9-11eb-803a-fc9e4b8ca675.png)

   Test로 push events를 눌러보면

   ![image](https://user-images.githubusercontent.com/43662673/112312156-d98b8480-8ce9-11eb-9d47-671db187c972.png)

   위와 같이 잘 실행되는 것을 볼 수 있다.

찐찐

### 2021-03-28

PUN 사용하기 


### 2021-04-01
카메라 시점 변환하기