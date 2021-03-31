using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//이 둘을 선언해야 JsonUtility, HttpWebRequest, StreamReader 등을 사용할 수 있다.
using System.IO;
using System.Net;

using System.Text;

public class TTSScript : MonoBehaviour
{
    private string apiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyCDAd1LVa8TOkpby_J9ezKK_bh9FO7vFcE";
    SetTextToSpeech tts = new SetTextToSpeech();

    // Start is called before the first frame update
    private void Start()
    {
        Init();
        CreateAudio();   
    }

    void Init(){
        SetInput si = new SetInput();
        si.text = "안녕하세요";
        tts.input = si;

        SetVoice sv = new SetVoice();
        sv.languageCode = "ko-KR";
        sv.name = "ko-KR-Wavenet-A";
        sv.ssmlGender = "FEMALE";
        tts.voice = sv;

        SetAudioConfig sa = new SetAudioConfig();
        sa.audioEncoding = "LINEAR16";
        sa.speakingRate = 0.8f;
        sa.pitch = 0;
        sa.volumeGainDb = 0;
        tts.audioConfig = sa;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //string값을 byte array -> float array로 변환
    private void CreateAudio(){
        //HttpWebRequest요청후 반환된 string값을 저장
        // Debug.Log(tts.input.text);
        // Debug.Log(tts.voice.languageCode);
        // Debug.Log(tts.audioConfig.audioEncoding);

        var str = TextToSpeechPost(tts);
        // Debug.Log("55 : "+str);
        //string값을 JsonUtility를 사용하여 JSON데이터 형식으로 다시 저장
        GetContent info = JsonUtility.FromJson<GetContent>(str);
        // Debug.Log("66 : "+info.audioContent);
        //JSON 형식으로 저장된 값을 byte array로 변환
        var bytes = Convert.FromBase64String(info.audioContent);
        // Debug.Log("77"+bytes[0]);
        //byte array를 float array로 변환
        var f = ConvertByteToFloat(bytes);
        Debug.Log("88"+f[0]);
        //create audio clip
        AudioClip audioClip = AudioClip.Create("audioContent",f.Length,1,44100,false);
        audioClip.SetData(f,0);
         Debug.Log("99"+audioClip);
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        Debug.Log("68 : here"+audioSource);
        audioSource.PlayOneShot(audioClip, 0.7F);//0.7F제발 추가해;
    }

    private static float[] ConvertByteToFloat(byte[] array){
        float[] floatArr = new float[array.Length/2];

        for(int i=0;i<floatArr.Length;i++){
            floatArr[i]=BitConverter.ToInt16(array,i*2)/32768.0f;
        }
        return floatArr;
    }

    //POST방식으로 웹과 소통하기 위한 메소드
    public string TextToSpeechPost(object data){
        //JsonUtility 사용.. string을 요청 보내기 위한 byte[]로 변환
        string str = JsonUtility.ToJson(data);
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        //요청을 보낼 주소와 세팅
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
       
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = bytes.Length;

        //Stream 형식으로 데이터를 보냄 request
        try{
            using(var stream = request.GetRequestStream()){
                stream.Write(bytes,0,bytes.Length);
                stream.Flush();
                stream.Close();
            }
           
            
            //여기서부터 안됨
            //요청 데이터에 대한 응답 데이터를 StreamReader로 받음
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader로 stream데이터를 읽음
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //stream데이터를 string으로 변환
            string json = reader.ReadToEnd();
            Debug.Log("json"+json);
            return json;
        }
        catch(WebException e){
            //log
            Debug.Log(e);
            return null;
        }
    }
}



[System.Serializable]
public class SetTextToSpeech{
    public SetInput input;
    public SetVoice voice;
    public SetAudioConfig audioConfig;
}
[System.Serializable]
public class SetInput{
    public string text;
    //public string ssml;
}
[System.Serializable]
public class SetVoice{
    public string languageCode;
    public string name;
    public string ssmlGender;
}
[System.Serializable]
public class SetAudioConfig{
    public string audioEncoding;
    public float speakingRate;
    public int pitch;
    public int volumeGainDb;
    //public int sampleRateHertz;
}
[System.Serializable]
public class GetContent{
    public string audioContent;
}


