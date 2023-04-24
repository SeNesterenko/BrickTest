#### Тестовое задание на позицию UnityDeveloper

### **Реализация:** 
[Короткое видео](https://youtu.be/swUzexl0-Ac)

+ **1. Подготовка к игре:**

  Все навыки представленые в древе навыков на уровне, задаются через StartConfiguration : ScriptableObject. StartConfiguration состоит из массива [Serializable] SkillModel.
SkillModel включаем в себя все параметры навыка, необходимые по заданию, по типц его стоимости, названия, позиции на канвасе и списка скилов, которые могут буть доступны после
его изучения или скилов, необходимых для его изучения.

+ **2. Старт игры:**

![UML](https://user-images.githubusercontent.com/107647367/233989894-9d45bb17-b6c1-4155-ae37-45449bc4aaa1.png)
  GameManager - используется как точка входа в приложение и отвечает за порядок вызова инициализаций содержащихся классов. Так он берёт данные из StartConfiguration и передаёт необходимые модели в GraphCreator. После чего создаёт экземпляр класса PlayerSkillsHandler (который не является MonoBehaviour), передавая в него модель игрока, созданную в PlayerCreator.

+ **2. Генерация древа навыков и создание их UI представления:**

![UML](https://user-images.githubusercontent.com/107647367/233990929-ac81ca70-3bf7-4ef9-923a-ed97ea6afdd6.png)
  GraphCreator - принимает список навыков на уровне и на основе них отрисовывает граф с навыками на карте и генерирует SkillViewControllers. SkillViewControllers является свзяющим звеном между model и view. Так же отвечает за то, какие элементы View должны отрисовываться и прокидываением логики взаимодейсвтия с интерактивными объектами в EventBus. 

View - отвечает только за отрисовку ui, не содержит логику или данные.

Model - содержит в себе только данные объекта и не содержит логики.

  
  PlayerCreator - создаёт модель игрока, которая хранит в себе количество очков навыков и изученные навыки.
  
  PlayerSkillHandler - получает события из EventBus и обрабатывает запрос (изученя или забывания одного или нескольких навыков, а так же проверяет, какие доступны операции над навыков, в зависимости от того, что уже знает Player и отдаёт их дальше в EventBus).

