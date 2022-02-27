using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class title_ui_controller : MonoBehaviour
{
    public TMPro.TextMeshPro title;
    public TMPro.TextMeshPro title_text;
    public TMPro.TextMeshPro button;

    private string text1 = "";
    private string text2 = "";

    private float time_elapsed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time_elapsed += Time.deltaTime;

        if(time_elapsed >= 8.0)
        {
            if(title_text.text == text1)
            {
                title_text.text = text2;
            } else
            {
                title_text.text = text1;
            }

            time_elapsed = 0.0f;
        }  
    }

    public void Set_Title_Text(string lang_flag)
    {
        if(lang_flag == "EN")
        {
            title.text = "Welcome to VERUSim";
            text1 = "You may move your head around to view the environment in 360 degrees, but you will be unable to physically move around in the virtual space";
            text2 = "Please select BEGIN to proceed to the nextr step to enable closed captioning";
            button.text = "BEGIN";
        }
        if(lang_flag == "FR")
        {
            title.text = "Bienvenue à VERUSim";
            text1 = "Veuillez noter que vous ne pourrez pas vous déplacer dans l’espace virtuel. Par contre, vous pourrez tourner votre tête pour voir l’environnement à 360 degrés";
            text2 = "Veuillez sélectionner COMMENCER pour passer à l'étape suivant. Un service de sous-titrage et une description sonore sont disponible.";
            button.text = "COMMENCER";
        }
        title_text.text = text1;
    }
}
