using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    //Пример паттерна «Команда» для переназначения клавиш из книги "Шаблоны игрового программирования"
    //Также включает систему отмены, повтора и воспроизведения (undo, redo, replay)
    public class GameController : MonoBehaviour
    {
        public MoveObject objectThatMoves;
        
        //Клавиши, которые связаны с командами
        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        //Храним команды здесь, чтобы упростить отмену, повтор и воспроизведение
        //В книге используется один список и индекс
        //private List<Command> oldCommands = new List<Command>();
        //Начинаем с -1, потому что в начале мы ещё не добавили ни одной команды
        //private int currentCommandIndex = -1;
        //Но я думаю, что проще использовать два стека
        //При воспроизведении мы преобразуем стек отмены в массив
        private Stack<Command> undoCommands = new Stack<Command>();
        private Stack<Command> redoCommands = new Stack<Command>();

        private bool isReplaying = false;

        //Чтобы воспроизведение работало, нам нужно знать, где объект начал движение
        private Vector3 startPos;

        //Время между выполнениями каждой команды при воспроизведении, чтобы мы могли видеть происходящее
        private const float REPLAY_PAUSE_TIMER = 0.5f;



        void Start()
        {
            //Привязываем клавиши к командам по умолчанию
            buttonW = new MoveForwardCommand(objectThatMoves);
            buttonA = new TurnLeftCommand(objectThatMoves);
            buttonS = new MoveBackCommand(objectThatMoves);
            buttonD = new TurnRightCommand(objectThatMoves);

            startPos = objectThatMoves.transform.position;
        }



        void Update()
        {
            //Можем проверять ввод, пока идёт воспроизведение
            if (isReplaying)
            {
                return;
            }
            
            //Здесь мы будем делать движения пошагово, чтобы упростить систему отмены
            //Если бы мы двигались со скоростью * Time.deltaTime, систему отмены было бы сложнее реализовать.
            //При отмене Time.deltaTime может отличаться, поэтому мы окажемся в другой позиции, не той, где были ранее
            //Эту проблему можно решить, сохраняя где-нибудь Time.deltaTime 
            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }
            //Отмена с помощью U (ctrl + z иногда конфликтует с системой отмены редактора)
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (undoCommands.Count == 0)
                {
                    Debug.Log("Нельзя отменить, потому что мы вернулись в начало");
                }
                else
                {
                    Command lastCommand = undoCommands.Pop();

                    lastCommand.Undo();

                    //Добавляем это в стек повтора, если хотим повторить отмену
                    redoCommands.Push(lastCommand);
                }
            }
            //Повтор с помощью R
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (redoCommands.Count == 0)
                {
                    Debug.Log("Нельзя повторить, потому что мы в конце");
                }
                else
                {
                    Command nextCommand = redoCommands.Pop();

                    nextCommand.Execute();

                    //Добавляем в стек отмены, если хотим отменить повтор
                    undoCommands.Push(nextCommand);
                }
            }


            //Переназначение клавиш простой заменой кнопок A и D
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ref важен, иначе клавиши не будут заменены
                SwapKeys(ref buttonA, ref buttonD);
            }


            //Запуск воспроизведения
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());

                isReplaying = true;
            }
        }



        //Воспроизведение
        private IEnumerator Replay()
        {
            //Перемещаем объект обратно в начальную позицию
            objectThatMoves.transform.position = startPos;

            //Пауза, чтобы мы могли увидеть, что объект начал движение с начальной позиции
            yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);

            //Преобразуем стек отмены в массив
            Command[] oldCommands = undoCommands.ToArray();
            
            //Этот массив инвертирован, поэтому мы перебираем его с конца
            for (int i = oldCommands.Length - 1; i >= 0; i--)
            {
                Command currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);
            }

            isReplaying = false;
        }



        //Выполняет команду и управляет списком, чтобы работали системы воспроизведения, отмены и повтора
        private void ExecuteNewCommand(Command commandButton)
        {
            commandButton.Execute();

            //Добавляем новую команду в последнюю позицию списка
            undoCommands.Push(commandButton);

            //Удаляем все команды повтора, потому что при добавлении новой команды повтор не определён
            redoCommands.Clear();
        }



        //Меняет местами указатели двух команд
        private void SwapKeys(ref Command key1, ref Command key2)
        {
            Command temp = key1;

            key1 = key2;
            
            key2 = temp;
        }
    }
}