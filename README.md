# ProjectManagerSimulator
Все компоненты, которые можно использовать для настройки будут вынесены в SO (ScriptableObject)

## Компонент настройки уровня:
- [Заголовок] Легкая сложность
- Список SO этапов легкой сложности(см. ниже)
- Список SO исходных фигур легкой сложности
- [Заголовок] Средняя сложность
- Список SO этапов средней сложности(см. ниже)
- Список SO исходных фигур средней сложности (см. ниже)
- [Заголовок] Харкорная сложность
- Список SO этапов хардкорной сложности(см. ниже)
- Список SO исходных фигур хардкорной сложности

### SO этапов:
- Список компонентов уровня (см.ниже)
- [Значение] Максимальное кол-во ошибок игрока
- [Заголовок] Настройки таймлайна
    - [Значение] Длительность
    - [Значение] Буст при корректном матчинге
    - [Значение] Замедление при некорректном матчинге
- [Заголовок] Настройка кофе
    - [Значение] Максимальное значение
    - [Значение] Дельта прирост за один тап

### Компонента уровня в виде SO будет содержать в себе поля:
- [Значение] Описание (опционально)
- [Перечисление] Тип фигуры
    - Круг
    - Квадрат
    - Четрехугольник
    - Пятиугольник
    - Шестиугольник
    - Восьмиугольник
- [Поле] Спрайт
- [Перечисление] Цвет фигуры
    - Черный
    - Синий
    - Голубой
    - Зеленый
    - Серый
    - Розовый
    - Красный
    - Белый
    - Желтый
- [Значение] Размер
- [Значение] Текст задачи
- [Значение] Время выполнения
- [Значение] Скорость перемещения

## Некоторый свод правил написания данного проекта:
- Что можно не делать от MonoBehaviour - не делать
- Все зависимости желательно внедрять через конструктор класса
- Никаких оптимизаций не использовать. Можно использовать FindObjectOfType, Instantiate прямо в сцену в рантайме, Find и т.п.
- Пилим проект в каком удобно стиле, главное чтобы работало. Но для удобного контроля сущностями предлагаю юзать MVC. Модели прокидываем в места где нужна зависимость.






