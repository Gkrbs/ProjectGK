using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputCode
{
    KEY_UP,         //MOVE FORWARD
    KEY_DOWN,       //MOVE BACK
    KEY_LEFT,       //MOVE LEFT
    KEY_RIGHT,      //MOVE RIGHT

    KEY_JUMP,       //JUMP
    KEY_RUN,        //RUN
    KEY_SIT,        //SIT

    KEY_BASIC,      //USE BASIC FUNCTION OF ITEM OR etc.
    KEY_SPECIAL,    //USE SPECIAL FUNCTION OF ITEM OR etc.
    KEY_PASSOVER,   //PASS OVER ITEM TO USER
    KEY_TABLET,     //OPEN TABLET IN-GAME SETTING

    KEY_ACTION,     //TRIGGER STH
    KEY_SCAN,       //SCAN STH
    KEY_LIGHT,      //TURN ON HEADLIGHT
    KEY_THROW,      //THROW ITEM IN HAND
    KEY_RELOAD,     //RELOAD BATTERY OR MAGAZINE

    KEY_ITEM1,      //GET HOLD ITEMS
    KEY_ITEM2,
    KEY_ITEM3,
    KEY_ITEM4,
    KEY_ITEM5,

    KEY_ESC         //OPEN SYSTEM SETTINGS
}