# 사진 읽어주는 인공지능
![image](https://user-images.githubusercontent.com/59387731/98904357-c88d6400-24fc-11eb-8daa-c15a09c4c0de.png)

# Pytorch tutorial
1) [스켈레톤](https://colab.research.google.com/drive/1p7jF-Hl07EMu7rfG5AbcfAEpManNFv5E?usp=sharing) 

# Introduction
본 프로젝트는 인공지능(AI : Artificial Intelligence)에 대한 원리 및 이해를 바탕으로 사용자에게 인공지능 기능을 적용한 웹 서비스 구축을 목표로 합니다. 

<img width="580" alt="Screen Shot 2020-11-28 at 1 53 14 PM" src="https://user-images.githubusercontent.com/59387731/100494055-1226b180-3181-11eb-975d-078edc7ca446.png">

전체 시스템은 위의 그림과 같이 3단계로 구성되어 있습니다.

- Image Captioning : 이미지를 설명하는 캡션 추출
- Text to Speech : 추출된 캡션을 스피치로 합성
- Voice Conversion : 합성된 스피치를 원하는 목소리로 변환

# Code organization
    ├── README.md             <- Top-level README.        
    │
    ├── web              <-- [GUI script]
    │   ├── web
    │       ├── static            <-- Static resource(css, js)
    │       ├── template          <-- Html (web page)
    │       ├── apps.py           <-- Configuration of app
    │       ├── urls.py           <-- Define url router
    │       ├── views.py          <-- Include business logic for reuqest
    │
    ├── speak_image           <-- [AI models]
    │   ├── IC                    <- Image captioning directory
    │       ├── image_captioning.py 
    │   ├── TTS                   <- Text-to-speech directory
    │       ├── tacotron.py
    │       ├── train.py
    │   ├── VC                    <- Voice conversion directory
    │       ├── preprocess
    │       ├── voice_conversion.py    
    │       ├── train.sh
    │   ├── Speak_Image.py    <- Defining all the AI models (connected to GUI)
    │   ├── main.py           <- main file (connected to GUI)

# Install Dependencies
**[WARNING] anaconda 가상환경을 사용하시는 것을 권장드립니다.**

```
#create venv
conda create -n [NAME] python=3.7.x
```
[NAME] : name of the virtual environment

```
#activate
source activate [NAME]
```

```
#deactivate
conda deactivate
```

다음으로 프레임워크 및 라이브러리를 설치합니다. 윈도우와 리눅스(우분투) 환경은 아래와 같습니다.
#### Windows(10)
`Widows10 / GPU: 2080-super / CUDA: 10.1 / cudnn: 7.5.1 / anaconda=4.9.2 기준`

#### Linux(Ubuntu)
`Ubuntu 18.04 / GPU: V100 / CUDA: 10.1 / cudnn: 7.6 / anaconda=4.8.2 기준`

1) pytorch 설치
```
conda install pytorch torchvision torchaudio cudatoolkit=10.1 -c pytorch
```
pytorch=1.7.0

2) tensorflow-gpu 설치
```
pip install tensorflow-gpu
```

tensorflow-gpu=2.4.0

3) 웹서버 django 설치
```
pip install django
```

(4) ffmpeg 설치
```
conda install -c conda-forge ffmpeg
```

5) 이외에 필요한 모듈을 설치
```
pip install -r requirements.txt
```

# Pre-trained model & build file

#### IC
(1) 동적 라이브러리 빌드하기
- /speak_image/IC/vqa_origin/ 로 이동
- `python setup.py build develop` 실행
- /speak_image/IC/vqa_origin/maskrcnn_benchmark/ 동적 라이브러리 생성 확인
**- windows의 경우 .pyd 파일, linux의 경우 .iso 파일이 만들어집니다**

(2) [detectron pre-trained model](https://drive.google.com/file/d/1A6S00G5uRtDYWrtB32QP5KkpYrgHBR68/view?usp=sharing) : /speak_image/IC/image_captioning.py 에서 경로 수정 필요

(3) [vocab](https://drive.google.com/file/d/13hJT7MV2K3ugC4gPE9hTvVR3PyuJzC67/view?usp=sharing) : /speak_image/IC/image_captioning.py 에서 경로 수정 필요

(4) [captioning pre-trained model](https://drive.google.com/file/d/1AZx47VgVLv58JtSe_FnWPSKfx88G72iS/view?usp=sharing) : /speak_image/IC/image_captioning.py 에서 경로 수정 필요

#### TTS
(1) [Tacotron pre-trained model](https://drive.google.com/file/d/1IUWQHB2cFQXekNuo-yCoKrY5wD8nNpnV/view?usp=sharing) : /speak_image/TTS/tacotron.py 에서 경로 수정 필요
**위 모델은 추가 학습이 더 필요한 모델입니다** 

(2) [Waveglow pre-trained model](https://drive.google.com/file/d/1lVP5gQoB-fi6aydKuxjVE64qMexGX2yL/view?usp=sharing) : /speak_image/TTS/tacotron.py 에서 경로 수정 필요


# Overall
/web 디렉토리로 이동하여 아래 명령 실행
```
python manage.py runserver [IP:PORT]
```

# Individual Models (Sub PJTs 기능명세서 )
**[WARNING] Sub PJTs 기능 명세서를 참고하여 작성하시길 바랍니다.**
## IC (Image Captioning) => Sub PJT 1
### TODO
/speak_image/IC로 이동하여 아래 항목을 작성 필요
- **requirements.txt** : 필요한 라이브러리 기입하여 한번에 install
- **image_captioning.py** : 작성되어 있는 Caption_Model, FeatureExtractor 클래스를 이해하여 사진 입력시 캡셔닝 결과를 출력하는 main문 작성 

아래 명령을 통해 이미지를 입력하고, 캡셔닝 결과를 얻을 수 있다.
```
python image_captioning.py
```

## TTS (Text-to-Speech) => Sub PJT 2

### Audio preprocessing
(1) [Melspectrogram tutorial](https://colab.research.google.com/drive/1YRX9ZXKQFS8h_IJCkx3RiWAt7sp8jbga?usp=sharing) : 음성 데이터 전처리 방법에 대한 튜토리얼 입니다.

### TODO
/speak_image/TTS로 이동하여 아래 항목을 작성 필요
- **requirements.txt** : 필요한 라이브러리 기입하여 한번에 install
- **train.py** : 모델을 학습시키는 코드 작성
- **tacotron.py** : 학습시킨 모델에 텍스트를 입력하여 음성을 출력하는 코드 작성

### Training
(1) LJ Speech dataset 다운로드하여 /speak_image/TTS 에 위치

* [LJ Speech](https://keithito.com/LJ-Speech-Dataset/): 131,000개의 (음성, 텍스트) 단일 여성 음성 데이터

(2) /speak_image/TTS/filelists 로 이동하여 txt파일의 파일 위치 확인

(3) /speak_image/TTS 디렉토리로 이동하여 아래 명령어 실행
```
python train.py -o [PATH] -c [PATH]
```
- o : checkpoint를 저장할 디렉토리
- c : pre-trained checkpoint의 주소
- --warmstart : pre-trained model 사용하여 학습 이어서 진행 여부

### Inference
학습이 완료 된 이후에 /speak_image/TTS 디렉토리로 이동하여 checkpoint 위치를 설정 후 아래 명령어 실행
```
python tacotron.py
```


## VC (Voice Conversion) => Sub PJT 3
### TODO
/speak_image/VC로 이동하여 아래 항목을 작성 필요
- **requirements.txt** : 필요한 라이브러리 기입하여 한번에 install
- **/preprocess/make_datasets_vctk.py** : waveform을 mel-spectrogram으로 변환하는 convert_file() 함수 구현
- **solver.py** : 모델을 학습시키는 코드 작성
- **voice_conversion.py** : 학습시킨 모델에 음성 2개를 입력하여 음성을 변환시키는 코드 작성

### Preprocessing
(1) VCTK dataset 다운로드

* [CSTR VCTK Corpus](http://www.udialogue.org/download/cstr-vctk-corpus.html): 109의 스피커로 구성된 멀티 스피커 데이터셋.

(2) 데이터 전처리

/speak_image/VC/prepreprocess 디렉토리로 이동하여 vctk.config 수정 후 아래 명령어 실행
```
./preprocess_vctk
```
- **segment\_size** : 학습을 위한 segment size. Default: 128
- **data\_dir** : 전처리 이후 저장할 디렉토리.
- **raw\_data\_dir** :VCTK raw data 디렉토리.
- **n_out_speakers** : test 스피커 인원. Default: 20
- **test\_prop** : validation 비율. Default: 0.1
- **training\_samples** : training segments for training. Default: 10000000
- **testing_samples** : test segment 개수. Default: 10000
- **n\_utt\_attr** : Normalizaion을 위해 평균과 표준편차를 구할 utterances 개수. Default: 5000

### Training
/speak_image/VC/solver.py 작성을 완료한 이후에 /speak_image/ 디렉토리로 이동하여 아래 명령 실행
```
.train.sh
```
- **c** : configuration 파일의 저장 위치
- **d** : checkpoint를 저장할 디렉토리
- **train\_set** : 학습에 사용하는 데이터 파일
- **store\_model\_path** : 학습이완료된 모델을 저장할 위치
- **summary\_steps** : training loss를 주기적으로 기록하는 step
- **save\_steps** : 모델 저장 주기 step
- **iters** : 모델을 학습시키는 iteration 횟수

### Inference
학습이 완료 된 이후에 /speak_image/ 디렉토리로 이동하여 아래 명령 실행
```
python voice_conversion.py
```
voice_conversion.py 에서 source auido, target audio, checkpoint path 등 설정 필요


## References
- [Bottom-Up and Top-Down Attention for Image Captioning and Visual Question Answering](https://arxiv.org/pdf/1707.07998.pdf), P. Anderson, *et al*.
- [Natural TTS Synthesis by Conditioning WaveNet on Mel Spectrogram Predictions](https://arxiv.org/pdf/1712.05884.pdf), J. Shen, *et al*.
- [One-shot Voice Conversion by Separating Speaker and Content Representations with Instance Normalization](https://arxiv.org/pdf/1904.05742.pdf), J. Chou, *et al*.
- [MelGAN: Generative Adversarial Networks for Conditional Waveform Synthesis](https://arxiv.org/pdf/1910.06711.pdf), K. Kumar, *et al*.
- [WaveGlow: A Flow-based Generative Network for Speech Synthesis](https://arxiv.org/pdf/1811.00002.pdf), R. Prenger, *et al*.
- [ruotianluo's Image Captioning implementation](https://github.com/ruotianluo/ImageCaptioning.pytorch)
- [NVIDIA's Tacotron+WaveGlow implementation](https://github.com/NVIDIA/tacotron2)
- [jjery2243542's adaptive voice conversion implementation](https://github.com/jjery2243542/adaptive_voice_conversion)
- [descriptinc's MelGAN implementation](https://github.com/descriptinc/melgan-neurips)

