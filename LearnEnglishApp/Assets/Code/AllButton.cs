using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class AllButton : MonoBehaviour
{
    [Header("LoginField")]
    public InputField usernameIF;
    string usernameString;
    public InputField passwordIF;
    string passwordString;

    [Header("SignupField")]
    public InputField RegisterEmailIF;
    string RegisterEmailString;
    public InputField RegisterpasswordIF;
    string RegisterpasswordString;
    public InputField RegisterEnterpasswordIF;
    string RegisterEnterpasswordString;

    [Header("Firebase")]
    Firebase.Auth.FirebaseAuth auth;
    public FirebaseUser Userfirebase;

    [Header("Panel")]
    public GameObject registerPanel;
    public GameObject mainPanel;

    private void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void LoginButton()
    {
        usernameString = usernameIF.text;
        passwordString = passwordIF.text;
        CheckLogin(usernameString, passwordString);
    }

    public void StartQuiz()
    {
        SceneManager.LoadScene("SettingQuiz", LoadSceneMode.Additive);
    }

    public void GotoQuizScene()
    {
        SceneManager.LoadScene("QuizScene", LoadSceneMode.Additive);
    }

    public void OpenRegisterButton()
    {
        registerPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void SignUpButton()
    {
        RegisterEmailString = RegisterEmailIF.text;
        RegisterpasswordString = RegisterpasswordIF.text;
        RegisterEnterpasswordString = RegisterEnterpasswordIF.text;

        if (RegisterpasswordString == RegisterEnterpasswordString)
        {
            CreatNewAccount(RegisterEmailString, RegisterpasswordString);
            Debug.Log("Create new account Succestful");
            registerPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Can not create new account");
        }
    }

    public void CloseRegisterpanle()
    {
        registerPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    void CheckLogin(string email , string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogFormat("Wrong");
                return;
            }
            SceneManager.LoadScene("MenuScene",LoadSceneMode.Additive);
        });
    }

    void CreatNewAccount(string email , string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled || task.IsFaulted)
            {
                return;
            }
        });
    }
}
