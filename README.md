# String expression evaluator
###Without using LINQ expression trees
Для добавления нового бинарного оператора:

1. Создать класс, наследуемый от абстрактного класса **BinaryExpressionBase**, реализующий интерфейсы *IExpression*, *IBinaryExpression*.

2. Добавить в словарь **OperatorsDictionary** статического класса **BinaryExpressionParser** запись,
  в качестве ключа использовать символ, в качестве значения - тип созданного класса
