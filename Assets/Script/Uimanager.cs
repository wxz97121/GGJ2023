using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Uimanager : MonoBehaviour
{
    public GameObject Uipanel;
    public GameObject UipanelVisual;
    public GameObject p1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSumbitPnel()
    {
        Uipanel.SetActive(true);
        UipanelVisual.SetActive(true);
        p1.SetActive(false);

    }
    public void CloseSumbitPnel()
    {
        Uipanel.SetActive(false);
        UipanelVisual.SetActive(false);
        p1.SetActive(true);
    }
}
