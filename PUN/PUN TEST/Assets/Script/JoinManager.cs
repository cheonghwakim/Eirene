using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
public class JoinManager : MonoBehaviour
{
    public bool IsFirebaseReady { get; private set; }
    // Start is called before the first frame updatepublic bool IsFirebaseReady { get; private set; }

    public InputField emailField;
    public InputField passwordField;
    public Button signUpButton;

    public static FirebaseApp firebaseApp;
    public static FirebaseAuth firebaseAuth;

    public static FirebaseUser User;

    public void Start()
    {
        // 파베 사용 가능한지 여부 검사 -> 가능하다면 객체 생성
        signUpButton.interactable = false;

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var result = task.Result;

                if (result != DependencyStatus.Available)
                {
                    Debug.LogError(result.ToString());
                    IsFirebaseReady = false;
                }
                else
                {
                    IsFirebaseReady = true;

                    firebaseApp = FirebaseApp.DefaultInstance;
                    firebaseAuth = FirebaseAuth.DefaultInstance;
                }

                signUpButton.interactable = IsFirebaseReady;
            }
        );
    }

    public void SignUp()
    {
        // 회원가입 버튼은 인풋 필드가 비어있지 않을 때 작동한다.
        if(emailField.text.Length != 0 && passwordField.text.Length != 0)
        {
            firebaseAuth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(
                task =>
                {
                    if(!task.IsCanceled && !task.IsFaulted)
                    {
                        Debug.Log("회원가입 성공");
                    }
                    else
                    {
                        Debug.Log("회원가입 실패");
                    }
                }
            );
            SceneManager.LoadScene("SignIn");
        }
    }
}
