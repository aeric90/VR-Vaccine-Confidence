using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_ui_controller : MonoBehaviour
{
    public TMPro.TextMeshPro lang_caption_text;
    public TMPro.TextMeshPro cc_caption_text;

    public SpriteRenderer en_sprite;
    public SpriteRenderer fr_sprite;

    public SpriteRenderer cc_on_sprite;
    public SpriteRenderer cc_off_sprite;

    public TMPro.TextMeshPro quit_button;
    public TMPro.TextMeshPro resume_button;

    public Sprite selected_lang;
    public Sprite normal_lang;

    public Sprite selected_cc_on;
    public Sprite normal_cc_on;
    public Sprite selected_cc_off;
    public Sprite normal_cc_off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Pause_Text(string lang_flag, string cc_flag)
    {
        if (lang_flag == "EN")
        {
            lang_caption_text.text = "Language Selected";
            cc_caption_text.text = "Closed Captioning";
            en_sprite.sprite = selected_lang;
            fr_sprite.sprite = normal_lang;
            quit_button.text = "QUIT";
            resume_button.text = "RESUME";
        }
        if (lang_flag == "FR")
        {
            lang_caption_text.text = "Langue Choisie";
            cc_caption_text.text = "Sous-Titrage";
            en_sprite.sprite = normal_lang;
            fr_sprite.sprite = selected_lang;
            quit_button.text = "QUIT";
            resume_button.text = "RESUME";
        }
        if (cc_flag == "yes")
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
