using UnityEngine;
using System;
using newDll15;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    const int size = 4;
    Game game;
    Sound sound;

    public Text movesLabel;
    public Text startLabel;

	void Start ()
	{
	    game = new Game(size);
	    sound = GetComponent<Sound>();
	    HideButtons();
	}

    public void OnStart()
    {
        System.Random rnd = new System.Random();
        int steps = rnd.Next(700, 1600);
        game.Start(steps);
        startLabel.text = "Перемешать";
        ShowButtons();
        sound.PlayStart();
    }

    public void OnClick()
    {
        if (game.Solved())
            return;
        string name = EventSystem.current.currentSelectedGameObject.name;
        // Парсим название кнопок (они содержат координаты XY)
        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));
        if (game.Press(x, y) > 0)
            sound.PlayMove();
        ShowButtons();
        if (game.Solved())
        {
            startLabel.text = "Старт";
            movesLabel.text = "Игра закончена за " + game.moves + " шаг(а)";
            sound.PlaySolved();
        }    
    }

    void HideButtons()
    {
        // Заполняем кнопки нулями и делаем их невидимыми
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigit(0, x, y);
    }

    void ShowButtons()
    {
        // Проходим по всему массиву и делаем кнопки видимыми
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigit(game.GetDigit(x, y), x, y);
        movesLabel.text = "Кол-во ходов: " + game.moves;
    }

    void ShowDigit(int digit, int x, int y)
    {
        string name = x + "" + y;
        // Находм кнопку по названию
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        // Пишем в кнопку цифру
        text.text = digit.ToString();
        
        button.GetComponentInChildren<Text>().color =
            (digit > 0) ? Color.black : Color.clear;
        button.GetComponentInChildren<Image>().color = 
            (digit > 0) ? Color.white : Color.clear; //Делаем кнопку видимой если в ней не 0
    }
}
