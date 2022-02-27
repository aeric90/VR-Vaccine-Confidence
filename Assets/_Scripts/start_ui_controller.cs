using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_ui_controller : MonoBehaviour
{
    public TMPro.TextMeshPro lang_caption_text;
    public TMPro.TextMeshPro cc_caption_text;

    public SpriteRenderer en_sprite;
    public SpriteRenderer fr_sprite;

    public SpriteRenderer cc_on_sprite;
    public SpriteRenderer cc_off_sprite;

    public TMPro.TextMeshPro start_text;
    public TMPro.TextMeshPro start_button;

    public Sprite selected_lang;
    public Sprite normal_lang;

    public Sprite selected_cc_on;
    public Sprite normal_cc_on;
    public Sprite selected_cc_off;
    public Sprite normal_cc_off;

    public void Set_Start_Text(string lang_flag, string cc_flag)
    {
        if (lang_flag == "EN")
        {
            lang_caption_text.text = "Language Selected";
            cc_caption_text.text = "Closed Captioning";
            en_sprite.sprite = selected_lang;
            fr_sprite.sprite = normal_lang;
            start_text.text = "If you'd like to make any changes, please select from the options above.<BR>When you're ready, please select START to begin your virtual experience.";
            start_button.text = "START";
        }
        if (lang_flag == "FR")
        {
            lang_caption_text.text = "Langue Choisie";
            cc_caption_text.text = "Sous-Titrage";
            en_sprite.sprite = normal_lang;
            fr_sprite.sprite = selected_lang;
            start_text.text = "Si vous souhaitez apporter des modifications, veuillez sélectionner l'une des options ci-dessus.<BR>Lorsque vous êtes prêt, veuillez sélectionner DÉMARRER pour commencer votre expérience virtuelle.";
            start_button.text = "DÉMARRER ";
        }
        if(cc_flag == "yes")
        {
            cc_on_sprite.sprite = selected_cc_on;
            cc_off_sprite.sprite = normal_cc_off;
        }
        if (cc_flag == "no")
        {
            cc_on_sprite.sprite = normal_cc_on;
            cc_off_sprite.sprite = selected_cc_off;
        }
    }
}
