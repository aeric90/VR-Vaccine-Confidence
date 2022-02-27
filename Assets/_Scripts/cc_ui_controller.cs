using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cc_ui_controller : MonoBehaviour
{
    public TMPro.TextMeshPro lang_caption_text;
    public TMPro.TextMeshPro cc_caption_text;

    public SpriteRenderer en_sprite;
    public SpriteRenderer fr_sprite;

    public TMPro.TextMeshPro cc_text;
    public TMPro.TextMeshPro yes_button;
    public TMPro.TextMeshPro no_button;

    public Sprite selected_lang;
    public Sprite normal_lang;

    public void Set_CC_Text(string lang_flag)
    {
        if (lang_flag == "EN")
        {
            lang_caption_text.text = "Language Selected";
            cc_caption_text.text = "Closed Captioning";
            en_sprite.sprite = selected_lang;
            fr_sprite.sprite = normal_lang;
            cc_text.text = "Would you like to enable closed captioning?";
            yes_button.text = "YES";
            no_button.text = "NO";
        }
        if (lang_flag == "FR")
        {
            lang_caption_text.text = "Langue Choisie";
            cc_caption_text.text = "Sous-Titrage";
            en_sprite.sprite = normal_lang;
            fr_sprite.sprite = selected_lang;
            cc_text.text = "Souhaitez-vous activer le sous-titrage?";
            yes_button.text = "OUI";
            no_button.text = "NON";
        }
    }
}
