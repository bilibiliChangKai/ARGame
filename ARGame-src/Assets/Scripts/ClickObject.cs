using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClickObject : MonoBehaviour
{
    void Start()
    {
        //获取三个按钮
        GameObject btnstart = GameObject.Find("Canvas/Image/start");
        GameObject btncontinue = GameObject.Find("Canvas/Image/continue");
        GameObject btnout = GameObject.Find("Canvas/Image/out");


        //获取按钮脚本组件
        Button btns = (Button)btnstart.GetComponent<Button>();
        Button btnc = (Button)btncontinue.GetComponent<Button>();
        Button btno = (Button)btnout.GetComponent<Button>();


        //添加点击侦听
        btns.onClick.AddListener(delegate () {
            onClick(btnstart);
            UnityEngine.SceneManagement.SceneManager.LoadScene("xiaoxiaole");
        });

        btnc.onClick.AddListener(delegate () {
            onClick(btncontinue);
        });

        btno.onClick.AddListener(delegate () {
            onClick(btnout);
            Application.Quit();
        });
    }

    void onClick(GameObject obj)
    {
        Debug.Log("click: " + obj.name);
    }
}